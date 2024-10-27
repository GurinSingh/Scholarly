using Scholarly.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarly.Domain.Repositories.Users
{
    public interface IUserEducationRepository
    {
        Task<IEnumerable<UserEducation>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<UserEducation>> GetByUserIdAsync(int userId, CancellationToken cancellationToken = default);
        Task<UserEducation> GetByIdAsync(int educationId, CancellationToken cancellationToken = default);
        void Insert(UserEducation userEducation);
        void Update(UserEducation userEducation);
        void Delete(UserEducation userEducation);
    }
}
