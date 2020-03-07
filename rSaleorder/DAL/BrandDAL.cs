using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class BrandDAL
    {

        MySaleOrderEntities db = new MySaleOrderEntities();

        /// <summary>
        /// 获取产品信息
        /// </summary>
        /// <returns></returns>
        public JsonData GetSaleBrands(int page, int limit, string brandname = "")
        {
            JsonData jdata = new JsonData();
            var probrand = db.SaleBrands.Where(t => t.status == (int)NormalEnum.EnumStatus.Availabilit);
            if (!string.IsNullOrEmpty(brandname))
            {
                probrand = probrand.Where(t => t.brandname.Contains(brandname));
            }
            jdata.count = probrand.Count();
            jdata.data = probrand.OrderBy(t => t.Id).Skip((page - 1) * limit).Take(limit).ToList();
            return jdata;

        }
        public int DelSaleBand(int id)
        {
            int r = 0;
            var brand = db.SaleBrands.Where(t => t.Id == id).FirstOrDefault();
            brand.status = 2;
            r = db.SaveChanges();
            return r;
        }
        public int AddBrand(SaleBrands brad)
        {
            int r = 0;
            brad.status = 1;
            db.SaleBrands.Add(brad);
            r = db.SaveChanges();
            return r;

        }

        public SaleBrands GetBrandgByname(string name)
        {

            var brand = db.SaleBrands.Where(t => t.brandname == name && t.status == (int)NormalEnum.EnumStatus.Availabilit).FirstOrDefault();
            return brand;
        }
        /// <summary>
        /// 根据Id 获取分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SaleBrands GetBrandById(int id)
        {

            var brand = db.SaleBrands.Where(t => t.Id == id && t.status == (int)NormalEnum.EnumStatus.Availabilit).FirstOrDefault();
            return brand;
        }

        public int UpdateBrand(SaleBrands salebrand)
        {

            int r = 0;
            var brand = db.SaleBrands.Where(t => t.Id == salebrand.Id).FirstOrDefault();
            brand.brandname = salebrand.brandname;
            brand.sort = salebrand.sort;
            r = db.SaveChanges();
            return r;
        }


    }
}
