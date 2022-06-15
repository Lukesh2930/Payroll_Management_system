using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Payroll_Mvc;
using Payroll_Mvc.Models;

namespace Payroll_Mvc.Controllers
{
    public class EmployeesController : Controller
    {
        private PayEntities1 db = new PayEntities1();
        private LoginPayroll lg = new LoginPayroll();

        // GET: Employees
        public ActionResult Index()
        {

            return View(db.Employees.ToList());
        }
        
        public ActionResult Display1(int? Id)
        {
            using (PayEntities1 db = new PayEntities1())
            {
                if (Id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                
                return View(db.TimeSheets.Where(x => x.User_id == Id).ToList());
            }

        }
        public ActionResult display(int? Id)
        {
            using (PayEntities1 db = new PayEntities1())
            {
                if (Id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Employee employee = db.Employees.Find(Id);
                if (employee == null)
                {
                    return HttpNotFound();
                }
                return View(employee);
            }

        }
        [HttpGet]
        public ActionResult Work_sheet()
        {
            return View();
        }
        
      
        [HttpPost]
        public ActionResult work_sheet(Worksheet w)
        {
            using (PayEntities1 db = new PayEntities1())
            {
                // db.Worksheet1.Where(x => x.CreatedOn != w.CreatedOn).FirstOrDefault();
                w.CreatedOn = Convert.ToDateTime(DateTime.Now.ToShortDateString());

               
                    db.Worksheets.Add(w);
                    
                    if (db.SaveChanges()> 0)
                    {
                        ViewBag.msg = "Created Successfully";
                    }
                    else
                    {
                        ViewBag.msg = "Failed to Create ";
                    }
            }
            return View();
        }
        // GET: Employees/Create
        /*  public ActionResult Create()
          {
              return View();
          }

          // POST: Employees/Create
          // To protect from overposting attacks, enable the specific properties you want to bind to, for 
          // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Create([Bind(Include = "User_id,User_Name,Age,Email,Password")] Employee employee)
          {
              if (ModelState.IsValid)
              {
                  db.Employees.Add(employee);
                  db.SaveChanges();
                  return RedirectToAction("Index");
              }

              return View(employee);
          } */

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
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
        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "User_id,User_Name,Joined_On,Age,Email,Password")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("display", new {id=employee.User_id});
            }
            return View(employee);
        }
        public ActionResult update(int? id)
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
        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult update([Bind(Include = "User_id,joined_on,User_Name,Age,Email,Password")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("LoginEmp","Login");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        /*   public ActionResult Delete(int? id)
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
               db.Employees.Remove(employee);
               db.SaveChanges();
               return RedirectToAction("Index");
           }*/

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
