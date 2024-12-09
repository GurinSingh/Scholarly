using Microsoft.AspNetCore.Mvc;
using Scholarly.Contracts.DTOs.Articles;
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
    public class ArticleController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ArticleController(IServiceManager serviceManager)
        {
            this._serviceManager = serviceManager;
        }
        [HttpGet("getById/{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
        {
            var article = await this._serviceManager.ArticleService.GetByIdAsync(id, cancellationToken);
            return Ok(article ?? new ViewArticleDto());
        }
        [HttpGet("get/{selector}")]
        public async Task<IActionResult> Get(string selector, CancellationToken cancellationToken)
        {
            var article = await this._serviceManager.ArticleService.GetBySelectorAsync(selector, cancellationToken);
            return Ok(article ?? new ViewArticleDto());
        }
        [HttpPost("save")]
        public async Task<IActionResult> Post([FromBody]WriteArticleDto article, CancellationToken cancellationToken)
        {
            await this._serviceManager.ArticleService.CreateAsync(article, cancellationToken);
            return Ok(article);
        }
    }
}
