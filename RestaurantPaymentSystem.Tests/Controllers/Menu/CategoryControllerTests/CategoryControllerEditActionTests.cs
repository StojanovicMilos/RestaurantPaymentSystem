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
    public class CategoryControllerEditActionTests
    {
        private CategoryController _categoryController;

        [TestInitialize]
        public void TestInitialize()
        {
            _categoryController = ControllerFactory.GetCategoryController();
        }

        [TestMethod]
        public void CategoryControllerEditCategoryGetActionRendersRightView()
        {
            //arrange
            const string viewName = "Edit";
            var category = Constants.CategoriesInDatabase[0];

            //act
            ViewResult result = _categoryController.Edit(category.Id) as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
        }

        [TestMethod]
        public void CategoryControllerEditCategoryGetActionCategoryDoesntExist()
        {
            //arrange
            var category = Constants.CategoriesNotInDatabase[0];

            //act
            HttpNotFoundResult result = _categoryController.Edit(category.Id) as HttpNotFoundResult;

            //assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }

        [TestMethod]
        public void CategoryControllerEditCategoryPostCategoryDoesntExist()
        {
            //arrange
            const string viewName = "AllCategories";
            var category = Constants.CategoriesNotInDatabase[0];

            //act
            ViewResult result = _categoryController.Edit(category) as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
        }

        [TestMethod]
        public void CategoryControllerEditCategoryPostCategoryExists()
        {
            //arrange
            const string viewName = "AllCategories";
            var category = Constants.CategoriesInDatabase[0];

            //act
            ViewResult result = _categoryController.Edit(category) as ViewResult;
            Assert.IsNotNull(result);
            var model = (result.ViewData.Model as IEnumerable<Category>).ToList();
            
            //assert
            Assert.AreEqual(viewName, result.ViewName);
            CollectionAssert.Contains(model, category);
        }
    }
}
