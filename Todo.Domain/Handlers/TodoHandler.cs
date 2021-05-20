using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Shared.Commands;
using Todo.Domain.Shared.Handlers;
using Todo.Domain.Repositories;
using Todo.Domain.Entities;

namespace Todo.Domain.Handlers
{
    public class TodoHandler :
        Notifiable<Notification>,
        IHandler<CreateTodoCommand>
    {
        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateTodoCommand command)
        {
            //fail fast validation
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Ops, sua tarefa está errada", command.Notifications);

            //gera o TodoItem
            var todo = new TodoItem(command.Title, command.Date, command.User);

            //salva no banco
            _repository.Create(todo);

            return new GenericCommandResult(true, "Tarefa salva", todo);
        }
    }
}