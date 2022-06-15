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
    public class LeaveEmpsController : Controller
    {
        private PayEntities1 db = new PayEntities1();

        // GET: LeaveEmps
        public ActionResult Index()
        {
            var leaveEmps = db.LeaveEmps.Include(l => l.Employee);
            return View(leaveEmps.ToList());
        }
        public ActionResult Index1()
        {
            var leaveEmps = db.LeaveEmps.Include(l => l.Employee);
            return View(leaveEmps.ToList());
        }
        public ActionResult LeaveIndex(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(db.LeaveEmps.Where(x => x.User_id == id).ToList());
        }
        public ActionResult LeaveIndex1(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(db.LeaveEmps.Where(x => x.User_id == id).ToList());
        }
        public ActionResult LeaveIndex2(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(db.LeaveEmps.Where(x => x.User_id == id).ToList());
        }
        // GET: LeaveEmps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
           
            return View(db.LeaveEmps.Where(x => x.User_id == id).FirstOrDefault());
        }

        // GET: LeaveEmps/Create
        public ActionResult Create()
        {
            ViewBag.User_id = new SelectList(db.Employees, "User_id", "User_Name");
            return View();
        }

        // POST: LeaveEmps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,User_id,StartLeave,Enddate,Numoffdays,Reason,Applydate,Leavedate,Approved")] LeaveEmp leaveEmp)
        {
            if (ModelState.IsValid)
            {
                db.LeaveEmps.Add(leaveEmp);
                db.SaveChanges();
                return RedirectToAction("LeaveIndex1", new {id=leaveEmp.User_id});
            }

            ViewBag.User_id = new SelectList(db.Employees, "User_id", "User_Name", leaveEmp.User_id);
            return View(leaveEmp);
        }

        // GET: LeaveEmps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveEmp leaveEmp = db.LeaveEmps.Find(id);
            if (leaveEmp == null)
            {
                return HttpNotFound();
            }
            ViewBag.User_id = new SelectList(db.Employees, "User_id", "User_Name", leaveEmp.User_id);
            return View(leaveEmp);
        }

        // POST: LeaveEmps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,User_id,StartLeave,Enddate,Numoffdays,Reason,Applydate,Leavedate,Approved")] LeaveEmp leaveEmp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leaveEmp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("LeaveIndex", new {id=leaveEmp.User_id});
            }
            ViewBag.User_id = new SelectList(db.Employees, "User_id", "User_Name", leaveEmp.User_id);
            return View(leaveEmp);
        }

        // GET: LeaveEmps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveEmp leaveEmp = db.LeaveEmps.Find(id);
            if (leaveEmp == null)
            {
                return HttpNotFound();
            }
            return View(leaveEmp);
        }

        // POST: LeaveEmps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LeaveEmp leaveEmp = db.LeaveEmps.Find(id);
            db.LeaveEmps.Remove(leaveEmp);
            db.SaveChanges();
            return RedirectToAction("Index1");
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
