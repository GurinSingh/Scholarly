using AutoMapper;
using Scholarly.Contracts.DTOs.Contents;
using Scholarly.Domain.Entities.Contents;
using Scholarly.Domain.Entities.Users;
using Scholarly.Domain.Repositories;
using Scholarly.Services.Abstractions.Contents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarly.Services.Contents
{
    public class ContentService : IContentService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ContentService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            this._repositoryManager = repositoryManager;
            this._mapper = mapper;
        }
        public async Task CreateAsync(WriteContentDto writeContentDto, CancellationToken cancellationToken)
        {
            User user = await this._repositoryManager.UserRepository.GetByIdAsync(1, cancellationToken);

            Content content = this._mapper.Map<Content>(writeContentDto);
            content.CreatedByUserId = user.UserId;
            content.CreatedBy = user;
            content.DateCreated = DateTime.UtcNow;
            content.DateModified = DateTime.UtcNow;
            content.IsActive = true;
            content.ModifiedBy = [user];

            await this._repositoryManager.ContentRepository.InsertAsync(content);
            await this._repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
