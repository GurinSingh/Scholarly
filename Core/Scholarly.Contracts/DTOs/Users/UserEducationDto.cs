using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarly.Contracts.DTOs.Users
{
    public class UserEducationDto
    {
        public UserEducationDto()
        {
            Users = new HashSet<UserDto>();
        }
        public string EducationName { get; set; }
        public DateTime StartDt { get; set; }
        public DateTime EndDt { get; set; }
        public bool IsCurrent { get; set; }
        public string FieldOfStudy { get; set; }
        public string Level { get; set; }
        public string InstituteName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<UserDto> Users { get; set; }
    }
}
