using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.Entities
{
    [TestClass]
    public class TodoItemTests
    {
        private readonly TodoItem _validTodo = new TodoItem("Titulo", DateTime.Now, "usuario");
        [TestMethod]
        public void Dado_novo_item_ele_nao_deve_estar_realizado()
        {
            Assert.AreEqual(_validTodo.Done, false);
        }
    }
}