using Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace Api.Services
{
    public class PostsService
    {

        public List<PostModel> postModels { get; set; } = new List<PostModel>();


        public void CreateNotificationPost(PostModel postModel)
        {
            this.postModels.Add(postModel);
        }

        public PostModel GetNotificationPost()
        {
            var posts = this.postModels;
            return new PostModel(title: "Soma de Post", sum: posts.Count());
        }
    }
}
