using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BLL.Models.Mapping
{
    public class Consultant_ProjectMap : EntityTypeConfiguration<Consultant_Project>
    {
        public Consultant_ProjectMap()
        {
            // Primary Key
            this.HasKey(t => t.ConsultantId);

            // Properties
            // Table & Column Mappings
            this.ToTable("Consultant_Project");           
            this.Property(t => t.ProjStartDate).HasColumnName("ProjStartDate");
            this.Property(t => t.ProjEndDate).HasColumnName("ProjEndDate");
            this.Property(t => t.BillableStatus).HasColumnName("BillableStatus");
            this.Property(t => t.BillableDaysMonth).HasColumnName("BillableDaysMonth");
            this.Property(t => t.BillableDaysYTD).HasColumnName("BillableDaysYTD");
            this.Property(t => t.ProjectId).HasColumnName("ProjectId");
            this.Property(t => t.ConsultantId).HasColumnName("ConsultantId");

            // Relationships
            this.HasRequired(t => t.Consultant)
                .WithMany(t => t.Consultant_Project)
                .HasForeignKey(d => d.ConsultantId);
            this.HasRequired(t => t.Project)
                .WithMany(t => t.Consultant_Project)
                .HasForeignKey(d => d.ProjectId);

        }
    }
}
