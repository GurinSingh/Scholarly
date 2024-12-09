using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scholarly.Domain.Entities.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarly.Persistence.Configurations.Articles
{
    public sealed class ArticleImageConfiguration : IEntityTypeConfiguration<ArticleImage>
    {
        public void Configure(EntityTypeBuilder<ArticleImage> builder)
        {
            builder.ToTable("ArticleImages");

            builder.HasKey(e => e.ArticleImageId).IsClustered(false);
            builder.Property(e => e.ArticleImageId).UseIdentityColumn(1, 1);
            builder.Property(e => e.ArticleId).IsRequired();
            builder.Property(e => e.ImageData).IsRequired().HasMaxLength(-1);
            builder.Property(e => e.Selector).IsRequired().HasMaxLength(500);
            builder.Property(e => e.MimeType).IsRequired();

            builder.HasIndex(e=> e.Selector)
                .IsUnique()
                .IsClustered(true);
        }
    }
}
