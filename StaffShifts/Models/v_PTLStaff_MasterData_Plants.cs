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
    
    public partial class v_PTLStaff_MasterData_Plants
    {
        public v_PTLStaff_MasterData_Plants()
        {
            this.t_PTLStaff_Details = new HashSet<t_PTLStaff_Details>();
            this.t_PTLStaff_Master_UserSites = new HashSet<t_PTLStaff_Master_UserSites>();
            this.t_PTLStaff_Submit_Details = new HashSet<t_PTLStaff_Submit_Details>();
        }
    
        public int AutoIDCode { get; set; }
        public string Plant { get; set; }
        public string PlantDesc { get; set; }
    
        public virtual ICollection<t_PTLStaff_Details> t_PTLStaff_Details { get; set; }
        public virtual ICollection<t_PTLStaff_Master_UserSites> t_PTLStaff_Master_UserSites { get; set; }
        public virtual ICollection<t_PTLStaff_Submit_Details> t_PTLStaff_Submit_Details { get; set; }
    }
}
