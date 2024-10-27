using AutoMapper;
using Scholarly.Contracts.DTOs.Common;
using Scholarly.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarly.Contracts.Mappers.Common
{
    internal class GenderProfile : Profile
    {
        public GenderProfile()
        {
            CreateMap<Gender, GenderDto>();
        }
    }
}
