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
    public class CategoryControllerCreateActionTests
    {
        private CategoryController _categoryController;

        [TestInitialize]
        public void TestInitialize()
        {
            _categoryController = ControllerFactory.GetCategoryController();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _categoryController.Dispose();
        }

        [TestMethod]
        public void CategoryControllerCreateActionGetActionRendersRightView()
        {
            //arrange
            const string viewName = "Create";

            //act
            ViewResult result = _categoryController.Create() as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
        }

        [TestMethod]
        public void CategoryControllerCreateActionPostModelStateInvalid()
        {
            //arrange
            const string viewName = "Create";
            _categoryController.ModelState.AddModelError("test", "test");
            var category = Constants.CategoriesNotInDatabase[0];

            //act
            ViewResult result = _categoryController.Create(category) as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
        }

        [TestMethod]
        public void CategoryControllerCreateActionPostModelStateValid()
        {
            //arrange
            const string viewName = "AllCategories";
            var category = Constants.CategoriesNotInDatabase[0];

            //act
            ViewResult result = _categoryController.Create(category) as ViewResult;
            
            //assert
            Assert.IsNotNull(result);
            var model = (result.ViewData.Model as IEnumerable<Category>).ToList();
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
            CollectionAssert.Contains(model, category);
        }
    }
}
