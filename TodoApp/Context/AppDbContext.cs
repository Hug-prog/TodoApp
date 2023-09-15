using Microsoft.EntityFrameworkCore;
using TodoApp.Entities;

namespace TodoApp.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Board> Board { get; set; }
    public DbSet<Todo> Todo { get; set; }
    
}