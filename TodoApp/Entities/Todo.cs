using TodoApp.Common;

namespace TodoApp.Entities;

public class Todo : BaseEntities
{
    public string Name { get; set; } 
    public string Description { get; set; }
}