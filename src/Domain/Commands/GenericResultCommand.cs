using Domain.Entities;
using Domain.interfaces.Commands;

namespace Domain.Commands
{
    public class GenericResultCommand : ICommandResult
    {
        public GenericResultCommand(bool success, string message, EntityBase data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

       public bool Success { get; set; }
       public string Message { get; set; }
       public EntityBase Data { get; set; }
       
       
    }
}
