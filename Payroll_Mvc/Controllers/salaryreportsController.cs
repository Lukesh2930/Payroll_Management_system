using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Payroll_Mvc;

namespace Payroll_Mvc.Controllers
{
    public class salaryreportsController : Controller
    {
        private PayEntities1 db = new PayEntities1();
  

        // GET: salaryreports
        public ActionResult Index()
        {
            var salaryreports = db.salaryreports.Include(s => s.Employee);
            return View(salaryreports.ToList());
        }

        // GET: salaryreports/Details/5
        public ActionResult SalaryView(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
       
            return View(db.salaryreports.Where(x => x.User_id == id).ToList());
        }
        public ActionResult SalaryView1(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(db.salaryreports.Where(x => x.User_id == id).ToList());
        }

        // GET: salaryreports/Create
        public ActionResult Create()
        {
            ViewBag.User_id = new SelectList(db.Employees, "User_id", "User_Name");
            return View();
        }

        // POST: salaryreports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "User_id,User_Name,Age,Email,Month,Salary,PfAmount,Esi,ProffessionalTax,Total")] salaryreport salaryreport)
        {
            if (ModelState.IsValid)
            {
                db.salaryreports.Add(salaryreport);
                db.SaveChanges();
                return RedirectToAction("SalaryView", new {id=salaryreport.User_id});
            }

            ViewBag.User_id = new SelectList(db.Employees, "User_id", "User_Name", salaryreport.User_id);
            return View(salaryreport);
        }

        // GET: salaryreports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            salaryreport salaryreport = db.salaryreports.Find(id);
            if (salaryreport == null)
            {
                return HttpNotFound();
            }
            ViewBag.User_id = new SelectList(db.Employees, "User_id", "User_Name", salaryreport.User_id);
            return View(salaryreport);
        }

        // POST: salaryreports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "User_id,User_Name,Age,Email,Month,Salary,PfAmount,Esi,ProffessionalTax,Total")] salaryreport salaryreport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salaryreport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("SalaryView", new { id = salaryreport.User_id });
            }
            ViewBag.User_id = new SelectList(db.Employees, "User_id", "User_Name", salaryreport.User_id);
            return View(salaryreport);
        }

        // GET: salaryreports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            salaryreport salaryreport = db.salaryreports.Find(id);
            if (salaryreport == null)
            {
                return HttpNotFound();
            }
            return View(salaryreport);
        }

        // POST: salaryreports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            salaryreport salaryreport = db.salaryreports.Find(id);
            db.salaryreports.Remove(salaryreport);
            db.SaveChanges();
            return RedirectToAction("SalaryView1", new { id = salaryreport.User_id });
        }

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
