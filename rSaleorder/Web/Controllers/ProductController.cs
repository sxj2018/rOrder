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
    public class ProductController : Controller
    {
        ProductBLL pbll = new ProductBLL();
        MySaleOrderEntities db = new MySaleOrderEntities();

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductView()
        {
            return View();
        }
        public ActionResult GetProductList(string paramList, int page=1, int limit=10)
        {
            Hashtable htParams = ComFun.StrToHasTable(paramList);
          
            JsonData jodata = pbll.GetSaleProdut(paramList, page, limit);
          
            return Json(jodata,JsonRequestBehavior.AllowGet);

        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult addproduct(string no, string cnname, string enname, string casno, string invotory, string stand, string purity, int cataId,string breadid,float price, int Id=0)
        {
            //var aadd = GetRequest("sales","");
            JsonData jodata = new JsonData();
            SaleProduct salepro = new SaleProduct();
            salepro.no = no;
            salepro.cnname = cnname;
            salepro.enname = enname;
            salepro.casno = casno;
            salepro.invotory =int.Parse(invotory);
            salepro.stand = stand;
            salepro.purity = purity;
            salepro.cataId = cataId;
            salepro.breadid = int.Parse(breadid);
            salepro.price = price;
            salepro.Id = Id;
            if (Id == 0)
            {
                jodata.code = pbll.AddSaleProduct(salepro);

            }
            else {
                jodata.code = pbll.UpdateSaleProduct(salepro);

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

        public ActionResult delproduct(string strid)
        {
            JsonData jodata = new JsonData();
            string[] arids = strid.Split(',');//定长 
            for (int i = 0; i < arids.Count(); i++)
            {
                int id = int.Parse(arids[i]);
                jodata.code = pbll.DelSaleProduct(id);
            }
            return Json(jodata);
        }



        protected int GetRequest(string strName, int nDefault)
        {
            if (!string.IsNullOrEmpty(this.Request.Form[strName]))
                return int.Parse(this.Request.Form[strName].ToString());
            if (!string.IsNullOrEmpty(this.Request.QueryString[strName]))
                return int.Parse(this.Request.QueryString[strName].ToString());
            return nDefault;
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
