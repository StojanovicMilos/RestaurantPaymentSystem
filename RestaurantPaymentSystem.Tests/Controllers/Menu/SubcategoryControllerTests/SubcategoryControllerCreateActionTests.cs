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
    /// <summary>
    /// Summary description for SubcategoryControllerCreateActionTests
    /// </summary>
    [TestClass]
    public class SubcategoryControllerCreateActionTests
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
            this._subcategoryController.Dispose();
        }

        [TestMethod]
        public void SubcategoryControllerCreateActionGetActionRendersRightView()
        {
            //arrange
            const string viewName = "Create";
            const int categoryId = 1;

            //act
            ViewResult result = _subcategoryController.Create(categoryId) as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
        }

        [TestMethod]
        public void SubcategoryControllerCreateActionPostModelStateInvalid()
        {
            //arrange
            const string viewName = "Create";
            _subcategoryController.ModelState.AddModelError("test", "test");
            var subcategoryModel = Constants.SubcategoriesNotInDatabase[0];

            //act
            ViewResult result = _subcategoryController.Create(subcategoryModel) as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
        }

        [TestMethod]
        public void SubcategoryControllerCreateActionPostModelStateValid()
        {
            //arrange
            string viewName = "AllSubcategories";
            var subcategoryModel = Constants.SubcategoriesNotInDatabase[0];

            //act
            ViewResult result = _subcategoryController.Create(subcategoryModel) as ViewResult;

            //assert
            Assert.IsNotNull(result);
            var model = (result.ViewData.Model as IEnumerable<Category>).ToList();
            var allSubcategories = model.SelectMany(c => c.Subcategories);

            Assert.AreEqual(viewName, result.ViewName);
            Assert.IsTrue(allSubcategories.Contains(subcategoryModel));
        }
    }
}
