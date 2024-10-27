using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scholarly.Contracts.DTOs.Common;

namespace Scholarly.Contracts.DTOs.Users
{
    public class UserDto
    {
        public UserDto()
        {
            WorkExperiences = new HashSet<UserWorkExperienceDto>();
            Educations = new HashSet<UserEducationDto>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DOB { get; set; }

        public virtual ICollection<UserWorkExperienceDto> WorkExperiences { get; set; }
        public virtual ICollection<UserEducationDto> Educations { get; set; }
        public virtual GenderDto Gender { get; set; }

    }
}
