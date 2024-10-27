using Scholarly.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarly.Domain.Repositories.Common
{
    public interface IGenderRepository
    {
        Task<IEnumerable<Gender>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Gender> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
