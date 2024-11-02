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
    public class UserWorkExperienceConfiguration : IEntityTypeConfiguration<UserWorkExperience>
    {
        public void Configure(EntityTypeBuilder<UserWorkExperience> builder)
        {
            builder.ToTable("UserWorkExperiences");

            builder.HasKey(e => e.UserWorkExperienceId);
            builder.Property(e => e.UserWorkExperienceId).UseIdentityColumn(1, 1);
            builder.Property(e => e.UserId).IsRequired();
            builder.Property(e => e.Position).IsRequired().HasMaxLength(100);
            builder.Property(e => e.StartDt).IsRequired();
            builder.Property(e => e.EndDt).IsRequired();
            builder.Property(e => e.IsCurrent).IsRequired().HasDefaultValue(false);
            builder.Property(e => e.Description).HasMaxLength(1000);
            builder.Property(e => e.SkillsUsed).HasMaxLength(1000);
            builder.Property(e => e.CompanyName).HasMaxLength(100);
            builder.Property(e => e.DateCreated).IsRequired();
            builder.Property(e => e.DateModified).IsRequired();

            builder.HasOne(e => e.User)
                .WithMany(e=> e.WorkExperiences)
                .HasForeignKey(e => e.UserId);
        }
    }
}
