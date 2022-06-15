using Payroll_Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Payroll_Mvc.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        static public int id;
        public ActionResult Index()
        {
            return View();  
        }
        public ActionResult LoginEmp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginEmp(LoginPayroll lg)
        {
            using (PayEntities1 db = new PayEntities1())
            {
                id = lg.UserId;
                var users = db.Employees.Where(x => x.User_id == lg.UserId && x.User_Name == lg.UserName && x.Password == lg.Password).ToList();
                if (users.Count > 0)
                {
                    Session["UserId"] = users[0].User_id;
                    Session["UserName"] = users[0].User_Name; 
                    return RedirectToAction("display","Employees", new { id =lg.UserId});
                   // return RedirectToAction("Index", "Employees");
                }
                {
                    ViewBag.msg = "Incorrest userid/password";
                  //  TempData["msg"] = "Incorrest userid/password";
                }
            }
            return View();
        }
        public ActionResult Redirect(Employee l)
        {

            return RedirectToAction("display", "Employees", new { id = id }); ;
        }
        public ActionResult LoginAdm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginAdm(LoginPayroll lg)
        {
            using (PayEntities1 db = new PayEntities1())
            {
                var users = db.Administrators.Where(x => x.User_id == lg.UserId && x.User_Name == lg.UserName && x.Password == lg.Password).ToList();
                if (users.Count > 0)
                {
                    Session["UserId"] = users[0].User_id;
                    Session["UserName"] = users[0].User_Name;
                    return RedirectToAction("Index", "Administrators");
                }
                else
                {
                    ViewBag.msg = "Incorrest userid/password";
                   // TempData["msg"] = "Incorrest userid/password";
                }
            }
            return View();
        }

        public ActionResult Forgot()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Forgot(ForgotPasswordLg lg)
        {
            using (PayEntities1 db = new PayEntities1())
            {
                var users = db.Employees.Where(x => x.User_id == lg.UserId && x.User_Name == lg.UserName).ToList();
                if (users.Count > 0)
                {
                    Session["UserId"] = users[0].User_id;
                    Session["UserName"] = users[0].User_Name;
                    return RedirectToAction("update", "Employees", new {id=lg.UserId});
                }
                {
                    ViewBag.msg = "Incorrest userid/password";
                    //TempData["msg"] = "Incorrest userid/password";
                }
            }
            return View();
        }
        public ActionResult logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "login");
        }
    }
}