using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantPaymentSystem.Controllers.Menu;
using RestaurantPaymentSystem.Models;
using RestaurantPaymentSystem.Tests.DB;

namespace RestaurantPaymentSystem.Tests.Controllers.Menu.CategoryControllerTests
{

	[TestClass]
    public class CategoryControllerAllCategoriesActionTests
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
        public void CategoryControllerAllCategoriesActionRendersRightView()
        {
            //arrange
            const string viewName = "AllCategories";

            //act
            ViewResult result = _categoryController.AllCategories() as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
        }

        [TestMethod]
        public void CategoryControllerAllCategoriesActionHasCategories()
        {
            //arrange
            var category0 = Constants.CategoriesInDatabase[0];
            var category1 = Constants.CategoriesInDatabase[1];
            var category2 = Constants.CategoriesInDatabase[2];

            //act
            ViewResult result = _categoryController.AllCategories() as ViewResult;

            //assert
            Debug.Assert(result != null, nameof(result) + " != null");
            var model = (result.ViewData.Model as IEnumerable<Category>).ToList();
            CollectionAssert.Contains(model, category0);
            CollectionAssert.Contains(model, category1);
            CollectionAssert.Contains(model, category2);
        }
    }
}
