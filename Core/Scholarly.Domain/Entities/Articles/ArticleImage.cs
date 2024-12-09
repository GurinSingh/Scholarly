using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarly.Domain.Entities.Articles
{
    public class ArticleImage
    {
        public ArticleImage()
        {
            this.Article = new();
        }
        public int ArticleImageId { get; set; }
        public string Selector { get; set; }
        public int ArticleId { get; set; }
        public byte[] ImageData { get; set; }
        public string MimeType { get; set; }

        public virtual Article Article { get; set; }
    }
}
