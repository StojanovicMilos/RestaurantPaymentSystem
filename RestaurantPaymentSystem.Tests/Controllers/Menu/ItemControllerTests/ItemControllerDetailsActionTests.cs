using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantPaymentSystem.Controllers.Menu;
using RestaurantPaymentSystem.Tests.Controllers.Shared;
using RestaurantPaymentSystem.Tests.DB;

namespace RestaurantPaymentSystem.Tests.Controllers.Menu.ItemControllerTests
{
    [TestClass]
    public class ItemControllerDetailsActionTests
    {
        private ItemController _controller;

        [TestInitialize]
        public void TestInitialize()
        {
            _controller = ControllerFactory.GetItemController();
        }

        [TestMethod]
        public void ItemControllerDetailsActionGetActionRendersRightView()
        {
            //arrange
            const string viewName = "Details";
            var item = Constants.ItemsInDatabase[0];

            //act
            ViewResult result = _controller.Details(item.Id) as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
        }

        [TestMethod]
        public void ItemControllerDetailsActionModelDoesntExist()
        {
            //arrange
            var item = Constants.ItemsNotInDatabase[0];

            //act
            HttpNotFoundResult result = _controller.Details(item.Id) as HttpNotFoundResult;

            //assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }
    }
}
