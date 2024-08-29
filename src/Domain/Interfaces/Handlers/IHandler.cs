using Domain.interfaces.Commands;

namespace Domain.Interfaces.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
         ICommandResult Handle(T command);
    }
}