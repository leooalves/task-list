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
        IHandler<CreateTodoCommand>,
        IHandler<UpdateTodoCommand>,
        IHandler<MarkTodoAsDoneCommand>,
        IHandler<MarkTodoAsUndoneCommand>
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

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            //fail fast validation
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Ops, sua tarefa está errada", command.Notifications);

            //gera o TodoItem
            var todoItem = _repository.GetById(command.Id, command.User);

            todoItem.UpdateTitle(command.Title);

            //salva no banco
            _repository.Update(todoItem);

            return new GenericCommandResult(true, "Tarefa salva", todoItem);
        }

        public ICommandResult Handle(MarkTodoAsDoneCommand command)
        {
            //fail fast validation
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Ops, sua tarefa está errada", command.Notifications);


            //Busca o TodoItem
            var todoItem = _repository.GetById(command.Id, command.User);

            //altera o estado
            todoItem.MarkAsDone();

            //salva no banco
            _repository.Update(todoItem);

            return new GenericCommandResult(true, "Tarefa salva", todoItem);
        }

        public ICommandResult Handle(MarkTodoAsUndoneCommand command)
        {
            //fail fast validation
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Ops, sua tarefa está errada", command.Notifications);


            //Busca o TodoItem
            var todoItem = _repository.GetById(command.Id, command.User);

            //altera o estado
            todoItem.MarkAsUndone();

            //salva no banco
            _repository.Update(todoItem);

            return new GenericCommandResult(true, "Tarefa salva", todoItem);
        }
    }
}