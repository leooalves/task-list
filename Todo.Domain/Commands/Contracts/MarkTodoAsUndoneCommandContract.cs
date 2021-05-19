using Flunt.Validations;

namespace Todo.Domain.Commands.Contracts
{
    public class MarkTodoAsUndoneCommandContract : Contract<MarkTodoAsUndoneCommand>
    {
        public MarkTodoAsUndoneCommandContract(MarkTodoAsUndoneCommand markTodoAsUndoneCommand)
        {
            Requires()
                .AreEquals(markTodoAsUndoneCommand.Id.ToString().Length, 36, "O Id deve ter 36 caracteres")
                .IsGreaterOrEqualsThan(markTodoAsUndoneCommand.User, 6, "Usuário inválido");
        }
    }
}