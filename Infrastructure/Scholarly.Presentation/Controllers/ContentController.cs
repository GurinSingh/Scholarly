using Microsoft.AspNetCore.Mvc;
using Scholarly.Contracts.DTOs.Contents;
using Scholarly.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Scholarly.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContentController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ContentController(IServiceManager serviceManager)
        {
            this._serviceManager = serviceManager;
        }

        [HttpPost("save")]
        public async Task<IActionResult> Post([FromBody]WriteContentDto content, CancellationToken cancellationToken)
        {
            throw new NotImplementedException("test");
            //await this._serviceManager.ContentService.CreateAsync(content, cancellationToken);
            //return Ok(content);
        }
    }
}
