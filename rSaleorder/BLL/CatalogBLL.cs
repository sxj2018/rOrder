using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
    public class CatalogBLL
    {
        CatalogDAL bdal = new CatalogDAL();
        public JsonData GetSaleCatalog(int page, int limit, string cataname = "")
        {
            var salbread = bdal.GetProCatalogs(page,limit,cataname);
            return salbread;

        }
        public int AddCatalog(SaleCatalog saleca)
        {
            return bdal.AddProCatalog(saleca);
        }
        public int DelSaleCatalog(int id)
        {
            return bdal.DelSaleCatalog(id);
        }

        public int UpdateProCatalog(SaleCatalog salecat)
        {
            return bdal.UpdateProCatalog(salecat);

        }
        public SaleCatalog GetCatalogById(int id)
        {            
            return bdal.GetCatalogById(id);
        }
        public SaleCatalog GetCatalogByname(string name)
        {
            return bdal.GetCatalogByname(name);
        }

    }
}
