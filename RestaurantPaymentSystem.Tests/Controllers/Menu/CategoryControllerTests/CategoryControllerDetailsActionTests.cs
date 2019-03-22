using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantPaymentSystem.Controllers.Menu;
using RestaurantPaymentSystem.Tests.DB;

namespace RestaurantPaymentSystem.Tests.Controllers.Menu.CategoryControllerTests
{
    [TestClass]
    public class CategoryControllerDetailsActionTests
    {
        private CategoryController _categoryController;

        [TestInitialize]
        public void TestInitialize()
        {
            _categoryController = ControllerFactory.GetCategoryController();
        }

        [TestMethod]
        public void CategoryControllerDetailsActionGetActionRendersRightView()
        {
            //arrange
            const string viewName = "Details";
            var category = Constants.CategoriesInDatabase[0];

            //act
            ViewResult result = _categoryController.Details(category.Id) as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
        }

        [TestMethod]
        public void CategoryControllerDetailsActionModelDoesntExist()
        {
            //arrange
            var category = Constants.CategoriesNotInDatabase[0];

            //act
            HttpNotFoundResult result = _categoryController.Details(category.Id) as HttpNotFoundResult;
            
            //assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }
    }
}
