using Domain.interfaces.Commands;
using Domain.Utils;

namespace Domain.Commands.User
{
    public class DeleteUserCommand : ICommand
    {
       public int id { get; set; }
       
    }
}
