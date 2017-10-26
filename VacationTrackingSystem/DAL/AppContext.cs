using Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AppContext : DbContext
    {
        public AppContext() : base("VacationTrackingSystemCS") {

            this.Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<VacationRequest> VacationRequests { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<InfoAboutVacation> InfoAboutVacations { get; set; }
        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Properties<DateTime>()
.Configure(c => c.HasColumnType("datetime2"));
            // builder.Entity<User>().HasOptional(u => u.InfoAboutVacation).WithOptionalPrincipal(o => o.User).Map(m => m.MapKey("UserId"));
        }
    }
}
