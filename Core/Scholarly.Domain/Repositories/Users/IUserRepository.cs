using Scholarly.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarly.Domain.Repositories.Users
{
    public interface IUserRepository
    {
        #region User
        Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<User> GetByIdAsync(int userId, CancellationToken cancellationToken = default);
        Task<User> GetByUserNameAsync(string userName, CancellationToken cancellationToken = default);
        Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
        Task InsertAsync(User user);
        void Update(User user);
        void Delete(User user);
        #endregion

        #region User Education
        Task<IEnumerable<UserEducation>> GetUserEducationsAsync(int userId, CancellationToken cancellationToken = default);
        Task CreateUserEducationAsync(UserEducation userEducation, CancellationToken cancellationToken = default);
        #endregion

        #region User Work Experience
        Task<IEnumerable<UserWorkExperience>> GetUserWorkExperiencesAsync(int userId, CancellationToken cancellationToken = default);
        Task CreateUserWorkExperienceAsync(UserWorkExperience userWorkExperience, CancellationToken cancellationToken = default);
        #endregion
    }
}
