using System;
using Flunt.Notifications;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Shared.Commands;

namespace Todo.Domain.Commands
{
    public class MarkTodoAsUndoneCommand : Notifiable<Notification>, ICommand
    {
        public MarkTodoAsUndoneCommand(Guid id, string user)
        {
            Id = id;
            User = user;

            AddNotifications(new MarkTodoAsUndoneCommandContract(this));
        }

        public Guid Id { get; set; }
        public string User { get; set; }

    }
}