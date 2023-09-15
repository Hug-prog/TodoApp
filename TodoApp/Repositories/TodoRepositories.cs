using System.Net;
using Microsoft.EntityFrameworkCore;
using TodoApp.Common;
using TodoApp.Context;
using TodoApp.Entities;

namespace TodoApp.Repositories;

public class TodoRepositories
{

    private readonly AppDbContext _context;

    public TodoRepositories(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Result<Todo>> Create(Todo todo, Guid boardId)
    {
        var board =  await _context.Board.Include(x=>x.Todos).FirstOrDefaultAsync(x => x.Id == boardId);
        await _context.AddAsync(todo);
        board.Todos.Add(todo);
        await _context.SaveChangesAsync();
        return Result<Todo>.Success("todo was created",todo,HttpStatusCode.Created);
    }

    public async Task<Result<List<Todo>>> GetAll()
    {
        return Result<List<Todo>>.Success("seccess", await _context.Todo.ToListAsync(), HttpStatusCode.OK);
    }
    
    public async Task<Result<Todo>> GetById(Guid id)
    {
        return Result<Todo>.Success("seccess", await _context.Todo.FirstOrDefaultAsync(x=>x.Id==id), HttpStatusCode.OK);
    }

    public async Task<Result<Todo>> GetById2(Guid id)
    {
        IQueryable<Todo> query = from todo in _context.Todo
            where todo.Id == id
            select todo;
        var data = await query.FirstOrDefaultAsync();
        if (data == null)
        {
            throw new Exception("dodo was not found");
        }
        return Result<Todo>.Success("seccess", data, HttpStatusCode.OK);

    }
}