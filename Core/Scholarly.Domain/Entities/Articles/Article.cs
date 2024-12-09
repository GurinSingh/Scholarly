using Scholarly.Domain.Entities.Users;
using Scholarly.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Scholarly.Domain.Entities.Articles
{
    public class Article : BaseEntity
    {
        public Article()
        {
            this.CreatedBy = new();
            this.ModifiedBy = new HashSet<User>();
            this.Images = new HashSet<ArticleImage>();
        }
        public int ArticleId { get; set; }

        private string _title;
        public string Title { 
            get
            {
                return this._title;
            } 
            set 
            {  
                this._title = value;
                this.Selector = value.Replace(" ", "-").RemoveNotAllowedUrlCharacters();
            } 
        }
        public string Introduction { get; set; }
        public string Description { get; set; }
        public string Selector{ get; set; }

        public int CreatedByUserId { get; set; }
        public virtual User CreatedBy { get; set; }

        public virtual ICollection<User> ModifiedBy { get; set; }
        public virtual ICollection<ArticleImage> Images { get; set; }
    }
}
