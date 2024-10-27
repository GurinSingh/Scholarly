using Microsoft.EntityFrameworkCore;
using Scholarly.Domain.Entities.Users;
using Scholarly.Domain.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarly.Persistence.Repositories.Users
{
    internal sealed class WorkExperienceRepository : IWorkExperienceRepository
    {
        private readonly ScholarlyDbContext _context;

        public WorkExperienceRepository(ScholarlyDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<UserWorkExperience>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await this._context.UserWorkExperiences.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<UserWorkExperience>> GetByUserIdAsync(int userId, CancellationToken cancellationToken = default)
        {
            return await this._context.UserWorkExperiences.Where(uwem => uwem.UserId == userId).ToListAsync(cancellationToken);
        }
    }
}
