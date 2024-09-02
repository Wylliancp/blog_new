using Application.Commands.Posts;
using Domain.Entities;
using Application.Handlers;
using Domain.interfaces.Commands;
using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Api.Services;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]

    public class PostsController : ControllerBase
    {
        private readonly ILogger<PostsController> _logger;
        public PostsService _postsService { get; }

        public PostsController(PostsService postsService, ILogger<PostsController> logger)
        {
            _logger = logger;
            _postsService = postsService;
        }

        [Route("GetTById")]
        [HttpGet]
        [Authorize]

        public Posts GetById([FromBody] int id, [FromServices] IPostsRepository repository)
        {
            return repository.GetById(id);
        }

        [Route("GetAll")]
        [HttpGet]
        [AllowAnonymous]

        public IEnumerable<Posts> GetAll([FromServices] IPostsRepository repository)
        {
            return repository.GetAll();
        }

        [Route("Create")]
        [HttpPost]
        [AllowAnonymous]

        public ICommandResult Create([FromBody] CreatePostsCommand createPostsCommand, [FromServices] PostsHandler handler)
        {
             var result =  handler.Handle(createPostsCommand);
            _postsService.CreateNotificationPost(new Models.PostModel(title: "soma de valores", sum: 1));
            return result;
        }

        [Route("Update")]
        [HttpPut]
        [Authorize]

        public ICommandResult Finish([FromBody] UpdatePostsCommand updatePostsCommand, [FromServices] PostsHandler handler)
        {
             return handler.Handle(updatePostsCommand);
        }

        

        [Route("Delete")]
        [HttpDelete]
        [Authorize]

        public ICommandResult Delete([FromQuery] DeletePostsCommand deletePostsCommand, [FromServices] PostsHandler handler)
        {
             return handler.Handle(deletePostsCommand);
        }
    }
}
