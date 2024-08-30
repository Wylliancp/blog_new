using Domain.Commands;
using Domain.Commands.Posts;
using Domain.Entities;
using Domain.interfaces.Commands;
using Domain.Interfaces.Handlers;
using Domain.Interfaces.Repositories;

namespace Domain.Handlers
{
    public class PostsHandler : 
    IHandler<CreatePostsCommand>,
    IHandler<UpdatePostsCommand>,
    IHandler<DeletePostsCommand>
    {
        private readonly IPostsRepository _repository;

        public PostsHandler(IPostsRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(CreatePostsCommand command)
        {
            if(!command.IsValid)
                return new GenericResultCommand(false,"Dados vazio!",null);

            var task = new Posts(command.Title, command.Description, command.UserId);
            //repository
                _repository.Create(task);
            //
            return new GenericResultCommand(true, "Criado com Sucesso!", task);
        }

        public ICommandResult Handle(UpdatePostsCommand command)
        {
            if(!command.IsValid)
                return new GenericResultCommand(false,"Titulo vazio!",null);
             
            //repository
            var task = _repository.GetById(command.Id);
            // reidratacao
            task.UpdataPosts(command.Title,command.Description);
            //
            _repository.Update(task);
            //
            return new GenericResultCommand(true, "Atualizado com Sucesso!", task);
        }

        public ICommandResult Handle(DeletePostsCommand command)
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
