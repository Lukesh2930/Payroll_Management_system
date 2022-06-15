using Payroll_Mvc.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Payroll_Mvc.Controllers
{
    public class AdministratorsController : Controller
    {
        // GET: Administrators
        private PayEntities1 db = new PayEntities1();

        // GET: Employees
        public ActionResult Index()
        {

            return View(db.Employees.ToList());
        }
       public ActionResult Time_sheet()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Time_Sheet(TimeSheet t)
        {
            using (PayEntities1 db = new PayEntities1())
            {
                db.TimeSheets.Add(t);
                if (db.SaveChanges() > 0)
                {
                    ViewBag.msg = "Inserted Successfully!";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.msg = "Not Inserted";
                }

            }
            return View();
        }
        public ActionResult display(int? Id)
        {
            using (PayEntities1 db = new PayEntities1())
            {
                if (Id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                return View(db.Worksheets.Where(x=>x.User_id==Id).ToList());
            }

        }
        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
           {
               if (id == null)
               {
                   return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
               }
               Employee employee = db.Employees.Find(id);
               if (employee == null)
               {
                   return HttpNotFound();
               }
               return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
          
                Employee employee = db.Employees.Find(id);
                
                if (employee != null)
                {
                    db.Employees.Remove(employee);
                    if (db.SaveChanges() > 0)
                    {
                        ViewBag.msg = "Deleted Successfully";
                    }
                    else
                    {
                        ViewBag.msg = "error";
                    }
                }
                return View();
            }
        }
}