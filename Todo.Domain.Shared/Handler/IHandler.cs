using Todo.Domain.Shared.Commands;

namespace Todo.Domain.Shared.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
