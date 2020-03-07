using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Utils;

namespace DAL
{
    public class ProductDAL
    {
        MySaleOrderEntities db = new MySaleOrderEntities();

        /// <summary>
        /// 获取产品信息
        /// </summary>
        /// <returns></returns>
        public JsonData GetSaleProdut(string paramList, int page, int limit)
        {
            JsonData jdata = new JsonData();
            Hashtable htParams = ComFun.StrToHasTable(paramList);
            var product = db.SaleProduct.Where(t => t.status == (int)NormalEnum.EnumStatus.Availabilit).AsQueryable();
            if (htParams.Contains("namereload"))
            {
                string valuename= htParams["namereload"].ToString();
                if (!string.IsNullOrEmpty(valuename))
                {
                    product = product.Where(t => t.cnname.Contains(valuename));

                }
            }
            if (htParams.Contains("casno"))
            {
                string valuename = htParams["casno"].ToString();
                if (!string.IsNullOrEmpty(valuename))
                { 
                    product = product.Where(t => t.casno == valuename);
                }

            }
            if (htParams.Contains("casno"))
            {
                string valuename = htParams["prono"].ToString();
                if (!string.IsNullOrEmpty(valuename))
                {
                    product = product.Where(t => t.no == valuename);
                }

            }
            var prolist = from a in product
                          join b in db.SaleBrands on a.breadid equals b.Id
                          join cata in db.SaleCatalog on a.cataId equals cata.Id
                          select new
                          {
                              a.Id,
                              a.no,
                              a.cnname,
                              a.enname,
                              a.casno,
                              a.invotory,
                              a.price,
                              a.stand,
                              a.purity,
                              a.adddate,
                              a.uptimedate,
                              a.cataId,
                              a.breadid,
                              brandname = b.brandname,
                              cataname = cata.cataname
                          };
            jdata.count = prolist.Count();
            jdata.data = prolist.OrderBy(t=>t.Id).Skip((page - 1)*limit).Take(limit).ToList();
            return jdata;
        }
        /// <summary>
        /// 添加产品
        /// </summary>
        /// <param name="sale"></param>
        /// <returns></returns>
        public int AddSaleProduct(SaleProduct salepro)
        {

            int r = 0;
            salepro.adddate = DateTime.Now;
            salepro.uptimedate = DateTime.Now;
            salepro.status = 1;
            db.SaleProduct.Add(salepro);
            r = db.SaveChanges();
            return r;

        }
        public int UpdateSaleProduct(SaleProduct saleproduct)
        {

            int r = 0;
            var pro = db.SaleProduct.Where(t => t.Id == saleproduct.Id&&t.status== (int)NormalEnum.EnumStatus.Availabilit).FirstOrDefault();
            pro.no = saleproduct.no;
            pro.cnname = saleproduct.cnname;
            pro.enname = saleproduct.enname;
            pro.casno = saleproduct.casno;
            pro.invotory = saleproduct.invotory;
            pro.stand = saleproduct.stand;
            pro.purity = saleproduct.purity;
            pro.cataId = saleproduct.cataId;
            pro.breadid = saleproduct.breadid;
            pro.uptimedate = DateTime.Now;
            r = db.SaveChanges();
            return r;

        }


        public int DelSaleProduct(int id)
        {
            int r = 0;
            var product = db.SaleProduct.Where(t => t.Id == id).FirstOrDefault();
            product.status = (int)NormalEnum.EnumStatus.HaveDeleted;
            r = db.SaveChanges();
            return r;
        }
    }
}
