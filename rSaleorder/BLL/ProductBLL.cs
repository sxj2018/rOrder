using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
    public class ProductBLL
    {
        ProductDAL pdal = new ProductDAL();
        public JsonData GetSaleProdut(string paramList,int page,int limit)
        {

            JsonData salepro = pdal.GetSaleProdut(paramList, page, limit);
            return salepro;

        }
        public int AddSaleProduct(SaleProduct salepro)
        {
            return pdal.AddSaleProduct(salepro);
        }
        public int DelSaleProduct(int id)
        {
            return pdal.DelSaleProduct(id);
        }
        public int UpdateSaleProduct(SaleProduct saleproduct)
        {

            return pdal.UpdateSaleProduct(saleproduct);

        }



    }
}
