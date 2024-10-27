using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scholarly.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarly.Persistence.Configurations.Common
{
    public sealed class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.ToTable("Genders");

            builder.HasKey(gender => gender.GenderId);
            builder.Property(gender => gender.GenderId).UseIdentityColumn(1, 1);
            builder.Property(gender => gender.GenderName).IsRequired().HasMaxLength(50);
        }
    }
}
