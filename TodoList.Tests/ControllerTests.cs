using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TodoList.Controllers;
using TodoList.Repositories;
using System.Web.Mvc;
using System.Collections.Generic;
using TodoList.Models;

namespace TodoList.Tests
{
    [TestClass]
    public class ControllerTests
    {
        HomeController homeController;

        [TestInitialize]
        public void Initialize()
        {
            var repository = new TodoInMemoryRepository();
            homeController = new HomeController(repository);
        }

        [TestMethod]
        public void IndexControllerTest()
        {
            var viewResult = homeController.Index() as ViewResult;

            var model = viewResult.ViewData.Model as List<Todo>;

            Assert.IsTrue(model.Count > 0);
        }
    }
}
