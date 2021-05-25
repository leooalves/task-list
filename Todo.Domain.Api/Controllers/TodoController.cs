using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    [Authorize]
    public class TodoController : ControllerBase
    {
        private readonly TodoHandler _handler;
        private readonly ITodoRepository _repository;
        public TodoController(TodoHandler handler, ITodoRepository repository)
        {
            _handler = handler;
            _repository = repository;
        }

        private string GetUser()
        {
            return User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return _repository.GetAll(user);
        }

        [Route("done")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllDone()
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return _repository.GetAllDone(user);
        }

        [Route("undone")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllUndone()
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return _repository.GetAllUndone(user);
        }

        [Route("done/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForToday()
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return _repository.GetByPeriod(user, DateTime.Now.Date, true);
        }

        [Route("undone/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetUndoneForToday()
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return _repository.GetByPeriod(user, DateTime.Now.Date, false);
        }

        [Route("done/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForTomorrow()
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return _repository.GetByPeriod(user, DateTime.Now.Date.AddDays(1), true);
        }

        [Route("undone/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetUndoneForTomorrow()
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return _repository.GetByPeriod(user, DateTime.Now.Date.AddDays(1), false);
        }

        [Route("")]
        [HttpPost]
        public GenericCommandResult Create(
            [FromBody] CreateTodoCommand command
        )
        {
            command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value; ;
            return (GenericCommandResult)_handler.Handle(command);
        }

        [Route("")]
        [HttpPut]
        public GenericCommandResult Update(
           [FromBody] UpdateTodoCommand command
        )
        {
            command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value; ;
            return (GenericCommandResult)_handler.Handle(command);
        }

        [Route("mark-as-done")]
        [HttpPut]
        public GenericCommandResult MarkAsDone(
            [FromBody] MarkTodoAsDoneCommand command
        )
        {
            command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value; ;
            return (GenericCommandResult)_handler.Handle(command);
        }

        [Route("mark-as-undone")]
        [HttpPut]
        public GenericCommandResult MarkAsUndone(
            [FromBody] MarkTodoAsUndoneCommand command
        )
        {
            command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value; ;
            return (GenericCommandResult)_handler.Handle(command);
        }
    }

}