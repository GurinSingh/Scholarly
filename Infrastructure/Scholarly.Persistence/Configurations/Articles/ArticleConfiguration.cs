using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scholarly.Domain.Entities.Articles;
using Scholarly.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarly.Persistence.Configurations.Articles
{
    public sealed class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles");

            builder.HasKey(e => e.ArticleId).IsClustered(false);
            builder.Property(e => e.ArticleId).UseIdentityColumn(1, 1);
            builder.Property(e => e.Title).HasMaxLength(200).IsRequired();
            builder.Property(e => e.Introduction).HasMaxLength(1000).IsRequired();
            builder.Property(e => e.Description).HasMaxLength(-1).IsRequired();
            builder.Property(e => e.DateCreated).IsRequired();
            builder.Property(e => e.DateModified).IsRequired();
            builder.Property(e => e.CreatedByUserId).IsRequired();
            builder.Property(e => e.Selector).IsRequired().HasMaxLength(200);

            builder.HasIndex(e => e.Selector)
                .IsUnique()
                .IsClustered(true);

            builder.HasOne(e => e.CreatedBy)
                .WithMany()
                .HasForeignKey(e => e.CreatedByUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.ModifiedBy)
                .WithMany(e=> e.Articles)
                .UsingEntity<ArticleModifiedByUserMap>(
                    l => l
                    .HasOne<User>()
                    .WithMany()
                    .HasForeignKey(e=> e.ModifiedByUserId)
                    .OnDelete(DeleteBehavior.NoAction),
                    r => r
                    .HasOne<Article>()
                    .WithMany()
                    .HasForeignKey(e=> e.ArticleId)
                    .OnDelete(DeleteBehavior.NoAction),
                    p => {
                        p.HasKey(e => e.ArticleModifiedByUserMapId);
                        p.Property(e => e.ArticleModifiedByUserMapId).UseIdentityColumn(1, 1);
                        p.Property(e=> e.DateModified)
                        .IsRequired()
                        .HasDefaultValueSql("GETDATE()");
                    }
                );

            builder.HasMany(e => e.Images)
                .WithOne(e=> e.Article)
                .HasForeignKey(e => e.ArticleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
