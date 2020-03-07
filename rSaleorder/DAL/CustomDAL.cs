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
   public class CustomDAL
    {
        MySaleOrderEntities db = new MySaleOrderEntities();
        public JsonData GetCustom(string paramList, int page, int limit)
        {
            JsonData jdata = new JsonData();
            var query = db.SaleCustom.Where(t => t.status == (int)NormalEnum.EnumStatus.Availabilit).AsQueryable();

            Hashtable htParams = ComFun.StrToHasTable(paramList);

            if (htParams.Contains("customerno"))
            {
                string customerno = htParams["customerno"].ToString();
                query = query.Where(t => t.name.Contains(customerno));
            }
     
        var customlist = from a in query
                             join b in db.Users on a.adduser equals b.Id
                             join c in db.Users on a.saleuser equals c.Id
                             select new
                             {
                                 a.Id,
                                 a.name,
                                 a.sex,
                                 a.adddate,
                                 a.updatedate,
                                 a.adduser,
                                 a.saleuser,
                                 a.phone,
                                 a.email,
                                 a.address,
                                 a.status,
                                 a.ico,
                                 addusername=b.name,
                                 saleusername=c.name
                             };

            jdata.count = customlist.Count();
            jdata.data = customlist.OrderBy(t => t.Id).Skip((page - 1) * limit).Take(limit).ToList();
            return jdata;
        }

        /// <summary>
        /// 添加产品
        /// </summary>
        /// <param name="sale"></param>
        /// <returns></returns>
        public int AddSaleCustom(SaleCustom salecustom)
        {

            int r = 0;
            salecustom.adddate = DateTime.Now;
            salecustom.updatedate = DateTime.Now;
            salecustom.status = 1;
            db.SaleCustom.Add(salecustom);
            r = db.SaveChanges();
            return r;

        }
        public int UpdateSaleCustom(SaleCustom salecustom)
        {

            int r = 0;
            var pro = db.SaleCustom.Where(t => t.Id == salecustom.Id && t.status == (int)NormalEnum.EnumStatus.Availabilit).FirstOrDefault();
            pro.name = salecustom.name;
            pro.sex = salecustom.sex;
            pro.updatedate = DateTime.Now;
            pro.adduser = salecustom.adduser;
            //pro.saleuser = salecustom.stand;
            pro.phone = salecustom.phone;
            pro.email = salecustom.email;
            pro.address = salecustom.address;
            pro.status = (int)NormalEnum.EnumStatus.Availabilit;
            r = db.SaveChanges();
            return r;

        }
        public int DelSaleCustom(int id)
        {
            int r = 0;
            var salecustom = db.SaleCustom.Where(t => t.Id == id).FirstOrDefault();
            salecustom.status = (int)NormalEnum.EnumStatus.HaveDeleted;
            r = db.SaveChanges();
            return r;
        }


    }
}
