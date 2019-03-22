using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantPaymentSystem.Controllers;
using RestaurantPaymentSystem.Models;
using RestaurantPaymentSystem.Tests.DB;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using RestaurantPaymentSystem.Controllers.Menu;

namespace RestaurantPaymentSystem.Tests.Controllers.CategoryControllerTests
{
    [TestClass]
    public class CategoryControllerEditActionTests
    {
        [TestMethod]
        public void CategoryControllerEditCategoryGetActionRendersRightView()
        {
            //arrange
            CategoryController categoryController = ControllerFactory.GetCategoryController();
            string viewName = "Edit";
            var category = Constants.CategoriesInDatabase[0];

            //act
            ViewResult result = categoryController.Edit(category.Id) as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
        }

        [TestMethod]
        public void CategoryControllerEditCategoryGetActionCategoryDoesntExist()
        {
            //arrange
            CategoryController categoryController = ControllerFactory.GetCategoryController();
            var category = Constants.CategoriesNotInDatabase[0];

            //act
            HttpNotFoundResult result = categoryController.Edit(category.Id) as HttpNotFoundResult;

            //assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }

        [TestMethod]
        public void CategoryControllerEditCategoryPostCategoryDoesntExist()
        {
            //arrange
            CategoryController categoryController = ControllerFactory.GetCategoryController();
            string viewName = "AllCategories";
            var category = Constants.CategoriesNotInDatabase[0];

            //act
            ViewResult result = categoryController.Edit(category) as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
        }

        [TestMethod]
        public void CategoryControllerEditCategoryPostCategoryExists()
        {
            //arrange
            CategoryController categoryController = ControllerFactory.GetCategoryController();
            string viewName = "AllCategories";
            var category = Constants.CategoriesInDatabase[0];

            //act
            ViewResult result = categoryController.Edit(category) as ViewResult;
            var model = (result.ViewData.Model as IEnumerable<Category>).ToList();
            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
            CollectionAssert.Contains(model, category);
        }
    }
}
