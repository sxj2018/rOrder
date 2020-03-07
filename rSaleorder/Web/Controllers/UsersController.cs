using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        UsersBLL users = new UsersBLL();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UsersView()
        {
            return View();
        }
        public ActionResult GetUsersList(string paramList, int page=1, int limit=10)
        {
            JsonData jodata = new JsonData();
            jodata = users.GetUsers(page, limit, paramList);
            return Json(jodata, JsonRequestBehavior.AllowGet);

        }
        public ActionResult adduser(int Id=0,string account = "", string tel = "", string email = "", string password = "", string name = "", string portraitico = "", string sex = "", int age = 0, string zhiwei = "")
        {
            //var aadd = GetRequest("sales","");
            JsonData jodata = new JsonData();
            Users user = new Users();
            //user.roleid = roleid;
            user.account = account;
            user.tel = tel;
            user.email = email;
            user.password = password;
            user.name = name;
            user.portraitico = portraitico;
            user.sex = sex;
            user.age = age;
            user.zhiwei = zhiwei;
            user.Id = Id;
            if (Id == 0)
            {
                jodata.code = users.IndserUser(user);

            }
            else {
                jodata.code = users.UpdateUser(user);

            }
            if (jodata.code == 1)
            {
                jodata.msg = "添加成功！";
            }
            else
            {
                jodata.msg = "添加失败！";
            }
            return Json(jodata);
        }
        public ActionResult DelUsers(string strid)
        {
            JsonData jodata = new JsonData();
            string[] arids = strid.Split(',');//定长 
            for (int i = 0; i < arids.Count(); i++)
            {
                int id = int.Parse(arids[i]);
                jodata.code = users.DelUser(id);
            }
            return Json(jodata);
        }


    }
}