using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;
using Utils;
using System.Collections;

namespace Web.Controllers
{
    public class SaleorderController : Controller
    {
        SaleOrderBLL sbll = new SaleOrderBLL();
        public ActionResult Index()
        {
            return View();
        }

        protected int GetRequest(string strName, int nDefault)
        {
            if (!string.IsNullOrEmpty(this.Request.Form[strName]))
                return int.Parse(this.Request.Form[strName].ToString());
            if (!string.IsNullOrEmpty(this.Request.QueryString[strName]))
                return int.Parse(this.Request.QueryString[strName].ToString());
            return nDefault;
        }
        public ActionResult SaleOrderView()
        {
            return View();
        }
        public ActionResult GetSaleOrderList(string paramList, int page, int limit)
        {
            Hashtable htParams = ComFun.StrToHasTable(paramList);
            //int nPage = GetRequest("page", 1);
            //int nRows = GetRequest("rows", 20);
            JsonData jodata = new JsonData();
           
            jodata = sbll.GetSaleOrder(paramList, page, limit);
            return Json(jodata, JsonRequestBehavior.AllowGet);

        }



        public ActionResult addsaleorder(int Id, string orderno, int customid, int saleuser,int executionstatus, float amount)
        {
            //var aadd = GetRequest("sales","");
            JsonData jodata = new JsonData();
            SaleOrder saleorder = new SaleOrder();
            saleorder.orderno = orderno;
            saleorder.customid = customid;
            saleorder.adduser = 1;
            saleorder.saleuser = saleuser;
            saleorder.audituser = null;
            saleorder.amount = amount;
            saleorder.executionstatus = executionstatus;
            saleorder.Id = Id;
            if (Id == 0)
            {
                jodata.code = sbll.AddSaleOrder(saleorder);

            }
            else
            {
                jodata.code = sbll.UpdateSaleOrder(saleorder);

            }
            if (jodata.code == 1)
            {
                jodata.msg = "添加成功！";
            }
            else
            {
                jodata.msg = "添加失败！";
            }
            return Json(jodata);
        }

        public ActionResult delsaleorder(string strid)
        {
            JsonData jodata = new JsonData();
            string[] arids = strid.Split(',');//定长 
            for (int i = 0; i < arids.Count(); i++)
            {
                int id = int.Parse(arids[i]);
                jodata.code = sbll.DelSaleOrder(id);
            }
            return Json(jodata);
        }
        public ActionResult AuduitSaleOrder(string strid,int type)
        {
            JsonData jodata = new JsonData();
            string[] arids = strid.Split(',');//定长 
            for (int i = 0; i < arids.Count(); i++)
            {
                int id = int.Parse(arids[i]);
                jodata.code = sbll.AuduitSaleOrder(id,type);
            }
            return Json(jodata);
        }
        

        public ActionResult GetOrderNewNo()
        {
            JsonData jodata = new JsonData();
            jodata.data = sbll.GetOrderNewNo();

            return Json(jodata, JsonRequestBehavior.AllowGet);
        }
    }
}