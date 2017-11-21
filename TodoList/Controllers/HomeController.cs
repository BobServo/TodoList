using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TodoList.Models;
using TodoList.Interfaces;
using TodoList.Repositories;

namespace TodoList.Controllers
{
    public class HomeController : Controller
    {
        ITodoRepository _todoRepository;

        public HomeController(ITodoRepository repository)
        {
            _todoRepository = repository;
        }

        public ActionResult Index()
        {
            var todos = _todoRepository.GetAllTodos();

            return View(todos);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Todo todo)
        {
            if (ModelState.IsValid)
            {
                _todoRepository.Add(todo);
                return RedirectToAction("Index");
            }

            return View(todo);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var todo = _todoRepository.GetTodoById(id);
            if (todo == null)
            {
                return View("Error");
            }

            return View(todo);
        }

        [HttpPost]
        public ActionResult Edit(Todo todo)
        {
            if (ModelState.IsValid)
            {
                _todoRepository.Save(todo);
                return RedirectToAction("Index");
            }
            return View(todo);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            { 
                return RedirectToAction("Index");
            }
            var todo = _todoRepository.GetTodoById(id);
            if (todo == null)
            {
                return View("Error");
            }

            return View(todo);
        }

        [HttpPost]
        public ActionResult Delete(Todo todo)
        {
            var success = _todoRepository.Delete(todo);

            if (!success)
            {
                return View("Error");
            }

            return RedirectToAction("Index");
        }


    }
}