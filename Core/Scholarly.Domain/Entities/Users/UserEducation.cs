using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarly.Domain.Entities.Users
{
    public class UserEducation : BaseEntity
    {
        public UserEducation()
        {
            this.User = new();
        }
        public int UserEducationId { get; set; }
        public string EducationName { get; set; }
        public DateTime StartDt { get; set; }
        public DateTime EndDt { get; set; }
        public bool IsCurrent { get; set; }
        public string FieldOfStudy { get; set; }
        public string Level { get; set; }
        public string InstituteName { get; set; }
        public string Description { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
