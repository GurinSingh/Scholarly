using Scholarly.Contracts.DTOs.Contents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarly.Services.Abstractions.Contents
{
    public interface IContentService
    {
        Task CreateAsync(WriteContentDto writeContentDto, CancellationToken cancellationToken);
    }
}
