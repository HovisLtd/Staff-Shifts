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
    public class MasterDatav2Controller : Controller
    {
        private Entities db = new Entities();

        // GET: /MasterDatav2/
        public ActionResult Index()
        {
            var t_ptlstaff_master_data = db.t_PTLStaff_Master_Data.Include(t => t.t_PTLStaff_Master_DataCodes);
            return View(t_ptlstaff_master_data.ToList());
        }

        // GET: /MasterDatav2/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_PTLStaff_Master_Data t_ptlstaff_master_data = db.t_PTLStaff_Master_Data.Find(id);
            if (t_ptlstaff_master_data == null)
            {
                return HttpNotFound();
            }
            return View(t_ptlstaff_master_data);
        }

        // GET: /MasterDatav2/Create
        public ActionResult Create()
        {
            ViewBag.DataCode = new SelectList(db.t_PTLStaff_Master_DataCodes, "DataCode", "DataCode");
            return View();
        }

        // POST: /MasterDatav2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Recid,DataCode,DataValue")] t_PTLStaff_Master_Data t_ptlstaff_master_data)
        {
            if (ModelState.IsValid)
            {
                db.t_PTLStaff_Master_Data.Add(t_ptlstaff_master_data);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DataCode = new SelectList(db.t_PTLStaff_Master_DataCodes, "DataCode", "DataCode", t_ptlstaff_master_data.DataCode);
            return View(t_ptlstaff_master_data);
        }

        // GET: /MasterDatav2/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_PTLStaff_Master_Data t_ptlstaff_master_data = db.t_PTLStaff_Master_Data.Find(id);
            if (t_ptlstaff_master_data == null)
            {
                return HttpNotFound();
            }
            ViewBag.DataCode = new SelectList(db.t_PTLStaff_Master_DataCodes, "DataCode", "DataCode", t_ptlstaff_master_data.DataCode);
            return View(t_ptlstaff_master_data);
        }

        // POST: /MasterDatav2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Recid,DataCode,DataValue")] t_PTLStaff_Master_Data t_ptlstaff_master_data)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_ptlstaff_master_data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DataCode = new SelectList(db.t_PTLStaff_Master_DataCodes, "DataCode", "DataCode", t_ptlstaff_master_data.DataCode);
            return View(t_ptlstaff_master_data);
        }

        // GET: /MasterDatav2/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_PTLStaff_Master_Data t_ptlstaff_master_data = db.t_PTLStaff_Master_Data.Find(id);
            if (t_ptlstaff_master_data == null)
            {
                return HttpNotFound();
            }
            return View(t_ptlstaff_master_data);
        }

        // POST: /MasterDatav2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            t_PTLStaff_Master_Data t_ptlstaff_master_data = db.t_PTLStaff_Master_Data.Find(id);
            db.t_PTLStaff_Master_Data.Remove(t_ptlstaff_master_data);
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
