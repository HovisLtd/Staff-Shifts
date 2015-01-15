using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StaffShifts.Models
{
    public class HovisDWMetadata
    {
        [Display(Name = "User Name")]
        public string PTLUserName { get; set; }

        [Display(Name = "SAP User Name")]
        public string PTLSAPName { get; set; }

        [Display(Name = "PTL ID")]
        public string PTLUserID { get; set; }

        [Display(Name = "Site")]
        public string SiteCode { get; set; }

        [Display(Name = "Shift Duration")]
        public string SchedShiftDuration { get; set; }

        [Display(Name = "Revised Shift Duration")]
        public string RevisedShiftDuration { get; set; }

        [Display(Name = "Scheduled Breaks")]
        public string ScheduledBreaks { get; set; }

        [Display(Name = "Revised Breaks")]
        public string RevisedBreaks { get; set; }

        [Display(Name = "Reason")]
        public string ReasonForChangeInShiftLength { get; set; }

        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy", ApplyFormatInEditMode = true)]
        //public DateTime SubmitDate { get; set; }
    }

    public class UserSitesMetadata
    {
        [Display(Name = "Site")]
        public string UserSiteCode { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }
    }

    public class PlantsMetadata
    {
        [Display(Name = "Site Code")]
        public string Plant { get; set; }

        [Display(Name = "Site Name")]
        public string PlantDesc { get; set; }
    }
}