using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BLL.Models.Mapping
{
    public class ConsultantMap : EntityTypeConfiguration<Consultant>
    {
        public ConsultantMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.FirstName)
                .IsRequired();

            this.Property(t => t.Surname)
                .IsRequired();

            this.Property(t => t.Email)
                .IsRequired();

            this.Property(t => t.PhoneNumber)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Consultants");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.Surname).HasColumnName("Surname");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.PhoneNumber).HasColumnName("PhoneNumber");
        }
    }
}
