using TodoApp.Common;

namespace TodoApp.Entities;

public class Board : BaseEntities
{ 
    public ICollection<Todo> Todos { get; set; }
}