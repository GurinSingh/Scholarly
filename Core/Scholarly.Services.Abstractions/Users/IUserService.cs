using Scholarly.Contracts.DTOs.Users;
using Scholarly.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarly.Services.Abstractions.Users
{
    public interface IUserService
    {
        #region User
        Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<UserDto> GetByIdAsync(int userId, CancellationToken cancellationToken = default);
        Task<UserDto> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
        Task<UserDto> GetByUserNameAsync(string userName, CancellationToken cancellationToken = default);
        Task<UserDto> CreateAsync(CreateUserDto createUserDto, CancellationToken cancellationToken = default);
        Task UpdateAsync(int userId, UpdateUserDto updateUserDto, CancellationToken cancellationToken = default);
        Task DeleteAsync(int userId, CancellationToken cancellationToken = default);
        #endregion

        #region User Education
        Task<IEnumerable<UserEducationDto>> GetUserEducationsAsync(int userId, CancellationToken cancellationToken = default);
        Task<IEnumerable<UserEducationDto>> CreateUserEducationsAsync(IList<CreateUserEducationDto> createUserEducationDto, CancellationToken cancellationToken = default);
        #endregion

        #region User Work Experience
        Task<IEnumerable<UserWorkExperienceDto>> GetUserWorkExperiencesAsync(int userId, CancellationToken cancellationToken = default);
        Task<IEnumerable<UserWorkExperienceDto>> CreateUserWorkExperiencesAsync(IList<CreateUserWorkExperienceDto> createUserWorkExperienceDto, CancellationToken cancellationToken = default);
        #endregion
    }
}
