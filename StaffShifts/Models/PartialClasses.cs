using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StaffShifts.Models
{
    [MetadataType(typeof(HovisDWMetadata))]
    public partial class t_PTLStaff_Details
    {
    }

    [MetadataType(typeof(UserSitesMetadata))]
    public partial class t_PTLStaff_Master_UserSites
    {
    }

    [MetadataType(typeof(PlantsMetadata))]
    public partial class v_PTLStaff_MasterData_Plants
    {
    }

    [MetadataType(typeof(SubmittedDataMetadata))]
    public partial class t_PTLStaff_Submit_Details
    {
    }

    //[MetadataType(typeof(ScorecardDetailsMetaData))]
    //public partial class t_Scorecard_Details
    //{
    //}

    //[MetadataType(typeof(UserSiteMetaData))]
    //public partial class t_Scorecard_Master_UserSites
    //{
    //}
}