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
    public class staffShiftTemplateV2Controller : Controller

    {
        private Entities db = new Entities();

        // GET: staffShiftTemplateV2
        [Authorize(Roles = "SScanEdit")]
        public ActionResult Index()
        {
            string UserIdentity = User.Identity.Name;
            string DefaultSite = "No Default Site";
            // Set the user name first
            if (UserIdentity == "")
            {
                UserIdentity = "Not Logged in";
            }

            // Get the default site for the user
            IQueryable<t_PTLStaff_Master_UserSites> userSites = db.t_PTLStaff_Master_UserSites
                .Where(c => c.UserName == UserIdentity);
            userSites = userSites.Take(1);
            foreach (var DefaultSites in userSites)
            {
                DefaultSite = Convert.ToString(DefaultSites.UserSiteCode);
            }

            var t_PTLStaff_Details = db.t_PTLStaff_Details.Include(t => t.v_PTLStaff_MasterData_Plants).Include(t => t.v_PTLStaff_MasterData_Breaks).Include(t => t.v_PTLStaff_MasterData_Breaks1).Include(t => t.v_PTLStaff_MasterData_Reason).Include(t => t.v_PTLStaff_MasterData_Discipline).Include(t => t.v_PTLStaff_MasterData_Shifts).Include(t => t.v_PTLStaff_MasterData_Shifts1);
            return View(t_PTLStaff_Details.ToList()
                .Where(c => c.SiteCode == DefaultSite));
        }

        [Authorize(Roles = "SScanEdit")]
        public ActionResult IndexSubmit()
        {
            string UserIdentity = User.Identity.Name;
            string DefaultSite = "No Default Site";
            //string ToDaysDate = DateTime.Now.ToString();
            string ToDaysDate = "";

            // Set the user name first
            if (UserIdentity == "")
            {
                UserIdentity = "Not Logged in";
            }

            // Get the default site for the user
            IQueryable<t_PTLStaff_Master_UserSites> userSites = db.t_PTLStaff_Master_UserSites
                .Where(c => c.UserName == UserIdentity);
            userSites = userSites.Take(1);
            foreach (var DefaultSites in userSites)
            {
                DefaultSite = Convert.ToString(DefaultSites.UserSiteCode);
            }

            // get the financial week and year


            ViewBag.UserIdentity = UserIdentity;
            ViewBag.DefaultSite = DefaultSite;
            ViewBag.SubmitDate = ToDaysDate;

            var t_PTLStaff_Details = db.t_PTLStaff_Details.Include(t => t.v_PTLStaff_MasterData_Plants).Include(t => t.v_PTLStaff_MasterData_Breaks).Include(t => t.v_PTLStaff_MasterData_Breaks1).Include(t => t.v_PTLStaff_MasterData_Reason).Include(t => t.v_PTLStaff_MasterData_Discipline).Include(t => t.v_PTLStaff_MasterData_Shifts).Include(t => t.v_PTLStaff_MasterData_Shifts1);
            return View(t_PTLStaff_Details.ToList()
                .Where(c => c.SiteCode == DefaultSite));
        }

        // GET: staffShiftTemplateV2/Details/5
        [Authorize(Roles = "SScanEdit")]
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_PTLStaff_Details t_PTLStaff_Details = db.t_PTLStaff_Details.Find(id);
            if (t_PTLStaff_Details == null)
            {
                return HttpNotFound();
            }
            return View(t_PTLStaff_Details);
        }

        // GET: staffShiftTemplateV2/Create
        [Authorize(Roles = "SScanEdit")]
        public ActionResult Create()
        {
            int DefaultSite = 999;
            string UserIdentity = User.Identity.Name;
            // Get the default site for the user
            IQueryable<t_PTLStaff_Master_UserSites> userSites = db.t_PTLStaff_Master_UserSites
                .Where(c => c.UserName == UserIdentity);
            userSites = userSites.Take(1);
            foreach (var DefaultSites in userSites)
            {
                DefaultSite = Convert.ToInt32(DefaultSites.UserSiteCode);
            }
            ViewBag.SiteCode = new SelectList(db.v_PTLStaff_MasterData_Plants, "Plant", "PlantDesc", DefaultSite);
            ViewBag.ScheduledBreaks = new SelectList(db.v_PTLStaff_MasterData_Breaks, "DataValue", "DataValue");
            ViewBag.RevisedBreaks = new SelectList(db.v_PTLStaff_MasterData_Breaks, "DataValue", "DataValue");
            ViewBag.ReasonForChangeInShiftLength = new SelectList(db.v_PTLStaff_MasterData_Reason, "DataValue", "DataValue");
            ViewBag.DisiplinaryStage = new SelectList(db.v_PTLStaff_MasterData_Discipline, "DataValue", "DataValue");
            ViewBag.SchedShiftDuration = new SelectList(db.v_PTLStaff_MasterData_Shifts, "DataValue", "DataValue");
            ViewBag.RevisedShiftDuration = new SelectList(db.v_PTLStaff_MasterData_Shifts, "DataValue", "DataValue");
            return View();
        }

        // POST: staffShiftTemplateV2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SScanEdit")]
        public ActionResult Create([Bind(Include = "Recid,StatusCode,SiteCode,PTLUserName,PTLSAPName,PTLUserID,SchedShiftDuration,RevisedShiftDuration,ScheduledBreaks,RevisedBreaks,ReasonForChangeInShiftLength,Comments,DisiplinaryStage,LastChangedBy,LastChangedDate,Confirmed")] t_PTLStaff_Details t_PTLStaff_Details)
        {
            string UserIdentity = "";
            UserIdentity = User.Identity.Name;
            if (ModelState.IsValid)
            {
                t_PTLStaff_Details.LastChangedBy = UserIdentity;
                t_PTLStaff_Details.LastChangedDate = DateTime.Now;
                t_PTLStaff_Details.DisiplinaryStage = "";
                t_PTLStaff_Details.ReasonForChangeInShiftLength = "";
                t_PTLStaff_Details.RevisedShiftDuration = "";
                t_PTLStaff_Details.StatusCode = "A";
                t_PTLStaff_Details.Confirmed = "";
                t_PTLStaff_Details.Comments = "";
                t_PTLStaff_Details.RevisedBreaks = "";
                db.t_PTLStaff_Details.Add(t_PTLStaff_Details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SiteCode = new SelectList(db.v_PTLStaff_MasterData_Plants, "Plant", "PlantDesc", t_PTLStaff_Details.SiteCode);
            ViewBag.ScheduledBreaks = new SelectList(db.v_PTLStaff_MasterData_Breaks, "DataValue", "DataValue", t_PTLStaff_Details.ScheduledBreaks);
            ViewBag.RevisedBreaks = new SelectList(db.v_PTLStaff_MasterData_Breaks, "DataValue", "DataValue", t_PTLStaff_Details.RevisedBreaks);
            ViewBag.ReasonForChangeInShiftLength = new SelectList(db.v_PTLStaff_MasterData_Reason, "DataValue", "DataValue", t_PTLStaff_Details.ReasonForChangeInShiftLength);
            ViewBag.DisiplinaryStage = new SelectList(db.v_PTLStaff_MasterData_Discipline, "DataValue", "DataValue", t_PTLStaff_Details.DisiplinaryStage);
            ViewBag.SchedShiftDuration = new SelectList(db.v_PTLStaff_MasterData_Shifts, "DataValue", "DataValue", t_PTLStaff_Details.SchedShiftDuration);
            ViewBag.RevisedShiftDuration = new SelectList(db.v_PTLStaff_MasterData_Shifts, "DataValue", "DataValue", t_PTLStaff_Details.RevisedShiftDuration);
            return View(t_PTLStaff_Details);
        }

        // GET: staffShiftTemplateV2/Edit/5
        [Authorize(Roles = "SScanEdit")]
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_PTLStaff_Details t_PTLStaff_Details = db.t_PTLStaff_Details.Find(id);
            if (t_PTLStaff_Details == null)
            {
                return HttpNotFound();
            }
            ViewBag.SiteCode = new SelectList(db.v_PTLStaff_MasterData_Plants, "Plant", "PlantDesc", t_PTLStaff_Details.SiteCode);
            ViewBag.ScheduledBreaks = new SelectList(db.v_PTLStaff_MasterData_Breaks, "DataValue", "DataValue", t_PTLStaff_Details.ScheduledBreaks);
            ViewBag.RevisedBreaks = new SelectList(db.v_PTLStaff_MasterData_Breaks, "DataValue", "DataValue", t_PTLStaff_Details.RevisedBreaks);
            ViewBag.ReasonForChangeInShiftLength = new SelectList(db.v_PTLStaff_MasterData_Reason, "DataValue", "DataValue", t_PTLStaff_Details.ReasonForChangeInShiftLength);
            ViewBag.DisiplinaryStage = new SelectList(db.v_PTLStaff_MasterData_Discipline, "DataValue", "DataValue", t_PTLStaff_Details.DisiplinaryStage);
            ViewBag.SchedShiftDuration = new SelectList(db.v_PTLStaff_MasterData_Shifts, "DataValue", "DataValue", t_PTLStaff_Details.SchedShiftDuration);
            ViewBag.RevisedShiftDuration = new SelectList(db.v_PTLStaff_MasterData_Shifts, "DataValue", "DataValue", t_PTLStaff_Details.RevisedShiftDuration);
            return View(t_PTLStaff_Details);
        }

        // POST: staffShiftTemplateV2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SScanEdit")]
        public ActionResult Edit([Bind(Include = "Recid,StatusCode,SiteCode,PTLUserName,PTLSAPName,PTLUserID,SchedShiftDuration,RevisedShiftDuration,ScheduledBreaks,RevisedBreaks,ReasonForChangeInShiftLength,Comments,DisiplinaryStage,LastChangedBy,LastChangedDate,Confirmed")] t_PTLStaff_Details t_PTLStaff_Details)
        {
            string UserIdentity = "";
            UserIdentity = User.Identity.Name;

            if (ModelState.IsValid)
            {

                t_PTLStaff_Details.LastChangedBy = UserIdentity;
                t_PTLStaff_Details.LastChangedDate = DateTime.Now;
                db.Entry(t_PTLStaff_Details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SiteCode = new SelectList(db.v_PTLStaff_MasterData_Plants, "Plant", "PlantDesc", t_PTLStaff_Details.SiteCode);
            ViewBag.ScheduledBreaks = new SelectList(db.v_PTLStaff_MasterData_Breaks, "DataValue", "DataValue", t_PTLStaff_Details.ScheduledBreaks);
            ViewBag.RevisedBreaks = new SelectList(db.v_PTLStaff_MasterData_Breaks, "DataValue", "DataValue", t_PTLStaff_Details.RevisedBreaks);
            ViewBag.ReasonForChangeInShiftLength = new SelectList(db.v_PTLStaff_MasterData_Reason, "DataValue", "DataValue", t_PTLStaff_Details.ReasonForChangeInShiftLength);
            ViewBag.DisiplinaryStage = new SelectList(db.v_PTLStaff_MasterData_Discipline, "DataValue", "DataValue", t_PTLStaff_Details.DisiplinaryStage);
            ViewBag.SchedShiftDuration = new SelectList(db.v_PTLStaff_MasterData_Shifts, "DataValue", "DataValue", t_PTLStaff_Details.SchedShiftDuration);
            ViewBag.RevisedShiftDuration = new SelectList(db.v_PTLStaff_MasterData_Shifts, "DataValue", "DataValue", t_PTLStaff_Details.RevisedShiftDuration);
            return View(t_PTLStaff_Details);
        }

        // GET: staffShiftTemplateV2/EditSubmit/5
        [Authorize(Roles = "SScanEdit")]
        public ActionResult EditSubmit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_PTLStaff_Details t_PTLStaff_Details = db.t_PTLStaff_Details.Find(id);
            if (t_PTLStaff_Details == null)
            {
                return HttpNotFound();
            }
            ViewBag.SiteCode = new SelectList(db.v_PTLStaff_MasterData_Plants, "Plant", "PlantDesc", t_PTLStaff_Details.SiteCode);
            ViewBag.ScheduledBreaks = new SelectList(db.v_PTLStaff_MasterData_Breaks, "DataValue", "DataValue", t_PTLStaff_Details.ScheduledBreaks);
            ViewBag.RevisedBreaks = new SelectList(db.v_PTLStaff_MasterData_Breaks, "DataValue", "DataValue", t_PTLStaff_Details.RevisedBreaks);
            ViewBag.ReasonForChangeInShiftLength = new SelectList(db.v_PTLStaff_MasterData_Reason, "DataValue", "DataValue", t_PTLStaff_Details.ReasonForChangeInShiftLength);
            ViewBag.DisiplinaryStage = new SelectList(db.v_PTLStaff_MasterData_Discipline, "DataValue", "DataValue", t_PTLStaff_Details.DisiplinaryStage);
            ViewBag.SchedShiftDuration = new SelectList(db.v_PTLStaff_MasterData_Shifts, "DataValue", "DataValue", t_PTLStaff_Details.SchedShiftDuration);
            ViewBag.RevisedShiftDuration = new SelectList(db.v_PTLStaff_MasterData_Shifts, "DataValue", "DataValue", t_PTLStaff_Details.RevisedShiftDuration);
            return View(t_PTLStaff_Details);
        }

        // POST: staffShiftTemplateV2/EditSubmit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SScanEdit")]
        public ActionResult EditSubmit([Bind(Include = "Recid,StatusCode,SiteCode,PTLUserName,PTLSAPName,PTLUserID,SchedShiftDuration,RevisedShiftDuration,ScheduledBreaks,RevisedBreaks,ReasonForChangeInShiftLength,Comments,DisiplinaryStage,LastChangedBy,LastChangedDate,Confirmed")] t_PTLStaff_Details t_ptlstaff_details)
        {
            string UserIdentity = "";
            UserIdentity = User.Identity.Name;

            if (ModelState.IsValid)
            {
                if (t_ptlstaff_details.RevisedShiftDuration == null)
                {
                    t_ptlstaff_details.RevisedShiftDuration = "";
                }
                if (t_ptlstaff_details.RevisedBreaks == null)
                {
                    t_ptlstaff_details.RevisedBreaks = "";
                }
                if (t_ptlstaff_details.ReasonForChangeInShiftLength == null)
                {
                    t_ptlstaff_details.ReasonForChangeInShiftLength = "";
                }
                if (t_ptlstaff_details.DisiplinaryStage == null)
                {
                    t_ptlstaff_details.DisiplinaryStage = "";
                }
                t_ptlstaff_details.LastChangedBy = UserIdentity;
                t_ptlstaff_details.LastChangedDate = DateTime.Now;
                t_ptlstaff_details.Confirmed = "Y";
                db.Entry(t_ptlstaff_details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexSubmit");
            }
            ViewBag.SiteCode = new SelectList(db.v_PTLStaff_MasterData_Plants, "Plant", "PlantDesc", t_ptlstaff_details.SiteCode);
            ViewBag.ScheduledBreaks = new SelectList(db.v_PTLStaff_MasterData_Breaks, "DataValue", "DataValue", t_ptlstaff_details.ScheduledBreaks);
            ViewBag.RevisedBreaks = new SelectList(db.v_PTLStaff_MasterData_Breaks, "DataValue", "DataValue", t_ptlstaff_details.RevisedBreaks);
            ViewBag.ReasonForChangeInShiftLength = new SelectList(db.v_PTLStaff_MasterData_Reason, "DataValue", "DataValue", t_ptlstaff_details.ReasonForChangeInShiftLength);
            ViewBag.DisiplinaryStage = new SelectList(db.v_PTLStaff_MasterData_Discipline, "DataValue", "DataValue", t_ptlstaff_details.DisiplinaryStage);
            ViewBag.SchedShiftDuration = new SelectList(db.v_PTLStaff_MasterData_Shifts, "DataValue", "DataValue", t_ptlstaff_details.SchedShiftDuration);
            ViewBag.RevisedShiftDuration = new SelectList(db.v_PTLStaff_MasterData_Shifts, "DataValue", "DataValue", t_ptlstaff_details.RevisedShiftDuration);
            return View(t_ptlstaff_details);
        }


        // GET: staffShiftTemplateV2/Delete/5
        [Authorize(Roles = "SScanEdit")]
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_PTLStaff_Details t_PTLStaff_Details = db.t_PTLStaff_Details.Find(id);
            if (t_PTLStaff_Details == null)
            {
                return HttpNotFound();
            }
            return View(t_PTLStaff_Details);
        }

        // POST: staffShiftTemplateV2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SScanEdit")]
        public ActionResult DeleteConfirmed(long id)
        {
            t_PTLStaff_Details t_PTLStaff_Details = db.t_PTLStaff_Details.Find(id);
            db.t_PTLStaff_Details.Remove(t_PTLStaff_Details);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("DataSubmit")]
        //[Authorize(Roles = "SScanEdit")]
        [Authorize(Roles = "SScanEdit")]
        public ActionResult DataSubmit(string SubmitDate, string UserIdentity, string DefaultSite)
        {
            DateTime SubmitDateFormat = Convert.ToDateTime(SubmitDate);
            //Check to see if data already exists
            //var deletescorecardrows =
            //    from scorecarddetails in db.t_Scorecard_Details
            //    where (scorecarddetails.Year == Convert.ToInt32(FinYear) && scorecarddetails.Week == Convert.ToInt32(FinWeek) && scorecarddetails.SiteCode == DefaultSite)
            //    select scorecarddetails;

            //IQueryable<t_PTLStaff_Submit_Details> deletestaffshiftrows = db.t_PTLStaff_Submit_Details
            //    .Where(c => c.SiteCode == DefaultSite);

            IQueryable<t_PTLStaff_Submit_Details> deletestaffshiftrows = db.t_PTLStaff_Submit_Details
                .Where(c => c.SiteCode == DefaultSite && c.SubmittedDate == SubmitDateFormat);

            foreach (var deletestaffshift in deletestaffshiftrows)
            {
                db.t_PTLStaff_Submit_Details.Remove(deletestaffshift);
            }
            db.SaveChanges();


            var Newdetail = new t_PTLStaff_Submit_Details();

            IQueryable<t_PTLStaff_Details> staffshifttemplates = db.t_PTLStaff_Details
                .Where(c => c.SiteCode == DefaultSite);

            foreach (var staffshift in staffshifttemplates)
            {
                Newdetail = new t_PTLStaff_Submit_Details();
                Newdetail.SiteCode = staffshift.SiteCode;
                Newdetail.SubmittedDate = Convert.ToDateTime(SubmitDate);
                Newdetail.SubmittedBy = UserIdentity;
                Newdetail.PTLUserName = staffshift.PTLUserName;
                Newdetail.PTLSAPName = staffshift.PTLSAPName;
                Newdetail.PTLUserID = staffshift.PTLUserID;
                Newdetail.SchedShiftDuration = staffshift.SchedShiftDuration;
                Newdetail.RevisedShiftDuration = staffshift.RevisedShiftDuration;
                Newdetail.ScheduledBreaks = staffshift.ScheduledBreaks;
                Newdetail.RevisedBreaks = staffshift.RevisedBreaks;
                Newdetail.ReasonForChangeInShiftLength = staffshift.ReasonForChangeInShiftLength;
                Newdetail.DisiplinaryStage = staffshift.DisiplinaryStage;
                Newdetail.Comments = staffshift.Comments;
                db.t_PTLStaff_Submit_Details.Add(Newdetail);
            }
            db.SaveChanges();

            //ViewBag.SubMessage = "Your data has been submitted";
            return RedirectToAction("Index", "SubmissionDetails");
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
