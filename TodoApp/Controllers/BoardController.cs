using Microsoft.AspNetCore.Mvc;
using TodoApp.Common;
using TodoApp.Entities;
using TodoApp.Repositories;

namespace TodoApp.Controllers;

public class BoardController : ApiController
{
    private readonly BoardRepositories _boardRepositories;

    public BoardController(BoardRepositories boardRepositories)
    {
        _boardRepositories = boardRepositories;
    }
    
    [HttpPost]
    public async Task<ActionResult<Result<Board>>> Create(Board board)
    {
        
        return await SendResponse(await _boardRepositories.Create(board));
    }
}