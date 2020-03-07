using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        UsersBLL ubll = new UsersBLL();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult fistView()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult HelpView()
        {
            return View();
        }
        
        public ActionResult GetLogin(string username, string pwd)
        {
            JObject jo = new JObject();
            Users us = ubll.GetUserLongin(username, pwd);
            if (us != null)
            {
                Session["usrName"] = us.name;
                Session["usrZhiwei"] = us.zhiwei;
                var strus = JsonConvert.SerializeObject(us);
                Session["userInfo"] = strus;
                Session["userid"] = us.Id;
                Session["userrolulevel"] = us.rolulevel;

                jo["result"] = 1;
            }
            else {
              
                jo["result"] = 0;
            }
            return Json(jo.ToString());

        }

        public ActionResult regView()
        {
            return View();
        }

        public ActionResult InserUser(Users users)
        {
            JObject jo = new JObject();
            Users uold = ubll.GetUserBycaount(users.account);
            if (uold == null)
            {
                int r = ubll.IndserUser(users);
                if (r>0)
                {
                    Session["usrName"] = users.name;
                    Session["usrZhiwei"] = users.zhiwei;
                    Session["userid"] = users.Id;    
                    Session["userrolulevel"] = users.rolulevel;

                    jo["result"] = r;
                    jo["messge"] = "注册成功！";
                }
            }
            else {
                jo["result"] = -1;
                jo["messge"] = "该用户名已经存在!";
            }          
            return Json(jo.ToString());

        }
        public ActionResult Exit()
        {
            JObject jo = new JObject();
            Session["usrName"] = null;
            Session["usrZhiwei"] = null;
            return View("Login");

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}