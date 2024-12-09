using Scholarly.Domain.Entities.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarly.Domain.Repositories.Articles
{
    public interface IArticleRepository
    {
        Task<Article> GetByIdAsync(int articleId, CancellationToken cancellationToken = default);
        Task<Article> GetBySelectorAsync(string selector, CancellationToken cancellationToken = default);
        Task<IEnumerable<Article>> GetAllAsync(CancellationToken cancellationToken = default);
        Task InsertAsync(Article article);
    }
}
