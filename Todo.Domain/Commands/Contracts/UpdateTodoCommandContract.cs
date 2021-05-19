using Flunt.Validations;

namespace Todo.Domain.Commands.Contracts
{
    public class UpdateTodoCommandContract : Contract<UpdateTodoCommand>
    {
        public UpdateTodoCommandContract(UpdateTodoCommand updateTodoCommand)
        {
            Requires()
                .IsGreaterOrEqualsThan(updateTodoCommand.Title, 3, "Title", "Por favor, descreva melhor eta tarefa!")
                .IsGreaterOrEqualsThan(updateTodoCommand.User, 6, "Usuário inválido")
                .AreEquals(updateTodoCommand.Id.ToString().Length, 36, "O Id deve ter 36 caracteres");
        }
    }
}
