using Application.Commands.User;
using Application.Handlers;
using Domain.Entities;
using Domain.interfaces.Commands;
using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]

    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [Route("GetTById")]
        [HttpGet]
        [Authorize]

        public User GetById([FromBody] int id, [FromServices] IUserRepository repository)
        {
            return repository.GetById(id);
        }

        [Route("GetAll")]
        [HttpGet]
        [Authorize]
        public IEnumerable<User> GetAll([FromServices] IUserRepository repository)
        {
            return repository.GetAll();
        }

        [Route("Create")]
        [HttpPost]
        [AllowAnonymous]

        public ICommandResult Create([FromBody] CreateUserCommand createUserCommand, [FromServices] UserHandler handler)
        {
            return handler.Handle(createUserCommand);
        }

        [Route("Update")]
        [HttpPut]
        [Authorize]

        public ICommandResult Finish([FromBody] UpdateUserCommand updateUserCommand, [FromServices] UserHandler handler)
        {
            return handler.Handle(updateUserCommand);
        }

        

        [Route("Delete")]
        [HttpDelete]
        [Authorize]

        public ICommandResult Delete([FromQuery] DeleteUserCommand deleteUserCommand, [FromServices] UserHandler handler)
        {
            return handler.Handle(deleteUserCommand);
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]

        public ICommandResult Authenticate(
         [FromServices] UserHandler handler,
         [FromBody] AuthenticateUserCommand authenticateUserCommand)
        {
            return handler.Handle(authenticateUserCommand);
        }
    }
}
