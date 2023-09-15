using Microsoft.EntityFrameworkCore;
using TodoApp.Context;

namespace TodoApp.Extensions;

public static class DatabaseExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddDbContextPool<AppDbContext>(option => option.UseMySql(
            configuration["ConnectionString:DefaultConnection"],
            new MariaDbServerVersion(new Version(11,1,2))
        ));

    }
}