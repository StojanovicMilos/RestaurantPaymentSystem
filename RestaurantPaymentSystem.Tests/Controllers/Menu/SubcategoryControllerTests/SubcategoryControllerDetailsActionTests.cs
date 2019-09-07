using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantPaymentSystem.Controllers.Menu;
using RestaurantPaymentSystem.Tests.Controllers.Shared;
using RestaurantPaymentSystem.Tests.DB;

namespace RestaurantPaymentSystem.Tests.Controllers.Menu.SubcategoryControllerTests
{
    [TestClass]
    public class SubcategoryControllerDetailsActionTests
    {
        private SubcategoryController _subcategoryController;

        [TestInitialize]
        public void TestInitialize()
        {
            _subcategoryController = ControllerFactory.GetSubcategoryController();
        }

        [TestMethod]
        public void SubcategoryControllerDetailsActionGetActionRendersRightView()
        {
            //arrange
            const string viewName = "Details";
            var subcategory = Constants.SubcategoriesInDatabase[0];

            //act
            ViewResult result = _subcategoryController.Details(subcategory.Id) as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
        }

        [TestMethod]
        public void SubcategoryControllerDetailsActionModelDoesntExist()
        {
            //arrange
            var subcategory = Constants.SubcategoriesNotInDatabase[0];

            //act
            HttpNotFoundResult result = _subcategoryController.Details(subcategory.Id) as HttpNotFoundResult;
            
            //assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }
    }
}
