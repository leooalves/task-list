using Flunt.Validations;

namespace Todo.Domain.Commands.Contracts
{
    public class CreateTodoCommandContract : Contract<CreateTodoCommand>
    {
        public CreateTodoCommandContract(CreateTodoCommand createTodoCommand)
        {
            Requires()
                .IsGreaterOrEqualsThan(createTodoCommand.Title, 3, "Title", "Por favor, descreva melhor eta tarefa!")
                .IsGreaterOrEqualsThan(createTodoCommand.User, 6, "Usuário inválido");
        }
    }
}
