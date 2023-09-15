using System.Net;
using TodoApp.Common;
using TodoApp.Context;
using TodoApp.Entities;


namespace TodoApp.Repositories;

public class BoardRepositories
{
    private readonly AppDbContext _context;

    public BoardRepositories(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Result<Board>> Create(Board board)
    {
        await _context.AddAsync(board);
        await _context.SaveChangesAsync();
        return Result<Board>.Success("board was created",board,HttpStatusCode.Created);
    }
}