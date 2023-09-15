using TodoApp.Repositories;

namespace TodoApp.Extensions;

public static class RepositoriesExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services.AddScoped<TodoRepositories>().AddScoped<BoardRepositories>();
    }
}