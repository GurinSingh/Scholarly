using Scholarly.Contracts.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarly.Services.Abstractions.Users
{
    public interface IWorkExperienceService
    {
        Task<IEnumerable<UserWorkExperienceDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<UserWorkExperienceDto>> GetByUserIdAsync(int userId, CancellationToken cancellationToken = default);
    }
}
