using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class CatalogController : Controller
    {
        CatalogBLL bbll = new CatalogBLL();

        // GET: Catalog
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CatalogView()
        {
            return View();
        }
        public ActionResult GetCatalogList(int page=1, int limit=10,string cataname="")
        {
            JsonData jodata = new JsonData();
            jodata = bbll.GetSaleCatalog(page,limit,cataname);
            return Json(jodata, JsonRequestBehavior.AllowGet);
        }

        public ActionResult delCatalog(string strid)
        {
            JsonData jodata = new JsonData();
            string[] arids = strid.Split(',');//定长 
            for (int i = 0; i < arids.Count(); i++)
            {
                int id = int.Parse(arids[i]);
                jodata.code = bbll.DelSaleCatalog(id);
            }
            return Json(jodata);
        }

        public ActionResult addcatalog(int sort, string cataname, int Id = 0)
        {
            //var aadd = GetRequest("sales","");
            JsonData jodata = new JsonData();
            SaleCatalog salecatalog = new SaleCatalog();
            salecatalog.sort = sort;
            salecatalog.cataname = cataname;
            salecatalog.Id = Id;
            var oldcata = bbll.GetCatalogByname(cataname);

            if (Id == 0)
            {
                if (oldcata == null)
                {
                    jodata.code = bbll.AddCatalog(salecatalog);
                }
                else
                {
                    jodata.msg = "已存在该分类名称！";
                }
            }
            else
            {
                if (oldcata != null)
                {
                    if (oldcata.Id == Id)
                    {
                        jodata.code = bbll.UpdateProCatalog(salecatalog);
                    }
                    else
                    {
                        jodata.msg = "已存在该分类名称！";
                    }
                }
                else
                {
                    jodata.code = bbll.UpdateProCatalog(salecatalog);
                }

            }
            if (jodata.code == 1)
            {
                jodata.msg = "添加成功！";
            }
            else
            {
                jodata.msg = jodata.msg + "添加失败！";
            }
            return Json(jodata);
        }


    }
}