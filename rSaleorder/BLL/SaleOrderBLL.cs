using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
    public class SaleOrderBLL
    {
        SaleOrderDAL sdal = new SaleOrderDAL();
        public JsonData GetSaleOrder(string paramList, int page, int limit)
        {
            return sdal.GetSaleOrder(paramList, page,limit);

        }
        /// <summary>
        /// 添加产品
        /// </summary>
        /// <param name="sale"></param>
        /// <returns></returns>
        public int AddSaleOrder(SaleOrder saleorder)
        {
            return sdal.AddSaleOrder(saleorder);

        }
        public int UpdateSaleOrder(SaleOrder saleorder)
        {
            return sdal.UpdateSaleOrder(saleorder);

        }


        public int DelSaleOrder(int id)
        {
            return sdal.DelSaleOrder(id);
        }
        public string GetOrderNewNo()
        {
            return sdal.GetOrderNewNo();
        }
        public int AuduitSaleOrder(int id, int type)
        {
            return sdal.AuduitSaleOrder(id,type);
        }

    }
}
