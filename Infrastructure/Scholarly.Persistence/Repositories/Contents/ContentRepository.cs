using Scholarly.Domain.Entities.Contents;
using Scholarly.Domain.Entities.Users;
using Scholarly.Domain.Repositories.Contents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarly.Persistence.Repositories.Contents
{
    public class ContentRepository : IContentRepository
    {
        private readonly ScholarlyDbContext _context;
        public ContentRepository(ScholarlyDbContext context)
        {
            this._context = context;
        }
        public async Task InsertAsync(Content content)
        {
            await this._context.Contents.AddAsync(content);
        }
    }
}
