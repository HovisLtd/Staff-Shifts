using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StaffShifts.Models;

namespace StaffShifts.Controllers
{
    public class UserSitesController : Controller
    {
        private Entities db = new Entities();

        // GET: UserSites
        public ActionResult Index()
        {
            var t_PTLStaff_Master_UserSites = db.t_PTLStaff_Master_UserSites.Include(t => t.v_PTLStaff_MasterData_Plants);
            return View(t_PTLStaff_Master_UserSites.ToList());
        }

        // GET: UserSites/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_PTLStaff_Master_UserSites t_PTLStaff_Master_UserSites = db.t_PTLStaff_Master_UserSites.Find(id);
            if (t_PTLStaff_Master_UserSites == null)
            {
                return HttpNotFound();
            }
            return View(t_PTLStaff_Master_UserSites);
        }

        // GET: UserSites/Create
        public ActionResult Create()
        {
            ViewBag.UserSiteCode = new SelectList(db.v_PTLStaff_MasterData_Plants, "Plant", "PlantDesc");
            return View();
        }

        // POST: UserSites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserName,UserSiteCode")] t_PTLStaff_Master_UserSites t_PTLStaff_Master_UserSites)
        {
            if (ModelState.IsValid)
            {
                db.t_PTLStaff_Master_UserSites.Add(t_PTLStaff_Master_UserSites);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserSiteCode = new SelectList(db.v_PTLStaff_MasterData_Plants, "Plant", "PlantDesc", t_PTLStaff_Master_UserSites.UserSiteCode);
            return View(t_PTLStaff_Master_UserSites);
        }

        // GET: UserSites/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_PTLStaff_Master_UserSites t_PTLStaff_Master_UserSites = db.t_PTLStaff_Master_UserSites.Find(id);
            if (t_PTLStaff_Master_UserSites == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserSiteCode = new SelectList(db.v_PTLStaff_MasterData_Plants, "Plant", "PlantDesc", t_PTLStaff_Master_UserSites.UserSiteCode);
            return View(t_PTLStaff_Master_UserSites);
        }

        // POST: UserSites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserName,UserSiteCode")] t_PTLStaff_Master_UserSites t_PTLStaff_Master_UserSites)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_PTLStaff_Master_UserSites).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserSiteCode = new SelectList(db.v_PTLStaff_MasterData_Plants, "Plant", "PlantDesc", t_PTLStaff_Master_UserSites.UserSiteCode);
            return View(t_PTLStaff_Master_UserSites);
        }

        // GET: UserSites/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_PTLStaff_Master_UserSites t_PTLStaff_Master_UserSites = db.t_PTLStaff_Master_UserSites.Find(id);
            if (t_PTLStaff_Master_UserSites == null)
            {
                return HttpNotFound();
            }
            return View(t_PTLStaff_Master_UserSites);
        }

        // POST: UserSites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            t_PTLStaff_Master_UserSites t_PTLStaff_Master_UserSites = db.t_PTLStaff_Master_UserSites.Find(id);
            db.t_PTLStaff_Master_UserSites.Remove(t_PTLStaff_Master_UserSites);
            db.SaveChanges();
            return RedirectToAction("Index");
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
