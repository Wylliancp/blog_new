using Domain.interfaces.Commands;
using Domain.Utils;

namespace Domain.Commands.User
{
    public class UpdateUserCommand : Validation<UpdateUserCommand>, ICommand
    {
        public UpdateUserCommand(int id, string nome, string password)
        {
            ValidTasksTitle(nome);

            Id = id;
            Nome = nome;
            Password = password;
        }

       public int Id { get; set; }
       public string Nome { get; set; }
        public string Password { get; set; } 
       
    }
}
