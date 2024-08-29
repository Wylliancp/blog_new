using Domain.interfaces.Commands;
using Domain.Utils;

namespace Domain.Commands.Posts
{
    public class DeletePostsCommand : ICommand
    {
       public int id { get; set; }
       
    }
}
