using Microsoft.EntityFrameworkCore;
using Scholarly.Domain.Entities.Users;
using Scholarly.Domain.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Scholarly.Persistence.Repositories.Users
{
    internal sealed class UserRepository : IUserRepository
    {
        private readonly ScholarlyDbContext _context;

        public UserRepository(ScholarlyDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await this._context.Users
                .ToListAsync(cancellationToken);
        }

        public async Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return await this._context.Users
                .FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower(), cancellationToken);
        }

        public async Task<User> GetByIdAsync(int userId, CancellationToken cancellationToken = default)
        {
            return await this._context.Users
                .FirstAsync(u => u.UserId == userId, cancellationToken);
        }

        public async Task<User> GetByUserNameAsync(string userName, CancellationToken cancellationToken = default)
        {
            return await this._context.Users
                .FirstOrDefaultAsync(u => u.UserName.ToLower() == userName.ToLower(), cancellationToken);
        }

        public async Task InsertAsync(User user)
        {
            await this._context.Users.AddAsync(user);
        }

        public void Update(User user)
        {
            this._context.Users.Update(user);
        }

        public void Delete(User user)
        {
            this._context.Users.Remove(user);
        }

        #region User Education
        public async Task<IEnumerable<UserEducation>> GetUserEducationsAsync(int userId, CancellationToken cancellationToken)
        {
            return await this._context.UserEducations
                .ToListAsync(cancellationToken);
        }

        public async Task CreateUserEducationAsync(UserEducation userEducation, CancellationToken cancellationToken)
        {
            await this._context.UserEducations.AddAsync(userEducation, cancellationToken);
        }
        #endregion

        #region User Work Experience
        public async Task<IEnumerable<UserWorkExperience>> GetUserWorkExperiencesAsync(int userId, CancellationToken cancellationToken)
        {
            return await this._context.UserWorkExperiences
                .ToListAsync(cancellationToken);
        }

        public async Task CreateUserWorkExperienceAsync(UserWorkExperience userWorkExperience, CancellationToken cancellationToken)
        {
            await this._context.UserWorkExperiences.AddAsync(userWorkExperience, cancellationToken);
        }
        #endregion
    }
}
