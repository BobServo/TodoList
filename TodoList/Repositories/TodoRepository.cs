using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using TodoList.database;
using TodoList.Interfaces;
using TodoList.Models;

namespace TodoList.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        TodoListEntities _todoContext = new TodoListEntities();
        public bool Add(Todo todo)
        {
            try
            {
                var assignment = new Assignment();
                assignment.Description = todo.Description;
                assignment.DueDate = todo.DueDate;
                assignment.Title = todo.Title;
                _todoContext.Assignments.Add(assignment);
                _todoContext.SaveChanges();
                return true;
            }
            catch(DbUpdateException ex)
            {
                return false;
            }
 
        }

        public bool Delete(Todo todo)
        {
            try
            {
                var assingment = _todoContext.Assignments.Single(a => a.Id == todo.Id);
                _todoContext.Assignments.Remove(assingment);
                _todoContext.SaveChanges();
                return true;
            }
            catch(DbUpdateException ex)
            {
                return false;
            }
   
        }

        public IEnumerable<Todo> GetAllTodos()
        {
            var assignments = _todoContext.Assignments;

            var list = new List<Todo>();

            foreach (var a in assignments)
            {
                list.Add(new Todo() { Id = a.Id, Title = a.Title, Description = a.Description,
                    DueDate = a.DueDate });
            }

            return list;
        }

        public Todo GetTodoById(int? id)
        {
            try
            {
                var assingment = _todoContext.Assignments.Single(a => a.Id == id);

                return new Todo()
                {
                    Id = assingment.Id,
                    Description = assingment.Description,
                    Title = assingment.Title,
                    DueDate = assingment.DueDate
                };
            }
            catch(Exception ex)
            {
                return null;
            }
   
        }

        public bool Save(Todo todo)
        {
            try
            {
                var assingment = _todoContext.Assignments.Single(a => a.Id == todo.Id);

                assingment.Description = todo.Description;
                assingment.Title = todo.Title;
                assingment.DueDate = todo.DueDate;
                _todoContext.SaveChanges();
                return true;
            }
            catch (DbUpdateException ex)
            {
                return false;
            }
 
        }
    }
}