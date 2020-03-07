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
    public class SaleOrderDAL
    {

        MySaleOrderEntities db = new MySaleOrderEntities();

        public JsonData GetSaleOrder(string paramList, int page, int limit)
        {

            JsonData jdata = new JsonData();
            Hashtable htParams = ComFun.StrToHasTable(paramList);
            var qurys = db.SaleOrder.Where(t => t.status == (int)NormalEnum.EnumStatus.Availabilit).AsQueryable();
            if (htParams.Contains("orderno"))
            {
                string valuename = htParams["orderno"].ToString();
                qurys = qurys.Where(t => t.orderno.Contains(valuename));

            }        
        var saleorderlist = from a in qurys
                                join b in db.SaleCustom on a.customid equals b.Id
                                join slpro in db.SaleOrderProlist on a.Id equals slpro.saleorderid
                                join pro in db.SaleProduct on slpro.productid equals pro.Id
                                join au in db.Users on a.adduser equals au.Id into tempadduser
                                from auu in tempadduser.DefaultIfEmpty()
                                join seleu in db.Users on a.adduser equals seleu.Id into tempseleuser
                                from seleuu in tempseleuser.DefaultIfEmpty()
                                join autu in db.Users on a.adduser equals autu.Id into tempaudituser
                                from autuu in tempaudituser.DefaultIfEmpty()

                                select new
                                {
                                    a.Id,
                                    a.orderno,
                                    a.orderdate,
                                    a.adddate,
                                    a.uptimedate,
                                    a.customid,
                                    a.executionstatus,
                                    a.auditstatus,
                                    a.adduser,
                                    a.saleuser,
                                    a.audituser,
                                    a.auditdate,
                                    //a.amount,
                                    a.status,
                                    customname=b.name,
                                    addname =auu.name,
                                    selename = seleuu.name,
                                    auitname = autuu.name,
                                    amount = slpro.amount,//订单上的产品数量
                                    prono=pro.no,
                                    proname = pro.cnname,
                                    prcasno = pro.casno,
                                    prostand = pro.stand,




                                };

            jdata.count = saleorderlist.Count();
            jdata.data = saleorderlist.OrderBy(t => t.Id).Skip((page - 1) * limit).Take(limit).ToList();
            return jdata;

        }

        public string GetOrderNewNo()
        {
            var nowdate = DateTime.Now.ToString("yyyyMMdd");
            var fiex = "XSD-" + nowdate+"-";
            var orders = db.SaleOrder.Where(t => t.orderno.StartsWith(fiex)).Select(t => t.orderno).ToList();
            var list = (from q in db.SaleOrder
                        where q.orderno.StartsWith(fiex)
                        select new
                        {
                            MaxNo = q.orderno.Substring(fiex.Length)
                        }).ToList();

            string maxno = list.Max(p => p.MaxNo);
            var newno = "";
            int nmax = 1;
            if (string.IsNullOrWhiteSpace(maxno))
            {
                newno = string.Format("{0}{1}", fiex, nmax.ToString().PadLeft(4, '0'));
            }
            else
            {
                int.TryParse(maxno, out nmax);
                nmax++;
                newno = string.Format("{0}{1}", fiex, nmax.ToString().PadLeft(4, '0'));
            }
            return newno;
        }

        /// <summary>
        /// 添加产品
        /// </summary>
        /// <param name="sale"></param>
        /// <returns></returns>
        public int AddSaleOrder(SaleOrder saleorder)
        {

            int r = 0;
            saleorder.adddate = DateTime.Now;
            saleorder.uptimedate = DateTime.Now;
            saleorder.orderdate = DateTime.Now;
            saleorder.auditdate = DateTime.Now;
            saleorder.executionstatus = (int)NormalEnum.EnumOutIoStatus.Notout;
            saleorder.auditstatus = (int)NormalEnum.EnumAuitStatus.NotAuit;
            saleorder.status = (int)NormalEnum.EnumStatus.Availabilit;
            db.SaleOrder.Add(saleorder);
         
            r = db.SaveChanges();
            return r;

        }
        public int UpdateSaleOrder(SaleOrder saleorder)
        {
        int r = 0;
            var saleorderold = db.SaleOrder.Where(t => t.Id == saleorder.Id && t.status == (int)NormalEnum.EnumStatus.Availabilit).FirstOrDefault();
            saleorderold.orderno = saleorder.orderno;
            saleorderold.customid = saleorder.customid;
            saleorderold.executionstatus = saleorder.executionstatus;
            saleorderold.saleuser = saleorder.saleuser;
            saleorderold.uptimedate = DateTime.Now;
            saleorderold.amount = saleorder.amount;
            r = db.SaveChanges();
            return r;

        }


        public int DelSaleOrder(int id)
        {
            int r = 0;
            var saleorder = db.SaleOrder.Where(t => t.Id == id).FirstOrDefault();
            saleorder.status = (int)NormalEnum.EnumStatus.HaveDeleted;
            r = db.SaveChanges();
            return r;
        }
        /// <summary>
        /// 审核，撤销审核 type=1待审核，type=2审核通过
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int AuduitSaleOrder(int id,int type)
        {
            int r = 0;
            var saleorder = db.SaleOrder.Where(t => t.Id == id).FirstOrDefault();
            saleorder.auditstatus = type;
            r = db.SaveChanges();
            return r;
        }
    }
}
