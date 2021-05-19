using System;
using Flunt.Notifications;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Shared.Commands;

namespace Todo.Domain.Commands
{
    public class MarkTodoAsDoneCommand : Notifiable<Notification>, ICommand
    {
        public MarkTodoAsDoneCommand(Guid id, string user)
        {
            Id = id;
            User = user;

            AddNotifications(new MarkTodoAsDoneCommandContract(this));
        }

        public Guid Id { get; set; }
        public string User { get; set; }

    }
}