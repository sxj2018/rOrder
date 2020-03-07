using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;
using System.Collections;
using Utils;
using DAL;

namespace Web.Controllers
{
    public class CustomController : Controller
    {
        CustomBLL cusbll = new CustomBLL();
        MySaleOrderEntities db = new MySaleOrderEntities();
        // GET: Custom
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CustomView()
        {
            //var userid = Session["userid"] == null ? "": Session["userid"].ToString();
            //if (!string.IsNullOrEmpty(userid))
            //{
            //    var users = db.Users.Where(t => t.Id == int.Parse(userid)).FirstOrDefault();

            //}
            return View();
        }
        public ActionResult GetCustomList(string paramList,int page=1, int limit=10)
        {
            JsonData jodata = new JsonData();
            jodata = cusbll.GetCustom(paramList, page, limit);
            return Json(jodata, JsonRequestBehavior.AllowGet);

        }
        public ActionResult addCustom(string paramList)
        {
            Hashtable htParams = ComFun.StrToHasTable(paramList);
            JsonData jodata = new JsonData();
            SaleCustom salecutom = new SaleCustom();
            //var seuser = Session["userInfo"] as Users;
            if (htParams.Contains("Id"))
            {
                salecutom.Id = int.Parse(htParams["Id"].ToString()==""?"0": htParams["Id"].ToString());
            }
            if (htParams.Contains("name"))
            {
                salecutom.name = htParams["name"].ToString();
            }
            if (htParams.Contains("name"))
            {
                salecutom.saleuser = int.Parse(htParams["saleuser"].ToString()=="" ? "0" : htParams["saleuser"].ToString());
            }
            if (htParams.Contains("phone"))
            {
                salecutom.phone = htParams["phone"].ToString();
            }
            if (htParams.Contains("email"))
            {
                salecutom.email = htParams["email"].ToString();
            }
            if (htParams.Contains("address"))
            {
                salecutom.address = htParams["address"].ToString();
            }
            //salecutom.adduser = seuser.Id;
            if (salecutom.Id == 0)
            {
                jodata.code = cusbll.AddSaleCustom(salecutom);

            }
            else
            {
                jodata.code = cusbll.UpdateSaleCustom(salecutom);

            }
            if (jodata.code == 1)
            {
                jodata.msg = "添加成功！";
            }
            else
            {
                jodata.msg = "添加失败！";
            }
            return Json(jodata, JsonRequestBehavior.AllowGet);
        }

        public ActionResult delCustom(string strid)
        {
            JsonData jodata = new JsonData();
            string[] arids = strid.Split(',');//定长 
            for (int i = 0; i < arids.Count(); i++)
            {
                int id = int.Parse(arids[i]);
                jodata.code = cusbll.DelSaleCustom(id);
            }
            return Json(jodata);
        }

    }
}