using AutoMapper;
using Scholarly.Contracts.DTOs.Users;
using Scholarly.Domain.Entities.Users;
using Scholarly.Domain.Repositories;
using Scholarly.Services.Abstractions.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarly.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public UserService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            this._repositoryManager = repositoryManager;
            this._mapper = mapper;
        }
        #region User
        public async Task<UserDto> CreateAsync(CreateUserDto createUserDto, CancellationToken cancellationToken = default)
        {
            var user = await this._repositoryManager.UserRepository.GetByEmailAsync(createUserDto.Email, cancellationToken);
            if (user != null)
                throw new Exception("Email exists");

            user = await this._repositoryManager.UserRepository.GetByUserNameAsync(createUserDto.UserName, cancellationToken);
            if (user != null)
                throw new Exception("User Name exists");

            user = this._mapper.Map<User>(createUserDto);
            user.Gender = await this._repositoryManager.GenderRepository.GetByIdAsync(user.GenderId, cancellationToken);
            user.IsActive = true;
            user.DateCreated = DateTime.UtcNow;
            user.DateModified = DateTime.UtcNow;

            await this._repositoryManager.UserRepository.Insert(user);
            await this._repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            user = await this._repositoryManager.UserRepository.GetByEmailAsync(createUserDto.Email, cancellationToken);
            return this._mapper.Map<UserDto>(user);
        }

        public Task DeleteAsync(int userId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var users = await this._repositoryManager.UserRepository.GetAllAsync(cancellationToken);
            return this._mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            var user = await this._repositoryManager.UserRepository.GetByEmailAsync(email, cancellationToken);
            return this._mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetByUserNameAsync(string userName, CancellationToken cancellationToken = default)
        {
            var user = await this._repositoryManager.UserRepository.GetByUserNameAsync(userName, cancellationToken);
            return this._mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetByIdAsync(int userId, CancellationToken cancellationToken = default)
        {
            var user = await this._repositoryManager.UserRepository.GetByIdAsync(userId, cancellationToken);
            return this._mapper.Map<UserDto>(user);
        }

        public Task UpdateAsync(int userId, UpdateUserDto updateUserDto, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region User Education
        public async Task<IEnumerable<UserEducationDto>> GetUserEducationsAsync(int userId, CancellationToken cancellationToken = default)
        {
            var userEducation = await this._repositoryManager.UserRepository.GetUserEducationsAsync(userId, cancellationToken);
            return this._mapper.Map<IEnumerable<UserEducationDto>>(userEducation);
        }

        public async Task<IEnumerable<UserEducationDto>> CreateUserEducationsAsync(IList<CreateUserEducationDto> createUserEducationsDto, CancellationToken cancellationToken = default)
        {
            if (createUserEducationsDto.Count == 0)
                throw new Exception("Nothing to save");

            int userId = createUserEducationsDto.First().UserId;
            var user = await this._repositoryManager.UserRepository.GetByIdAsync(userId, cancellationToken);

            var userEducations = this._mapper.Map<IList<UserEducation>>(createUserEducationsDto);

            foreach (var ue in userEducations)
            {
                ue.User = user;
                await this._createUserEducationAsync(ue, cancellationToken);
            }
            await this._repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            var userEducationsDto = await this._repositoryManager.UserRepository.GetUserEducationsAsync(userId, cancellationToken);
            return this._mapper.Map<IEnumerable<UserEducationDto>>(userEducationsDto);
        }
        #endregion

        #region User Work Experience
        public async Task<IEnumerable<UserWorkExperienceDto>> GetUserWorkExperiencesAsync(int userId, CancellationToken cancellationToken = default)
        {
            var userWorkExperiences = await this._repositoryManager.UserRepository.GetUserWorkExperiencesAsync(userId, cancellationToken);
            return this._mapper.Map<IEnumerable<UserWorkExperienceDto>>(userWorkExperiences);
        }

        public async Task<IEnumerable<UserWorkExperienceDto>> CreateUserWorkExperiencesAsync(IList<CreateUserWorkExperienceDto> createUserWorkExperiencesDto, CancellationToken cancellationToken = default)
        {
            if (createUserWorkExperiencesDto.Count == 0)
                throw new Exception("Nothing to save");

            int userId = createUserWorkExperiencesDto.First().UserId;
            var user = await this._repositoryManager.UserRepository.GetByIdAsync(userId, cancellationToken);

            var userWorkExperiences = this._mapper.Map<IList<UserWorkExperience>>(createUserWorkExperiencesDto);

            foreach (var uwe in userWorkExperiences)
            {
                uwe.User = user;
                await this._createUserWorkExperienceAsync(uwe, cancellationToken);
            }
            await this._repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            var userEducations = await this._repositoryManager.UserRepository.GetUserWorkExperiencesAsync(userId, cancellationToken);
            return this._mapper.Map<IEnumerable<UserWorkExperienceDto>>(userEducations);
        }

        private async Task _createUserEducationAsync(UserEducation userEducation, CancellationToken cancellationToken) =>
            await this._repositoryManager.UserRepository.CreateUserEducationAsync(userEducation, cancellationToken);

        private async Task _createUserWorkExperienceAsync(UserWorkExperience userWorkExperience, CancellationToken cancellationToken) =>
            await this._repositoryManager.UserRepository.CreateUserWorkExperienceAsync(userWorkExperience, cancellationToken);

        #endregion
    }
}
