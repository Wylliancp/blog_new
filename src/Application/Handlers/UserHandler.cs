using Application.Commands;
using Application.Commands.User;
using Application.Services;
using Domain.Entities;
using Domain.interfaces.Commands;
using Domain.Interfaces.Handlers;
using Domain.Interfaces.Repositories;

namespace Application.Handlers
{
    public class UserHandler : 
    IHandler<CreateUserCommand>,
    IHandler<UpdateUserCommand>,
    IHandler<DeleteUserCommand>,
    IHandler<AuthenticateUserCommand>
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

        public ICommandResult Handle(AuthenticateUserCommand command)
        {

            if (!command.IsValid)
                return new GenericResultCommand(false, "Nome vazio!", null);

            var task = new User(command.Nome, command.Password);
            //repository
            var user = _repository.Authenticate(task.Nome, task.Password);
            //

            if (user == null)
                return new GenericResultCommand(false, "Usúario ou senha inválido", null);

            var token = TokenServices.GenerateToken(user);
            user.Password = "";

            return new GenericResultCommand(true, "Login com Sucesso!", new
            {
                user = user,
                token = token
            });

        }
    }
}
