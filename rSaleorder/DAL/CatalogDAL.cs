using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class CatalogDAL
    {
        MySaleOrderEntities db = new MySaleOrderEntities();

        /// <summary>
        /// 获取分类信息
        /// </summary>
        /// <returns></returns>
        public JsonData GetProCatalogs(int page, int limit, string cataname = "")
        {
            JsonData jdata = new JsonData();
            var procatalogs = db.SaleCatalog.Where(t => t.status == (int)NormalEnum.EnumStatus.Availabilit);
            if (!string.IsNullOrEmpty(cataname))
            {
                procatalogs = procatalogs.Where(t => t.cataname.Contains(cataname));
            }
            jdata.count = procatalogs.Count();
            jdata.data = procatalogs.OrderBy(t => t.Id).Skip((page - 1) * limit).Take(limit).ToList();
            return jdata;

        }
        /// <summary>
        /// 添加分类
        /// </summary>
        /// <param name="sale"></param>
        /// <returns></returns>
        public int AddProCatalog(SaleCatalog salecat)
        {

            int r = 0;           
            salecat.status = 1;
            db.SaleCatalog.Add(salecat);
            r = db.SaveChanges();
            return r;

        }
        public SaleCatalog GetCatalogByname(string name)
        {

            var cata = db.SaleCatalog.Where(t => t.cataname == name && t.status == (int)NormalEnum.EnumStatus.Availabilit).FirstOrDefault();
            return cata;
        }
        /// <summary>
        /// 根据Id 获取分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SaleCatalog GetCatalogById(int id)
        {

            var cata = db.SaleCatalog.Where(t => t.Id == id && t.status == (int)NormalEnum.EnumStatus.Availabilit).FirstOrDefault();
            return cata;
        }

        public int DelSaleCatalog(int id)
        {
            int r = 0;
            var brand = db.SaleCatalog.Where(t => t.Id == id).FirstOrDefault();
            brand.status = 2;
            r = db.SaveChanges();
            return r;
        }
        public int UpdateProCatalog(SaleCatalog salecat)
        {

            int r = 0;
            var cata = db.SaleCatalog.Where(t => t.Id == salecat.Id).FirstOrDefault();
            cata.cataname = salecat.cataname;
            cata.sort = salecat.sort;
            r = db.SaveChanges();
            return r;

        }

    }
}
