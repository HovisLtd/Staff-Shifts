using Microsoft.AspNet.Identity.EntityFramework;

namespace StaffShifts.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        //public System.Data.Entity.DbSet<StaffShifts.Models.MasterData> MasterDatas { get; set; }

        //public System.Data.Entity.DbSet<StaffShifts.Models.MasterDataCodes> MasterDataCodes { get; set; }
    }
}