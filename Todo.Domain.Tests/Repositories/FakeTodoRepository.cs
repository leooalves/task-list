using System;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.Repositories
{
    public class FakeTodoRepository : ITodoRepository
    {
        public void Create(TodoItem todo)
        {

        }

        public TodoItem GetById(Guid id)
        {
            return new TodoItem("Titulo", DateTime.Now, "leonardooliveira");
        }

        public void Update(TodoItem todo)
        {

        }
    }
}