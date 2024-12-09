using Microsoft.EntityFrameworkCore;
using Scholarly.Domain.Entities.Articles;
using Scholarly.Domain.Entities.Users;
using Scholarly.Domain.Repositories.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarly.Persistence.Repositories.Articles
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ScholarlyDbContext _context;
        public ArticleRepository(ScholarlyDbContext context)
        {
            this._context = context;
        }
        public async Task<Article> GetByIdAsync(int articleId, CancellationToken cancellationToken = default)
        {
            return await this._context.Articles.FirstOrDefaultAsync(c=> c.ArticleId == articleId);
        }
        public async Task<Article> GetBySelectorAsync(string selector, CancellationToken cancellationToken = default)
        {
            return await this._context.Articles.Where(c => c.Selector == selector).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Article>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await this._context.Articles.ToListAsync(cancellationToken);
        }
        public async Task InsertAsync(Article article)
        {
            await this._context.Articles.AddAsync(article);
        }
    }
}
