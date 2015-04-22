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
    public class MasterDataCodesv2Controller : Controller
    {
        private Entities db = new Entities();

        // GET: /MasterDataCodesv2/
        public ActionResult Index()
        {
            return View(db.t_PTLStaff_Master_DataCodes.ToList());
        }

        // GET: /MasterDataCodesv2/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_PTLStaff_Master_DataCodes t_ptlstaff_master_datacodes = db.t_PTLStaff_Master_DataCodes.Find(id);
            if (t_ptlstaff_master_datacodes == null)
            {
                return HttpNotFound();
            }
            return View(t_ptlstaff_master_datacodes);
        }

        // GET: /MasterDataCodesv2/Create
        [Authorize(Roles = "SScanEdit")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /MasterDataCodesv2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SScanEdit")]
        public ActionResult Create([Bind(Include = "DataCode")] t_PTLStaff_Master_DataCodes t_ptlstaff_master_datacodes)
        {
            if (ModelState.IsValid)
            {
                db.t_PTLStaff_Master_DataCodes.Add(t_ptlstaff_master_datacodes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_ptlstaff_master_datacodes);
        }

        // GET: /MasterDataCodesv2/Edit/5
        [Authorize(Roles = "SScanEdit")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_PTLStaff_Master_DataCodes t_ptlstaff_master_datacodes = db.t_PTLStaff_Master_DataCodes.Find(id);
            if (t_ptlstaff_master_datacodes == null)
            {
                return HttpNotFound();
            }
            return View(t_ptlstaff_master_datacodes);
        }

        // POST: /MasterDataCodesv2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SScanEdit")]
        public ActionResult Edit([Bind(Include = "DataCode")] t_PTLStaff_Master_DataCodes t_ptlstaff_master_datacodes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_ptlstaff_master_datacodes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_ptlstaff_master_datacodes);
        }

        // GET: /MasterDataCodesv2/Delete/5
        [Authorize(Roles = "SScanEdit")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_PTLStaff_Master_DataCodes t_ptlstaff_master_datacodes = db.t_PTLStaff_Master_DataCodes.Find(id);
            if (t_ptlstaff_master_datacodes == null)
            {
                return HttpNotFound();
            }
            return View(t_ptlstaff_master_datacodes);
        }

        // POST: /MasterDataCodesv2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SScanEdit")]
        public ActionResult DeleteConfirmed(string id)
        {
            t_PTLStaff_Master_DataCodes t_ptlstaff_master_datacodes = db.t_PTLStaff_Master_DataCodes.Find(id);
            db.t_PTLStaff_Master_DataCodes.Remove(t_ptlstaff_master_datacodes);
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
