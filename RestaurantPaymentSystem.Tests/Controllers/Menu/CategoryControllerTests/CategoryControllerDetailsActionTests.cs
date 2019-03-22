using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantPaymentSystem.Controllers;
using RestaurantPaymentSystem.Models;
using RestaurantPaymentSystem.Tests.DB;
using System.Web.Mvc;
using RestaurantPaymentSystem.Controllers.Menu;

namespace RestaurantPaymentSystem.Tests.Controllers.CategoryControllerTests
{
    [TestClass]
    public class CategoryControllerDetailsActionTests
    {
        [TestMethod]
        public void CategoryControllerDetailsActionGetActionRendersRightView()
        {
            //arrange
            CategoryController categoryController = ControllerFactory.GetCategoryController();
            string viewName = "Details";
            var category = Constants.CategoriesInDatabase[0];

            //act
            ViewResult result = categoryController.Details(category.Id) as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
        }

        [TestMethod]
        public void CategoryControllerDetailsActionModelDoesntExist()
        {
            //arrange
            CategoryController categoryController = ControllerFactory.GetCategoryController();
            var category = Constants.CategoriesNotInDatabase[0];

            //act
            HttpNotFoundResult result = categoryController.Details(category.Id) as HttpNotFoundResult;
            
            //assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }
    }
}
