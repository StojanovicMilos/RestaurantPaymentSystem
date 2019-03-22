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
    public class CategoryControllerDeleteActionTests
    {
        [TestMethod]
        public void CategoryControllerDeleteActionGetActionRendersRightView()
        {
            //arrange
            CategoryController categoryController = ControllerFactory.GetCategoryController();
            string viewName = "Delete";
            var category = Constants.CategoriesInDatabase[0];

            //act
            ViewResult result = categoryController.Delete(category.Id) as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
        }

        [TestMethod]
        public void CategoryControllerDeleteCategoryGetCategoryExists()
        {
            //arrange
            CategoryController categoryController = ControllerFactory.GetCategoryController();
            string viewName = "Delete";
            var category = Constants.CategoriesInDatabase[0];

            //act
            ViewResult result = categoryController.Delete(category.Id) as ViewResult;
            var model = result.ViewData.Model as Category;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
            Assert.AreEqual(model, category);
        }

        [TestMethod]
        public void CategoryControllerDeleteActionGetActionCategoryDoesNotExist()
        {
            //arrange
            CategoryController categoryController = ControllerFactory.GetCategoryController();
            var category = Constants.CategoriesNotInDatabase[0];

            //act
            HttpNotFoundResult result = categoryController.Delete(category.Id) as HttpNotFoundResult;

            //assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }



        [TestMethod]
        public void CategoryControllerDeleteActionPostCategoryExists()
        {
            //arrange
            CategoryController categoryController = ControllerFactory.GetCategoryController();
            string viewName = "AllCategories";
            var category = Constants.CategoriesInDatabase[0];

            //act
            ViewResult result = categoryController.DeleteConfirmed(category.Id) as ViewResult;
            var model = (result.ViewData.Model as IEnumerable<Category>).ToList();
            
            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
            CollectionAssert.DoesNotContain(model, category);
        }

        [TestMethod]
        public void CategoryControllerDeleteActionPostCategoryDoesntExist()
        {
            //arrange
            CategoryController categoryController = ControllerFactory.GetCategoryController();
            var category = Constants.CategoriesNotInDatabase[0];

            //act
            var result = categoryController.DeleteConfirmed(category.Id) as HttpNotFoundResult;

            //assert
            Assert.IsNotNull(result);
        }
    }
}
