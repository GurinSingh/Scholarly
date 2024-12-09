using AutoMapper;
using Scholarly.Domain.Repositories;
using Scholarly.Services.Abstractions;
using Scholarly.Services.Abstractions.Articles;
using Scholarly.Services.Abstractions.Users;
using Scholarly.Services.Articles;
using Scholarly.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarly.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IUserService> _lazyUserService;
        private readonly Lazy<IWorkExperienceService> _lazyWorkExperienceService;
        private readonly Lazy<IArticleService> _lazyArticleService;

        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            this._lazyUserService = new Lazy<IUserService>(() => new UserService(repositoryManager, mapper));
            this._lazyWorkExperienceService = new Lazy<IWorkExperienceService>(()=> new WorkExperienceService(repositoryManager, mapper));
            this._lazyArticleService = new Lazy<IArticleService>(()=> new ArticleService(repositoryManager, mapper));
        }
        public IUserService UserService => this._lazyUserService.Value;
        public IWorkExperienceService WorkExperienceService => this._lazyWorkExperienceService.Value;
        public IArticleService ArticleService => this._lazyArticleService.Value;
    }
}
