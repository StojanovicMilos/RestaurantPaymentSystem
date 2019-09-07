using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantPaymentSystem.Controllers.Menu;
using RestaurantPaymentSystem.Models;
using RestaurantPaymentSystem.Tests.Controllers.Shared;
using RestaurantPaymentSystem.Tests.DB;

namespace RestaurantPaymentSystem.Tests.Controllers.Menu.CategoryControllerTests
{
    
    [TestClass]
    public class CategoryControllerDeleteActionTests
    {
        private CategoryController _categoryController;

        [TestInitialize]
        public void TestInitialize()
        {
            _categoryController = ControllerFactory.GetCategoryController();
        }

        [TestMethod]
        public void CategoryControllerDeleteActionGetActionRendersRightView()
        {
            //arrange
            const string viewName = "Delete";
            var category = Constants.CategoriesInDatabase[0];

            //act
            ViewResult result = _categoryController.Delete(category.Id) as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
        }

        [TestMethod]
        public void CategoryControllerDeleteCategoryGetCategoryExists()
        {
            //arrange
            const string viewName = "Delete";
            var category = Constants.CategoriesInDatabase[0];

            //act
            ViewResult result = _categoryController.Delete(category.Id) as ViewResult;
            Assert.IsNotNull(result);
            var model = result.ViewData.Model as Category;
            
            //assert
            Assert.AreEqual(viewName, result.ViewName);
            Assert.AreEqual(model, category);
        }

        [TestMethod]
        public void CategoryControllerDeleteActionGetActionCategoryDoesNotExist()
        {
            //arrange
            var category = Constants.CategoriesNotInDatabase[0];

            //act
            HttpNotFoundResult result = _categoryController.Delete(category.Id) as HttpNotFoundResult;

            //assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }



        [TestMethod]
        public void CategoryControllerDeleteActionPostCategoryExists()
        {
            //arrange
            const string viewName = "AllCategories";
            var category = Constants.CategoriesInDatabase[1];

            //act
            ViewResult result = _categoryController.DeleteConfirmed(category.Id) as ViewResult;
            Assert.IsNotNull(result);
            var model = (result.ViewData.Model as IEnumerable<Category>).ToList();
            
            //assert
            Assert.AreEqual(viewName, result.ViewName);
            CollectionAssert.DoesNotContain(model, category);
        }

        [TestMethod]
        public void CategoryControllerDeleteActionPostCategoryDoesntExist()
        {
            //arrange
            var category = Constants.CategoriesNotInDatabase[0];

            //act
            var result = _categoryController.DeleteConfirmed(category.Id) as HttpNotFoundResult;

            //assert
            Assert.IsNotNull(result);
        }
    }
}
