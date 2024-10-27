using AutoMapper;
using Scholarly.Contracts.DTOs.Users;
using Scholarly.Domain.Entities.Users;
using Scholarly.Domain.Repositories;
using Scholarly.Services.Abstractions;
using Scholarly.Services.Abstractions.Users;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarly.Services.Users
{
    public class WorkExperienceService : IWorkExperienceService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public WorkExperienceService(IRepositoryManager _repositoryManager, IMapper mapper)
        {
            this._repositoryManager = _repositoryManager;
            this._mapper = mapper;
        }
        public Task<IEnumerable<UserWorkExperienceDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserWorkExperienceDto>> GetByUserIdAsync(int userId, CancellationToken cancellationToken = default)
        {
            var workExperience = await this._repositoryManager.WorkExperienceRepository.GetByUserIdAsync(userId, cancellationToken);
            return this._mapper.Map<IEnumerable<UserWorkExperienceDto>>(workExperience);
        }
    }
}
