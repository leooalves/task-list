using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.Queries
{
    [TestClass]
    public class TodoQueriesTests
    {
        private List<TodoItem> _items;

        public TodoQueriesTests()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("Tarefa 1", DateTime.Now, "usuarioA"));
            _items.Add(new TodoItem("Tarefa 2", DateTime.Now, "usuarioA"));
            _items.Add(new TodoItem("Tarefa 3", DateTime.Now, "leonardooliveira"));
            _items.Add(new TodoItem("Tarefa 4", DateTime.Now, "usuarioA"));
            _items.Add(new TodoItem("Tarefa 5", DateTime.Now, "leonardooliveira"));
        }

        [TestMethod]
        public void Deve_retornar_apenas_tarefas_do_usuario_leonardooliveira()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("leonardooliveira"));
            Assert.AreEqual(2, result.Count());
        }
    }
}