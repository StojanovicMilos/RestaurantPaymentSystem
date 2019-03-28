using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantPaymentSystem.Controllers.Menu;
using RestaurantPaymentSystem.Models;
using RestaurantPaymentSystem.Tests.DB;

namespace RestaurantPaymentSystem.Tests.Controllers.Menu.SubcategoryControllerTests
{
    [TestClass]
    public class SubcategoryControllerEditActionTests
    {
        private SubcategoryController _subcategoryController;

        [TestInitialize]
        public void TestInitialize()
        {
            _subcategoryController = ControllerFactory.GetSubcategoryController();
        }

        [TestMethod]
        public void SubcategoryControllerEditSubcategoryGetActionRendersRightView()
        {
            //arrange
            const string viewName = "Edit";
            var subcategory = Constants.SubcategoriesInDatabase[0];

            //act
            ViewResult result = _subcategoryController.Edit(subcategory.Id) as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
        }

        [TestMethod]
        public void SubcategoryControllerEditSubcategoryGetActionSubcategoryDoesntExist()
        {
            //arrange
            var subcategory = Constants.SubcategoriesNotInDatabase[0];

            //act
            HttpNotFoundResult result = _subcategoryController.Edit(subcategory.Id) as HttpNotFoundResult;

            //assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }

        [TestMethod]
        public void SubcategoryControllerEditSubcategoryPostSubcategoryDoesntExist()
        {
            //arrange
            const string viewName = "AllSubcategories";
            var subcategory = Constants.SubcategoriesNotInDatabase[0];

            //act
            ViewResult result = _subcategoryController.Edit(subcategory) as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
        }

        [TestMethod]
        public void SubcategoryControllerEditSubcategoryPostSubcategoryExists()
        {
            //arrange
            const string viewName = "AllSubcategories";
            var subcategory = Constants.SubcategoriesInDatabase[0];

            //act
            ViewResult result = _subcategoryController.Edit(subcategory) as ViewResult;
            Assert.IsNotNull(result);
            var model = (result.ViewData.Model as IEnumerable<Category>).ToList();
            
            //assert
            Assert.AreEqual(viewName, result.ViewName);
            CollectionAssert.Contains(model[0].Subcategories, subcategory);
        }
    }
}
