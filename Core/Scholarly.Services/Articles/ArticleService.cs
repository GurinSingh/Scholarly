using AutoMapper;
using Scholarly.Contracts.DTOs.Articles;
using Scholarly.Domain.Entities.Articles;
using Scholarly.Domain.Entities.Users;
using Scholarly.Domain.Repositories;
using Scholarly.Services.Abstractions.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarly.Services.Articles
{
    public class ArticleService : IArticleService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ArticleService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            this._repositoryManager = repositoryManager;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<ViewArticleDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var articles = await this._repositoryManager.ArticleRepository.GetAllAsync(cancellationToken);
            return this._mapper.Map<IEnumerable<ViewArticleDto>>(articles);
        }

        public async Task<ViewArticleDto> GetByIdAsync(int articleId, CancellationToken cancellationToken = default)
        {
            Article article = await this._repositoryManager.ArticleRepository.GetByIdAsync(articleId, cancellationToken);
            return this._mapper.Map<ViewArticleDto>(article);
        }

        public async Task<ViewArticleDto> GetBySelectorAsync(string selector, CancellationToken cancellationToken = default)
        {
            Article article = await this._repositoryManager.ArticleRepository.GetBySelectorAsync(selector, cancellationToken);
            return this._mapper.Map<ViewArticleDto>(article);
        }

        public async Task CreateAsync(WriteArticleDto writeArticleDto, CancellationToken cancellationToken)
        {
            User user = await this._repositoryManager.UserRepository.GetByIdAsync(1, cancellationToken);

            Article article = this._mapper.Map<Article>(writeArticleDto);
            article.CreatedByUserId = user.UserId;
            article.CreatedBy = user;
            article.DateCreated = DateTime.UtcNow;
            article.DateModified = DateTime.UtcNow;
            article.IsActive = true;
            article.ModifiedBy = [user];

            await this._repositoryManager.ArticleRepository.InsertAsync(article);
            await this._repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }        
    }
}
