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
    public class ItemControllerEditActionTests
    {
        private ItemController _controller;

        [TestInitialize]
        public void TestInitialize()
        {
            _controller = ControllerFactory.GetItemController();
        }

        [TestMethod]
        public void ItemControllerEditItemGetActionRendersRightView()
        {
            //arrange
            const string viewName = "Edit";
            var item = Constants.ItemsInDatabase[0];

            //act
            ViewResult result = _controller.Edit(item.Id) as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
        }

        [TestMethod]
        public void ItemControllerEditItemGetActionItemDoesntExist()
        {
            //arrange
            var item = Constants.ItemsNotInDatabase[0];

            //act
            HttpNotFoundResult result = _controller.Edit(item.Id) as HttpNotFoundResult;

            //assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }

        [TestMethod]
        public void ItemControllerEditItemPostItemDoesntExist()
        {
            //arrange
            const string viewName = "AllItems";
            var item = Constants.ItemsNotInDatabase[0];

            //act
            ViewResult result = _controller.Edit(item) as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
        }

        [TestMethod]
        public void ItemControllerEditItemPostItemExists()
        {
            //arrange
            const string viewName = "AllItems";
            var item = Constants.ItemsInDatabase[0];

            //act
            ViewResult result = _controller.Edit(item) as ViewResult;
            Assert.IsNotNull(result);
            var model = (result.ViewData.Model as IEnumerable<Category>).ToList();
            var allItems = model.SelectMany(c => c.Subcategories).SelectMany(s => s.Items).ToList();

            //assert
            Assert.AreEqual(viewName, result.ViewName);
            CollectionAssert.Contains(allItems, item);
        }
    }
}
