using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;

namespace Web.Controllers
{
    public class BrandController : Controller
    {
        BrandBLL bbll = new BrandBLL();
        // GET: Brand
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BrandView()
        {
            return View();
        }
        public ActionResult GetBranList(int page=1, int limit=10, string brandname = "")
        {
            JsonData jodata = new JsonData();
            jodata = bbll.GetSaleBrands(page, limit, brandname);
            return Json(jodata, JsonRequestBehavior.AllowGet);

        }

        public ActionResult addBrad(string brandname, string sort, int Id = 0)
        {
            //var aadd = GetRequest("sales","");
            JsonData jodata = new JsonData();
            SaleBrands brand = new SaleBrands();
            brand.brandname = brandname;
            brand.sort = 1;
            brand.Id = Id;
            var oldbrand = bbll.GetBrandgByname(brandname);

            if (Id == 0)
            {
                if (oldbrand == null)
                {
                    jodata.code = bbll.AddBrand(brand);
                }
                else
                {
                    jodata.msg = "该品牌名称已经存在不能重复添加！";

                }
            }
            else
            {
                if (oldbrand != null)
                {
                    if (oldbrand.Id == Id)
                    {
                        jodata.code = bbll.UpdateBrand(brand);
                    }
                    else
                    {
                        jodata.msg = "该品牌名称已经存在不能重复添加！";
                    }
                }
                else
                {
                    jodata.code = bbll.UpdateBrand(brand);
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

        public ActionResult deldBrad(string strid)
        {
            JsonData jodata = new JsonData();
            string[] arids = strid.Split(',');//定长 
            for (int i = 0; i < arids.Count(); i++)
            {
                int id = int.Parse(arids[i]);
                jodata.code = bbll.DelSaleBand(id);
            }
            return Json(jodata);
        }

    }
}