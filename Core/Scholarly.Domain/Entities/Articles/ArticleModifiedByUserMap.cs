using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarly.Domain.Entities.Articles
{
    public class ArticleModifiedByUserMap
    {
        public int ArticleModifiedByUserMapId { get; set; }
        public int ArticleId { get; set; }
        public int ModifiedByUserId { get; set; }
        public DateTime DateModified { get; set; }
    }
}
