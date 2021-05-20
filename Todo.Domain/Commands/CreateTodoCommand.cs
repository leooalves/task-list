using System;
using Flunt.Notifications;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Shared.Commands;

namespace Todo.Domain.Commands
{
    public class CreateTodoCommand : Notifiable<Notification>, ICommand
    {
        public CreateTodoCommand(string title, string user, DateTime date)
        {
            Title = title;
            User = user;
            Date = date;
        }

        public string Title { get; set; }

        public string User { get; set; }

        public DateTime Date { get; set; }

        public void Validate()
        {
            AddNotifications(new CreateTodoCommandContract(this));
        }
    }
}