using System;
using Domain.Commands;
using Domain.Commands.User;
using Domain.Entities;
using Domain.interfaces.Commands;
using Domain.Interfaces.Handlers;
using Domain.Interfaces.Repositories;

namespace Domain.Handlers
{
    public class UserHandler : 
    IHandler<CreateUserCommand>,
    IHandler<UpdateUserCommand>,
    IHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _repository;

        public UserHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(CreateUserCommand command)
        {
            if(!command.IsValid)
                return new GenericResultCommand(false,"Titulo vazio!",null);

            var task = new User(command.Nome, command.Password);
            //repository
                _repository.Create(task);
            //
            return new GenericResultCommand(true, "Criado com Sucesso!", task);
        }

        public ICommandResult Handle(UpdateUserCommand command)
        {
            if(!command.IsValid)
                return new GenericResultCommand(false,"Titulo vazio!",null);
             
            //repository
            var task = _repository.GetById(command.Id);
            // reidratacao
            task.UpdataUser(command.Nome,command.Password);
            //
            _repository.Update(task);
            //
            return new GenericResultCommand(true, "Atualizado com Sucesso!", task);
        }

        public ICommandResult Handle(DeleteUserCommand command)
        {
            if(command.id == 0)
                return new GenericResultCommand(false,"Id vazio!",null);
            
                //repository
                _repository.Delete(command.id);
                //
            return new GenericResultCommand(true, "Deletado com Sucesso!", null);
        }
    }
}
