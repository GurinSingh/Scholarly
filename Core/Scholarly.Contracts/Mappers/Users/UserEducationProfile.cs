using AutoMapper;
using Scholarly.Contracts.DTOs.Users;
using Scholarly.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarly.Contracts.Mappers.Users
{
    internal class UserEducationProfile: Profile
    {
        public UserEducationProfile()
        {
            CreateMap<UserEducation, UserEducationDto>();
            CreateMap<CreateUserEducationDto, UserEducation>();
        }
    }
}
