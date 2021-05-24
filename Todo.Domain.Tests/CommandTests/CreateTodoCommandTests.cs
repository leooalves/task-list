using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;

namespace Todo.Domain.Tests.Commands
{
    [TestClass]
    public class CreateTodoCommandTests
    {
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.Now);
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Titulo", "leonardooliveira", DateTime.Now);

        public CreateTodoCommandTests()
        {
            _invalidCommand.Validate();
            _validCommand.Validate();
        }

        [TestMethod]
        public void Dado_um_comando_invalido_ele_e_invalido()
        {
            Assert.AreEqual(_invalidCommand.IsValid, false);
        }

        [TestMethod]
        public void Dado_um_comando_valido_ele_e_valido()
        {
            Assert.AreEqual(_validCommand.IsValid, true);
        }
    }
}