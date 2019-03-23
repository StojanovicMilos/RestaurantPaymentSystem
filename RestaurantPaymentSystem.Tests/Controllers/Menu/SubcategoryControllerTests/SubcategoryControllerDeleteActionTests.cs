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
    public class SubcategoryControllerDeleteActionTests
    {
        private SubcategoryController _subcategoryController;

        [TestInitialize]
        public void TestInitialize()
        {
            this._subcategoryController = ControllerFactory.GetSubcategoryController();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this._subcategoryController.Dispose();
        }

        [TestMethod]
        public void SubcategoryControllerDeleteActionGetActionRendersRightView()
        {
            //arrange
            const string viewName = "Delete";
            var itemName = Constants.SubcategoriesInDatabase[0];

            //act
            ViewResult result = _subcategoryController.Delete(itemName.Id) as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
        }

        [TestMethod]
        public void SubcategoryControllerDeleteActionGetActionItemExists()
        {
            //arrange
            const string viewName = "Delete";
            var subCategory = Constants.SubcategoriesInDatabase[0];

            //act
            ViewResult result = _subcategoryController.Delete(subCategory.Id) as ViewResult;
            var model = result.ViewData.Model as Subcategory;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
            Assert.AreEqual(model, subCategory);
        }

        [TestMethod]
        public void SubcategoryControllerDeleteActionGetActionItemDoesNotExist()
        {
            //arrange
            var subcategory = Constants.SubcategoriesNotInDatabase[0];

            //act
            HttpNotFoundResult result = _subcategoryController.Delete(subcategory.Id) as HttpNotFoundResult;

            //assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }



        [TestMethod]
        public void SubcategoryControllerDeleteActionPostItemExists()
        {
            //arrange
            const string viewName = "AllSubcategories";
            var subcategory = Constants.SubcategoriesInDatabase[1];

            //act
            ViewResult result = _subcategoryController.DeleteConfirmed(subcategory.Id) as ViewResult;
            Assert.IsNotNull(result);
            var model = (result.ViewData.Model as IEnumerable<Category>).ToList();

            //assert
            Assert.AreEqual(viewName, result.ViewName);
            CollectionAssert.DoesNotContain(model, subcategory);
        }

        [TestMethod]
        public void SubcategoryControllerDeleteActionPostCategoryDoesntExist()
        {
            //arrange
            var subCategory = Constants.SubcategoriesNotInDatabase[0];

            //act
            var result = _subcategoryController.DeleteConfirmed(subCategory.Id) as HttpNotFoundResult;

            //assert
            Assert.IsNotNull(result);
            //assert
        }
    }
}