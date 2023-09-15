using Microsoft.AspNetCore.Mvc;
using TodoApp.Common;
using TodoApp.Entities;
using TodoApp.Repositories;

namespace TodoApp.Controllers;

public class TodoController : ApiController
{
    // add instance of class 
    private readonly TodoRepositories _todoRepositories;

    public TodoController(TodoRepositories todoRepositories)
    {
        _todoRepositories = todoRepositories;
    }
    
    [HttpPost ("{boardId}")]
    public async Task<ActionResult<Result<Todo>>> Create(Todo todo,Guid boardId)
    {
        
        return await SendResponse(await _todoRepositories.Create(todo,boardId));
    }
    
    [HttpGet]
    public async Task<ActionResult<Result<List<Todo>>>> GetAll()
    {
        
        return await SendResponse(await _todoRepositories.GetAll());
    }
    [HttpGet ("{id}")]
    public async Task<ActionResult<Result<Todo>>> GetById(Guid id)
    {
        
        return await SendResponse(await _todoRepositories.GetById(id));
    }
}