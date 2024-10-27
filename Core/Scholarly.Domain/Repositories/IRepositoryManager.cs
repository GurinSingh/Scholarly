using Scholarly.Domain.Repositories.Common;
using Scholarly.Domain.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarly.Domain.Repositories
{
    public interface IRepositoryManager
    {
        public IUserRepository UserRepository { get; }
        public IWorkExperienceRepository WorkExperienceRepository { get; }
        public IGenderRepository GenderRepository { get; }

        public IUnitOfWork UnitOfWork { get; }
    }
}
