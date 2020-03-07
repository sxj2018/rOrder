using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
    public class BrandBLL
    {
        BrandDAL bdal = new BrandDAL();
        public JsonData GetSaleBrands(int page, int limit, string brandname = "")
        {
            var salbread = bdal.GetSaleBrands(page, limit, brandname);
            return salbread;

        }

        public SaleBrands GetBrandgByname(string name)
        {

            return bdal.GetBrandgByname(name);
        }
        /// <summary>
        /// 根据Id 获取分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SaleBrands GetBrandById(int id)
        {
            return bdal.GetBrandById(id);
        }


        public int DelSaleBand(int id)
        {
            return bdal.DelSaleBand(id);
        }

        public int AddBrand(SaleBrands brad)
        {
            return bdal.AddBrand(brad);

        }

        public int UpdateBrand(SaleBrands salebrand)
        {

            return bdal.UpdateBrand(salebrand);
        }

    }
}
