using Scholarly.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarly.Domain.Repositories.Users
{
    public interface IWorkExperienceRepository
    {
        Task<IEnumerable<UserWorkExperience>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<UserWorkExperience>> GetByUserIdAsync(int userId, CancellationToken cancellationToken = default);
    }
}
