using Flunt.Validations;

namespace Todo.Domain.Commands.Contracts
{
    public class MarkTodoAsDoneCommandContract : Contract<MarkTodoAsDoneCommand>
    {
        public MarkTodoAsDoneCommandContract(MarkTodoAsDoneCommand markTodoAsDoneCommand)
        {
            Requires()
                .AreEquals(markTodoAsDoneCommand.Id.ToString().Length, 36, "O Id deve ter 36 caracteres")
                .IsGreaterOrEqualsThan(markTodoAsDoneCommand.User, 6, "Usuário inválido");
        }
    }
}