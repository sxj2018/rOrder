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
    public class UsersDAL
    {
        MySaleOrderEntities db = new MySaleOrderEntities();
        public Users GetUserLongin(string account, string pwd)
        {
            Users us = db.Users.Where(t => t.account == account && t.password == pwd&&t.status== (int)NormalEnum.EnumStatus.Availabilit).FirstOrDefault();
            return us;
        }
        /// <summary>
        /// 根据账户名获取用户信息
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public Users GetUserBycaount(string account)
        {
            Users us = db.Users.Where(t => t.account == account && t.status == (int)NormalEnum.EnumStatus.Availabilit).FirstOrDefault();
            return us;
        }
        public Users GetUserById(int userId)
        {
            Users us = db.Users.Where(t => t.Id == userId && t.status == (int)NormalEnum.EnumStatus.Availabilit).FirstOrDefault();
            return us;
        }

        public int IndserUser(Users users) {
            int r = 0;
            users.adddate = DateTime.Now;
            users.uptdate = DateTime.Now;
            users.status =1;
            users.roleid = 1;
            db.Users.Add(users);
            r = db.SaveChanges();
            return r;
        }
        public int UpdateUser(Users users)
        {
            int r = 0;
            var user = db.Users.Where(t => t.Id == users.Id).FirstOrDefault();
            user.account = users.account;
            user.tel = users.tel;
            user.email = users.email;
            user.portraitico = users.portraitico;
            user.sex = users.sex;
            user.age = users.age;
            user.zhiwei = users.zhiwei;
            r = db.SaveChanges();
            return r;
        }

        public int DelUser(int id)
        {
            int r = 0;
            var users = db.Users.Where(t => t.Id == id).FirstOrDefault();
            users.status = 2;
            r = db.SaveChanges();
            return r;
        }
        public JsonData GetUsers(int page, int limit, string paramList)
        {
            JsonData jdata = new JsonData();
            Hashtable htParams = ComFun.StrToHasTable(paramList);
            var users = db.Users.Where(t => t.status == (int)NormalEnum.EnumStatus.Availabilit).AsQueryable();
            if (htParams.Contains("username"))
            {
                string valuename = htParams["username"].ToString();
                users = users.Where(t => t.name.Contains(valuename));
            }
            jdata.count = users.Count();
            jdata.data = users.OrderBy(t => t.Id).Skip((page - 1) * limit).Take(limit).ToList();
            return jdata;
        }


    }
}
