using Domain.interfaces.Commands;
using Domain.Utils;

namespace Application.Commands.Posts
{
    public class UpdatePostsCommand : Validation<UpdatePostsCommand>, ICommand
    {
        public UpdatePostsCommand(int id, string title, string description)
        {
            ValidTasksTitle(title);

            Id = id;
            Description = description;
        }

       public int Id { get; set; }
       public string Title { get; set; }
        public string Description { get; set; } 
       
    }
}
