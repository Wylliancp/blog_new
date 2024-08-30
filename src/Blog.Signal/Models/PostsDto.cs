using System;

namespace Blog.Signal.Models
{
    public class PostsDto
    {
        public int Id { get; set; }
        public DateTime DateCreate { get;  set; }
        public DateTime DateUpdate { get;  set; }

        public string Title { get;  set; }
        public string Description { get;  set; }
        public int UserId { get;  set; }
    }
}
