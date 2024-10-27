using Microsoft.EntityFrameworkCore;
using Scholarly.Domain.Entities.Common;
using Scholarly.Domain.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarly.Persistence.Repositories.Common
{
    internal sealed class GenderRepository : IGenderRepository
    {
        private readonly ScholarlyDbContext _context;
        public GenderRepository(ScholarlyDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Gender>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await this._context.Genders.ToListAsync(cancellationToken);
        }

        public async Task<Gender> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await this._context.Genders.FirstOrDefaultAsync(g => g.GenderId == id, cancellationToken);
        }
    }
}
