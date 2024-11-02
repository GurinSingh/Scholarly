using AutoMapper;
using Scholarly.Contracts.DTOs.Contents;
using Scholarly.Domain.Entities.Contents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarly.Contracts.Mappers.Contents
{
    public class ContentProfile : Profile
    {
        public ContentProfile()
        {
            CreateMap<WriteContentDto, Content>();
        }
    }
}
