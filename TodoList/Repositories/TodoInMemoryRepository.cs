using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TodoList.Models;
using TodoList.Interfaces;

namespace TodoList.Repositories
{
    public class TodoInMemoryRepository : ITodoRepository
    {
        private List<Todo> _todos;

        public TodoInMemoryRepository()
        {
            _todos = new List<Todo>() {
                new Todo { Id=0, Description="Something to do 0", Title="Todo 0", DueDate= new DateTime(2017,12,10)},
                new Todo { Id=1, Description="Something to do 1", Title="Todo 1", DueDate= new DateTime(2017,12,11)},
                new Todo { Id=2, Description="Something to do 2", Title="Todo 2", DueDate= new DateTime(2017,12,12)},
                new Todo { Id=3, Description="Something to do 3", Title="Todo 3", DueDate= new DateTime(2017,12,13)},
                new Todo { Id=4, Description="Something to do 4", Title="Todo 4", DueDate= new DateTime(2017,12,14)}
            };


        }

        public IEnumerable<Todo> GetAllTodos()
        {
            return _todos;
        }

        public Todo GetTodoById(int? id)
        {
            var todo = _todos.Find(t => t.Id == id);

            return todo;
        }

        public bool Add(Todo todo)
        {
            _todos.Add(todo);
            return true;
        }

        public bool Save(Todo todo)
        {
            var toEdit = _todos.Find(t => t.Id == todo.Id);

            toEdit.Description = todo.Description;
            toEdit.Title = todo.Title;
            toEdit.DueDate = todo.DueDate;

            return true;
        }

        public bool Delete(Todo todo)
        {
            var toDelete = _todos.Find(t => t.Id == todo.Id);
            _todos.Remove(toDelete);

            return true;
        }
    }
}