using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scholarly.Domain.Entities.Common;
using Scholarly.Domain.Entities.Articles;

namespace Scholarly.Domain.Entities.Users
{
    public class User : BaseEntity
    {
        public User()
        {
            this.WorkExperiences = new HashSet<UserWorkExperience>();
            this.Educations = new HashSet<UserEducation>();
            this.Articles = new HashSet<Article>();
            this.Gender = new();
        }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DOB { get; set; }
        public string Password { get; set; }

        public virtual ICollection<UserWorkExperience> WorkExperiences { get; set; }
        public virtual ICollection<UserEducation> Educations { get; set; }
        public virtual ICollection<Article> Articles { get; set; }

        public int GenderId { get; set; }
        public virtual Gender Gender { get; set; }
    }
}
