using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
   public class CustomBLL
    {
        CustomDAL cus = new CustomDAL();
        public JsonData GetCustom(string paramList, int page, int limit)
        {

            JsonData customer = cus.GetCustom(paramList, page,limit);
            return customer;

        }

        /// <summary>
        /// 添加产品
        /// </summary>
        /// <param name="sale"></param>
        /// <returns></returns>
        public int AddSaleCustom(SaleCustom salecustom)
        {

            return cus.AddSaleCustom(salecustom);
        }
        /// <summary>
        /// 编辑产品
        /// </summary>
        /// <param name="salecustom"></param>
        /// <returns></returns>
        public int UpdateSaleCustom(SaleCustom salecustom)
        {
            return cus.UpdateSaleCustom(salecustom);
        }

        public int DelSaleCustom(int id)
        {
            return cus.DelSaleCustom(id);
        }

    }
}
