using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StaffShifts.Models;
using PagedList;


namespace StaffShifts.Controllers
{
    public class SubmissionDetailsController : Controller
    {
        private Entities db = new Entities();

        // GET: SubmissionDetails
        [Authorize(Roles = "Admin,SScanEdit")]
        public ActionResult Index(int? page)
        {
            DateTime SelectedDate = DateTime.Now.AddDays(-7);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            //return View(db.t_PTLStaff_Submit_Details.ToList()
            //            .OrderByDescending(x => x.SubmittedDate).ThenByDescending(x => x.SiteCode).ThenBy(x => x.PTLUserName));
            return View(db.t_PTLStaff_Submit_Details
            .Where(x => x.SubmittedDate >= SelectedDate)
            .OrderByDescending(x => x.SubmittedDate).ThenByDescending(x => x.SiteCode).ThenBy(x => x.PTLUserName).ToPagedList(pageNumber, pageSize));
        }

        // GET: SubmissionDetails
        [Authorize(Roles = "Admin,SScanEdit")]
        public ActionResult IndexSearch(DateTime? currentFilter, DateTime? SubmitDate, int? page)
        {
            if (SubmitDate != null)
            {
                page = 1;
            }
            else
            {
                SubmitDate = currentFilter;
            }

            ViewBag.CurrentFilter = SubmitDate;
            //DateTime SelectedDate = DateTime.Now.AddDays(-7);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            //return View(db.t_PTLStaff_Submit_Details.ToList()
            //            .OrderByDescending(x => x.SubmittedDate).ThenByDescending(x => x.SiteCode).ThenBy(x => x.PTLUserName));
            return View(db.t_PTLStaff_Submit_Details
            .Where(x => x.SubmittedDate == SubmitDate)
            .OrderByDescending(x => x.SubmittedDate).ThenByDescending(x => x.SiteCode).ThenBy(x => x.PTLUserName).ToPagedList(pageNumber, pageSize));
        }

        // GET: SubmissionDetails/Details/5
        [Authorize(Roles = "Admin,SScanEdit")]
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_PTLStaff_Submit_Details t_PTLStaff_Submit_Details = db.t_PTLStaff_Submit_Details.Find(id);
            if (t_PTLStaff_Submit_Details == null)
            {
                return HttpNotFound();
            }
            return View(t_PTLStaff_Submit_Details);
        }

        // GET: SubmissionDetails/Create
        [Authorize(Roles = "Admin,SScanEdit")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubmissionDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,SScanEdit")]
        public ActionResult Create([Bind(Include = "Recid,SiteCode,PTLUserName,PTLSAPName,PTLUserID,SchedShiftDuration,RevisedShiftDuration,ScheduledBreaks,RevisedBreaks,ReasonForChangeInShiftLength,Comments,DisiplinaryStage,SubmittedBy,SubmittedDate")] t_PTLStaff_Submit_Details t_PTLStaff_Submit_Details)
        {
            if (ModelState.IsValid)
            {
                db.t_PTLStaff_Submit_Details.Add(t_PTLStaff_Submit_Details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_PTLStaff_Submit_Details);
        }

        // GET: SubmissionDetails/Edit/5
        [Authorize(Roles = "Admin,SScanEdit")]
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_PTLStaff_Submit_Details t_PTLStaff_Submit_Details = db.t_PTLStaff_Submit_Details.Find(id);
            if (t_PTLStaff_Submit_Details == null)
            {
                return HttpNotFound();
            }
            return View(t_PTLStaff_Submit_Details);
        }

        // POST: SubmissionDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,SScanEdit")]
        public ActionResult Edit([Bind(Include = "Recid,SiteCode,PTLUserName,PTLSAPName,PTLUserID,SchedShiftDuration,RevisedShiftDuration,ScheduledBreaks,RevisedBreaks,ReasonForChangeInShiftLength,Comments,DisiplinaryStage,SubmittedBy,SubmittedDate")] t_PTLStaff_Submit_Details t_PTLStaff_Submit_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_PTLStaff_Submit_Details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_PTLStaff_Submit_Details);
        }

        // GET: SubmissionDetails/Delete/5
        [Authorize(Roles = "Admin,SScanEdit")]
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_PTLStaff_Submit_Details t_PTLStaff_Submit_Details = db.t_PTLStaff_Submit_Details.Find(id);
            if (t_PTLStaff_Submit_Details == null)
            {
                return HttpNotFound();
            }
            return View(t_PTLStaff_Submit_Details);
        }

        // POST: SubmissionDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,SScanEdit")]
        public ActionResult DeleteConfirmed(long id)
        {
            t_PTLStaff_Submit_Details t_PTLStaff_Submit_Details = db.t_PTLStaff_Submit_Details.Find(id);
            db.t_PTLStaff_Submit_Details.Remove(t_PTLStaff_Submit_Details);
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
