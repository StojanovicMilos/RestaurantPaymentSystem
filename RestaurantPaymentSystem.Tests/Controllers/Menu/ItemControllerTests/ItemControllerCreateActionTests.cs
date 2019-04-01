using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantPaymentSystem.Controllers.Menu;
using RestaurantPaymentSystem.Models;
using RestaurantPaymentSystem.Tests.Controllers.Shared;
using RestaurantPaymentSystem.Tests.DB;

namespace RestaurantPaymentSystem.Tests.Controllers.Menu.ItemControllerTests
{
    [TestClass]
    public class ItemControllerCreateActionTests
    {
        private ItemController _controller;

        [TestInitialize]
        public void TestInitialize()
        {
            _controller = ControllerFactory.GetItemController();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _controller.Dispose();
        }

        [TestMethod]
        public void ItemControllerCreateActionGetActionRendersRightView()
        {
            //arrange
            const string viewName = "Create";
            const int subcategoryId = 1;

            //act
            ViewResult result = _controller.Create(subcategoryId) as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
        }

        [TestMethod]
        public void ItemControllerCreateActionPostModelStateInvalid()
        {
            //arrange
            const string viewName = "Create";
            _controller.ModelState.AddModelError("test", "test");
            var item = Constants.ItemsNotInDatabase[0];

            //act
            ViewResult result = _controller.Create(item) as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
        }

        [TestMethod]
        public void ItemControllerCreateActionPostModelStateValid()
        {
            //arrange
            const string viewName = "AllItems";
            var item = Constants.ItemsNotInDatabase[0];

            //act
            ViewResult result = _controller.Create(item) as ViewResult;

            //assert
            Assert.IsNotNull(result);
            var model = (result.ViewData.Model as IEnumerable<Category>).ToList();
            var allItems = model.SelectMany(c => c.Subcategories).SelectMany(s => s.Items).ToList();

            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
            CollectionAssert.Contains(allItems, item);
        }
    }
}
