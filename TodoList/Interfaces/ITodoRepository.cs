using System.Collections.Generic;
using System.Linq;
using TodoList.Models;

namespace TodoList.Interfaces
{
    public interface ITodoRepository
    {
        bool Add(Todo todo);
        bool Delete(Todo todo);
        IEnumerable<Todo> GetAllTodos();
        Todo GetTodoById(int? id);
        bool Save(Todo todo);
    }
}