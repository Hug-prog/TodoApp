using Microsoft.AspNetCore.Mvc;

namespace TodoApp.Common;

[ApiController, Route("[controller]")]
public class ApiController: ControllerBase
{
    public Task<ActionResult<Result<T>>> SendResponse<T>(Result<T> data)
    {
        return Task.FromResult<ActionResult<Result<T>>>(
            StatusCode((int)data.StatusCode, data)
        );
    }
}