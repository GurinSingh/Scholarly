using Scholarly.Domain.Entities.Contents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarly.Domain.Repositories.Contents
{
    public interface IContentRepository
    {
        Task InsertAsync(Content content);
    }
}
