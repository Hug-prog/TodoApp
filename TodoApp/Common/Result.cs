using System.Net;

namespace TodoApp.Common;

public class  Result<T>
{
    public string Message { get; set; }
    public T Data { get; set; }
    public HttpStatusCode StatusCode { get; set; }

    public static Result<T> Success(string message,T data,HttpStatusCode statusCode)
    {
        return new Result<T> { Message = message, Data = data, StatusCode = statusCode };
    }
}