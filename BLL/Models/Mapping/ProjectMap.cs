using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BLL.Models.Mapping
{
    public class ProjectMap : EntityTypeConfiguration<Project>
    {
        public ProjectMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.ProjectName)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Projects");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ProjectName).HasColumnName("ProjectName");
        }
    }
}
