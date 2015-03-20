using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using BLL.Models.Mapping;

namespace BLL.Models
{
    public partial class PlacementDashboardContext : DbContext
    {
        static PlacementDashboardContext()
        {
            Database.SetInitializer<PlacementDashboardContext>(null);
        }

        public PlacementDashboardContext()
            : base("Name=PlacementDashboardContext")
        {
        }

        public DbSet<Consultant_Project> Consultant_Project { get; set; }
        public DbSet<Consultant> Consultants { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Consultant_ProjectMap());
            modelBuilder.Configurations.Add(new ConsultantMap());
            modelBuilder.Configurations.Add(new ProjectMap());
        }
    }
}
