using Domain.interfaces.Commands;
using Domain.Utils;

namespace Application.Commands.User
{
    public class DeleteUserCommand : ICommand
    {
       public int id { get; set; }
       
    }
}
