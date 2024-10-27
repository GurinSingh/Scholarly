using Microsoft.AspNetCore.Mvc;
using Scholarly.Contracts.DTOs.Users;
using Scholarly.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarly.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController:  ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public UserController(IServiceManager serviceManager)
        {
            this._serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var usersDto = await this._serviceManager.UserService.GetAllAsync(cancellationToken);
            return Ok(usersDto);
        }
        [HttpGet("{userName}")]
        public async Task<IActionResult> Get(string userName, CancellationToken cancellationToken)
        {
            var userDto = await this._serviceManager.UserService.GetByUserNameAsync(userName, cancellationToken);
            return Ok(userDto);
        }
        [HttpPost("save")]
        public async Task<IActionResult> Post([FromBody]CreateUserDto createUserDto, CancellationToken cancellationToken)
        {
            var userDto = await this._serviceManager.UserService.CreateAsync(createUserDto, cancellationToken);
            return Ok(userDto);
        }
        [HttpPost("education")]
        public async Task<IActionResult> Post([FromBody]List<CreateUserEducationDto> createUserEducationDto, CancellationToken cancellationToken)
        {
            var userEducationDto = await this._serviceManager.UserService.CreateUserEducationsAsync(createUserEducationDto, cancellationToken);
            return Ok(userEducationDto);   
        }
        [HttpPost("workexperience")]
        public async Task<IActionResult> Post([FromBody]List<CreateUserWorkExperienceDto> createUserWorkExperienceDto, CancellationToken cancellationToken)
        {
            var userWorkExperience = await this._serviceManager.UserService.CreateUserWorkExperiencesAsync(createUserWorkExperienceDto, cancellationToken);
            return Ok(null);
        }
    }
}
