using Scholarly.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarly.Domain.Entities.Contents
{
    public class Content: BaseEntity
    {
        public Content()
        {
            this.CreatedBy = new();
            this.ModifiedBy = new HashSet<User>();
        }
        public int ContentId { get; set; }
        public string ContentTitle { get; set; }
        public string ContentDescription { get; set; }

        public int CreatedByUserId { get; set; }
        public virtual User CreatedBy { get; set; }

        public virtual ICollection<User> ModifiedBy { get; set; }
    }
}
