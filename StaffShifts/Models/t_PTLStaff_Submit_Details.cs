//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StaffShifts.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class t_PTLStaff_Submit_Details
    {
        public long Recid { get; set; }
        public string SiteCode { get; set; }
        public string PTLUserName { get; set; }
        public string PTLSAPName { get; set; }
        public string PTLUserID { get; set; }
        public string SchedShiftDuration { get; set; }
        public string RevisedShiftDuration { get; set; }
        public string ScheduledBreaks { get; set; }
        public string RevisedBreaks { get; set; }
        public string ReasonForChangeInShiftLength { get; set; }
        public string Comments { get; set; }
        public string DisiplinaryStage { get; set; }
        public string SubmittedBy { get; set; }
        public Nullable<System.DateTime> SubmittedDate { get; set; }
    
        public virtual v_PTLStaff_MasterData_Plants v_PTLStaff_MasterData_Plants { get; set; }
    }
}
