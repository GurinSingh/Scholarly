using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarly.Contracts.DTOs.Users
{
    public class UserWorkExperienceDto
    {
        public UserWorkExperienceDto()
        {
            this.Users = new HashSet<UserDto>();
        }
        public string Position { get; set; }
        public DateTime StartDt { get; set; }
        public DateTime EndDt { get; set; }
        public bool IsCurrent { get; set; }
        public string Description { get; set; }
        public string SkillsUsed { get; set; }
        public string CompanyName { get; set; }

        public virtual ICollection<UserDto> Users { get; set; }
    }
}
