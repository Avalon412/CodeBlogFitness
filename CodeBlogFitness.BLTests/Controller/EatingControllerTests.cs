using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeBlogFitness.BL.Controller;
using System;
using CodeBlogFitness.BL.Model;
using System.Linq;

namespace CodeBlogFitness.BL.Controller.Tests {
    [TestClass()]
    public class EatingControllerTests {
        [TestMethod()]
        public void AddTest() {
            //Arange
            var userName = Guid.NewGuid().ToString();
            var foodName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController(userName);
            var eatingController = new EatingController(userController.CurrentUser);
            var food = new Food(foodName, rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500));

            //Act
            eatingController.Add(food, 100.0);

            //Assert
            Assert.AreEqual(food.Name, eatingController.Eating.Foods.FirstOrDefault(fn => fn.Key.Name == food.Name).Key.Name);
        }
    }
}