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
    public sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(e => e.UserId);
            builder.Property(e => e.UserId).UseIdentityColumn(1, 1);
            builder.Property(e => e.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(50).IsRequired();
            builder.Property(e => e.UserName).HasMaxLength(100);
            builder.Property(e => e.Email).IsRequired().HasMaxLength(100);
            builder.Property(e => e.PhoneNumber).HasMaxLength(10);
            builder.Property(e => e.DOB);
            builder.Property(e => e.GenderId).IsRequired();
            builder.Property(e => e.Password).IsRequired();
            builder.Property(e => e.IsActive).HasDefaultValue(true);
            builder.Property(e => e.DateCreated).IsRequired();
            builder.Property(e => e.DateModified).IsRequired();

            builder.HasIndex(e => e.UserName)
                .IsUnique().HasFilter(null);

            builder.HasIndex(e => e.Email)
                .IsUnique();

            builder.HasOne(e => e.Gender)
                .WithMany()
                .HasForeignKey(e => e.GenderId);
        }
    }
}
