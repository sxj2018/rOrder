using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
    public class UsersBLL
    {
        UsersDAL udal = new UsersDAL();
        public Users GetUserLongin(string account, string pwd)
        {
            return udal.GetUserLongin(account, pwd);

        }
        public Users GetUserBycaount(string account)
        {            
            return udal.GetUserBycaount(account);
        }
        public int IndserUser(Users users)
        {
            return udal.IndserUser(users);
        }

        public int DelUser(int id)
        {
            return udal.DelUser(id);
        }

        public JsonData GetUsers(int page, int limit, string paramList)
        {
            var users = udal.GetUsers(page,limit,paramList);
            return users;

        }

        public int UpdateUser(Users users)
        {
            return udal.UpdateUser(users);
        }

    }
}
