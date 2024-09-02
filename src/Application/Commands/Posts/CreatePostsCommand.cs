using Domain.interfaces.Commands;
using Domain.Utils;

namespace Application.Commands.Posts
{
    public class CreatePostsCommand : Validation<CreatePostsCommand>, ICommand
    {

        public CreatePostsCommand(string title, string description, int userId)
        {
            ValidTasksTitle(title);
            ValidTasksId(userId);
            Title = title;
            Description = description;
            UserId = userId;
        }
       
       public string Title { get; set; }
       public string Description { get; set; }    
       public int UserId { get; set; }

    }
}




