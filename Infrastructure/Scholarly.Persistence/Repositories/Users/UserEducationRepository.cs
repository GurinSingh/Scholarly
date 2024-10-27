using Microsoft.EntityFrameworkCore;
using Scholarly.Domain.Entities.Users;
using Scholarly.Domain.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarly.Persistence.Repositories.Users
{
    internal sealed class UserEducationRepository : IUserEducationRepository
    {
        private readonly ScholarlyDbContext _context;

        public UserEducationRepository(ScholarlyDbContext context)
        {
            _context = context;
        }
        public void Delete(UserEducation userEducation)
        {
            this._context.Remove(userEducation);
        }

        public async Task<IEnumerable<UserEducation>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await this._context.UserEducations.ToListAsync(cancellationToken);
        }

        public async Task<UserEducation> GetByIdAsync(int educationId, CancellationToken cancellationToken = default)
        {
            return await this._context.UserEducations.FindAsync(educationId, cancellationToken);
        }

        public async Task<IEnumerable<UserEducation>> GetByUserIdAsync(int userId, CancellationToken cancellationToken = default)
        {
            return await this._context.UserEducations.Where(ue=> ue.UserId == userId).ToListAsync(cancellationToken);
        }

        public void Insert(UserEducation userEducation)
        {
            this._context.Add(userEducation);
        }

        public void Update(UserEducation userEducation)
        {
            this._context.Update(userEducation);
        }
    }
}
