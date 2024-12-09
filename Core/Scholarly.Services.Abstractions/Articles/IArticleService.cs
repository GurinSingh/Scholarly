using Scholarly.Contracts.DTOs.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarly.Services.Abstractions.Articles
{
    public interface IArticleService
    {
        Task<IEnumerable<ViewArticleDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<ViewArticleDto> GetByIdAsync(int articleId, CancellationToken cancellationToken = default);
        Task<ViewArticleDto> GetBySelectorAsync(string selector, CancellationToken cancellationToken = default);
        Task CreateAsync(WriteArticleDto writeArticleDto, CancellationToken cancellationToken);
    }
}
