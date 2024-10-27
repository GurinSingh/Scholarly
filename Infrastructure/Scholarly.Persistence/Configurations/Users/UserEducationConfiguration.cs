using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scholarly.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarly.Persistence.Configurations.Users
{
    public class UserEducationConfiguration : IEntityTypeConfiguration<UserEducation>
    {
        public void Configure(EntityTypeBuilder<UserEducation> builder)
        {
            builder.ToTable("UserEducations");

            builder.HasKey(e => e.EducationId);
            builder.Property(e => e.EducationId).UseIdentityColumn(1, 1);
            builder.Property(e => e.UserId).IsRequired();
            builder.Property(e => e.EducationName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.StartDt).IsRequired();
            builder.Property(e => e.EndDt).IsRequired();
            builder.Property(e => e.IsCurrent).IsRequired().HasDefaultValue(false);
            builder.Property(e => e.FieldOfStudy).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Level).IsRequired().HasMaxLength(50);
            builder.Property(e => e.InstituteName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Description).HasMaxLength(1000);
            builder.Property(e=> e.DateCreated).IsRequired();
            builder.Property(e=> e.DateModified).IsRequired();

            builder.HasOne(e => e.User)
                .WithMany(e=> e.Educations)
                .HasForeignKey(e => e.UserId);
        }
    }
}
