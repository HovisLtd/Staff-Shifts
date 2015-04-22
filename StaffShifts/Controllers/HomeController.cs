using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StaffShifts.Models;
using StaffShifts.ViewModels;

namespace StaffShifts.Controllers
{
 

    public class HomeController : Controller
    {
        private Entities db = new Entities();
        
        [AllowAnonymous]
        public ActionResult Index()
        {

            ViewData["SubmitDetails"] = (from t_PTLStaff_Submit_Details in db.t_PTLStaff_Submit_Details
                                        group t_PTLStaff_Submit_Details by new { t_PTLStaff_Submit_Details.SiteCode } into ListDocuments
                                        join pl in db.v_PTLStaff_MasterData_Plants on ListDocuments.FirstOrDefault().SiteCode equals pl.Plant
                                        select new LastDateViewModel { Site = pl.PlantDesc, LastDate = ListDocuments.Max(m => m.SubmittedDate) }).ToList(); 

            return View();
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Staff shift recording.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Site contact page.";

            return View();
        }
    }
}