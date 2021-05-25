using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    public class TodoController : ControllerBase
    {
        private readonly TodoHandler _handler;
        private readonly ITodoRepository _repository;
        public TodoController(TodoHandler handler, ITodoRepository repository)
        {
            _handler = handler;
            _repository = repository;
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            return _repository.GetAll("leonardooliveira");
        }

        [Route("done")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllDone()
        {
            return _repository.GetAllDone("leonardooliveira");
        }

        [Route("undone")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllUndone()
        {
            return _repository.GetAllUndone("leonardooliveira");
        }

        [Route("done/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForToday()
        {
            return _repository.GetByPeriod("leonardooliveira", DateTime.Now.Date, true);
        }

        [Route("undone/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetUndoneForToday()
        {
            return _repository.GetByPeriod("leonardooliveira", DateTime.Now.Date, false);
        }

        [Route("done/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForTomorrow()
        {
            return _repository.GetByPeriod("leonardooliveira", DateTime.Now.Date.AddDays(1), true);
        }

        [Route("undone/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetUndoneForTomorrow()
        {
            return _repository.GetByPeriod("leonardooliveira", DateTime.Now.Date.AddDays(1), false);
        }

        [Route("")]
        [HttpPost]
        public GenericCommandResult Create(
            [FromBody] CreateTodoCommand command
        )
        {
            command.User = "leonardooliveira";
            return (GenericCommandResult)_handler.Handle(command);
        }

        [Route("")]
        [HttpPut]
        public GenericCommandResult Update(
           [FromBody] UpdateTodoCommand command
        )
        {
            command.User = "leonardooliveira";
            return (GenericCommandResult)_handler.Handle(command);
        }

        [Route("mark-as-done")]
        [HttpPut]
        public GenericCommandResult MarkAsDone(
            [FromBody] MarkTodoAsDoneCommand command
        )
        {
            command.User = "leonardooliveira";
            return (GenericCommandResult)_handler.Handle(command);
        }

        [Route("mark-as-undone")]
        [HttpPut]
        public GenericCommandResult MarkAsUndone(
            [FromBody] MarkTodoAsUndoneCommand command
        )
        {
            command.User = "leonardooliveira";
            return (GenericCommandResult)_handler.Handle(command);
        }
    }

}