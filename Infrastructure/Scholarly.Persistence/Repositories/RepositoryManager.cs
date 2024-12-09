using Scholarly.Domain.Entities.Users;
using Scholarly.Domain.Repositories;
using Scholarly.Domain.Repositories.Common;
using Scholarly.Domain.Repositories.Articles;
using Scholarly.Domain.Repositories.Users;
using Scholarly.Persistence.Repositories.Common;
using Scholarly.Persistence.Repositories.Articles;
using Scholarly.Persistence.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarly.Persistence.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IUserRepository> _lazyUserRepository;
        private readonly Lazy<IWorkExperienceRepository> _lazyWorkExperienceRepository;
        private readonly Lazy<IGenderRepository> _lazyGenderRepository;
        private readonly Lazy<IArticleRepository> _lazyArticleRepository;

        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

        public RepositoryManager(ScholarlyDbContext context)
        {
            this._lazyUserRepository = new Lazy<IUserRepository>(()=> new UserRepository(context));
            this._lazyWorkExperienceRepository = new Lazy<IWorkExperienceRepository>(()=> new WorkExperienceRepository(context));
            this._lazyGenderRepository = new Lazy<IGenderRepository>(()=> new GenderRepository(context));
            this._lazyArticleRepository = new Lazy<IArticleRepository>(()=> new ArticleRepository(context));

            this._lazyUnitOfWork = new Lazy<IUnitOfWork>(()=> new UnitOfWork(context));
        }
        public IUserRepository UserRepository => this._lazyUserRepository.Value;
        public IWorkExperienceRepository WorkExperienceRepository => this._lazyWorkExperienceRepository.Value;
        public IGenderRepository GenderRepository => this._lazyGenderRepository.Value;
        public IArticleRepository ArticleRepository => this._lazyArticleRepository.Value;

        public IUnitOfWork UnitOfWork => this._lazyUnitOfWork.Value;
    }
}
