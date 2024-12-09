using AutoMapper;
using Scholarly.Contracts.DTOs.Articles;
using Scholarly.Domain.Entities.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarly.Contracts.Mappers.Articles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<WriteArticleDto, Article>();
            CreateMap<Article, ViewArticleDto>();
        }
    }
}
