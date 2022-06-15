using Payroll_Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Payroll_Mvc.Controllers
{
    public class SignupController : Controller
    {
        // GET: Signup
        public ActionResult signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult signup(Employee lg)
        {
            using (PayEntities1 db = new PayEntities1())
            {
                if (ModelState.IsValid)
                {
                    lg.Joined_On = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    db.Employees.Add(lg);
                    var r = db.SaveChanges();
                    if (r > 0)
                    {
                        ViewBag.msg = "Inserted Successfully!";
                        ModelState.Clear();
                    }
                    else
                    {
                        ViewBag.msg = "Failed to Insert";
                    }
                }
                return View();
            }
        }
    }
}