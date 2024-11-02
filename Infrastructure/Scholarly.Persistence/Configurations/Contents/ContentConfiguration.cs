using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scholarly.Domain.Entities.Contents;
using Scholarly.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarly.Persistence.Configurations.Contents
{
    public sealed class ContentConfiguration : IEntityTypeConfiguration<Content>
    {
        public void Configure(EntityTypeBuilder<Content> builder)
        {
            builder.ToTable("Contents");

            builder.HasKey(e => e.ContentId);
            builder.Property(e => e.ContentId).UseIdentityColumn(1, 1);
            builder.Property(e => e.ContentTitle).HasMaxLength(1000).IsRequired();
            builder.Property(e => e.ContentDescription).HasMaxLength(-1).IsRequired();
            builder.Property(e => e.DateCreated).IsRequired();
            builder.Property(e => e.DateModified).IsRequired();
            builder.Property(e => e.CreatedByUserId).IsRequired();

            builder.HasOne(e => e.CreatedBy)
                .WithMany()
                .HasForeignKey(e => e.CreatedByUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.ModifiedBy)
                .WithMany(e=> e.Contents)
                .UsingEntity<ContentModifiedByUserMap>(
                    l => l
                    .HasOne<User>()
                    .WithMany()
                    .HasForeignKey(e=> e.ModifiedByUserId)
                    .OnDelete(DeleteBehavior.NoAction),
                    r => r
                    .HasOne<Content>()
                    .WithMany()
                    .HasForeignKey(e=> e.ContentId)
                    .OnDelete(DeleteBehavior.NoAction),
                    p => {
                        p.HasKey(e => e.ContentModifiedByUserMapId);
                        p.Property(e => e.ContentModifiedByUserMapId).UseIdentityColumn(1, 1);
                        p.Property(e=> e.DateModified)
                        .IsRequired()
                        .HasDefaultValueSql("GETDATE()");
                    }
                );
        }
    }
}
