using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantPaymentSystem.Controllers.Menu;
using RestaurantPaymentSystem.Models;
using RestaurantPaymentSystem.Tests.Controllers.Shared;
using RestaurantPaymentSystem.Tests.DB;

namespace RestaurantPaymentSystem.Tests.Controllers.Menu.SubcategoryControllerTests
{
	[TestClass]
    public class SubcategoryControllerAllSubcategoriesActionTests
    {
        private SubcategoryController _subcategoryController;

        [TestInitialize]
        public void TestInitialize()
        {
            _subcategoryController = ControllerFactory.GetSubcategoryController();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _subcategoryController.Dispose();
        }

        [TestMethod]
        public void SubcategoryControllerAllSubcategoriesActionRendersRightView()
        {
            //arrange
            string viewName = "AllSubcategories";

            //act
            ViewResult result = _subcategoryController.AllSubcategories() as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
        }

        [TestMethod]
        public void SubcategoryControllerAllSubcategoriesActionHasCategories()
        {
            //arrange
            var category0 = Constants.CategoriesInDatabase[0];
            var category1 = Constants.CategoriesInDatabase[1];
            var category2 = Constants.CategoriesInDatabase[2];

            //act
            ViewResult result = _subcategoryController.AllSubcategories() as ViewResult;

            //assert

            Assert.IsNotNull(result);
            var model = (result.ViewData.Model as IEnumerable<Category>).ToList();
            CollectionAssert.Contains(model, category0);
            CollectionAssert.Contains(model, category1);
            CollectionAssert.Contains(model, category2);
        }
    }
}
