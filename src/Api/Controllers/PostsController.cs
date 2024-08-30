using Domain.Commands.User;
using Domain.Entities;
using Domain.Handlers;
using Domain.interfaces.Commands;
using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [Route("GetTById")]
        [HttpGet]
        public User GetById([FromBody] int id, [FromServices] IUserRepository repository)
        {
            return repository.GetById(id);
        }

        [Route("GetAll")]
        [HttpGet]
        public IEnumerable<User> GetAll([FromServices] IUserRepository repository)
        {
            return repository.GetAll();
        }

        [Route("Create")]
        [HttpPost]
        public ICommandResult Create([FromBody] CreateUserCommand createUserCommand, [FromServices] UserHandler handler)
        {
             return handler.Handle(createUserCommand);
        }

        [Route("Update")]
        [HttpPut]
        public ICommandResult Finish([FromBody] UpdateUserCommand updateUserCommand, [FromServices] UserHandler handler)
        {
             return handler.Handle(updateUserCommand);
        }

        

        [Route("Delete")]
        [HttpDelete]
        public ICommandResult Delete([FromQuery] DeleteUserCommand deleteUserCommand, [FromServices] UserHandler handler)
        {
             return handler.Handle(deleteUserCommand);
        }
    }
}
