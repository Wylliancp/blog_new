using System.Collections.Generic;
using Domain.Commands;
using Domain.Commands.Posts;
using Domain.Entities;
using Domain.Handlers;
using Domain.interfaces.Commands;
using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly ILogger<PostsController> _logger;

        public PostsController(ILogger<PostsController> logger)
        {
            _logger = logger;
        }

        [Route("GetTById")]
        [HttpGet]
        public Posts GetById([FromBody] int id, [FromServices] IPostsRepository repository)
        {
            return repository.GetById(id);
        }

        [Route("GetAll")]
        [HttpGet]
        public IEnumerable<Posts> GetAll([FromServices] IPostsRepository repository)
        {
            return repository.GetAll();
        }

        [Route("Create")]
        [HttpPost]
        public ICommandResult Create([FromBody] CreatePostsCommand createPostsCommand, [FromServices] PostsHandler handler)
        {
             return handler.Handle(createPostsCommand);
        }

        [Route("Update")]
        [HttpPut]
        public ICommandResult Finish([FromBody] UpdatePostsCommand updatePostsCommand, [FromServices] PostsHandler handler)
        {
             return handler.Handle(updatePostsCommand);
        }

        

        [Route("Delete")]
        [HttpDelete]
        public ICommandResult Delete([FromQuery] DeletePostsCommand deletePostsCommand, [FromServices] PostsHandler handler)
        {
             return handler.Handle(deletePostsCommand);
        }
    }
}
