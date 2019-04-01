using System.Collections.Generic;
using System.Diagnostics;
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
    public class ItemControllerDeleteActionTests
    {
        private ItemController _controller;

        [TestInitialize]
        public void TestInitialize()
        {
            _controller = ControllerFactory.GetItemController();
        }

        [TestMethod]
        public void ItemControllerDeleteActionGetActionRendersRightView()
        {
            //arrange
            const string viewName = "Delete";
            var item = Constants.ItemsInDatabase[0];

            //act
            ViewResult result = _controller.Delete(item.Id) as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
        }

        [TestMethod]
        public void ItemControllerDeleteItemGetItemExists()
        {
            //arrange
            const string viewName = "Delete";
            var item = Constants.ItemsInDatabase[0];

            //act
            ViewResult result = _controller.Delete(item.Id) as ViewResult;
            Assert.IsNotNull(result);
            var model = result.ViewData.Model as Item;

            //assert
            Assert.AreEqual(viewName, result.ViewName);
            Assert.AreEqual(model, item);
        }

        [TestMethod]
        public void ItemControllerDeleteActionGetActionItemDoesNotExist()
        {
            //arrange
            var item = Constants.ItemsNotInDatabase[0];

            //act
            HttpNotFoundResult result = _controller.Delete(item.Id) as HttpNotFoundResult;

            //assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }



        [TestMethod]
        public void ItemControllerDeleteActionPostItemExists()
        {
            //arrange
            const string viewName = "AllItems";
            var item = Constants.ItemsInDatabase[1];

            //act
            ViewResult result = _controller.DeleteConfirmed(item.Id) as ViewResult;
            Assert.IsNotNull(result);
            var model = (result.ViewData.Model as IEnumerable<Category>).ToList();
            var allItems = model.SelectMany(c => c.Subcategories).SelectMany(s => s.Items).ToList();

            //assert
            Assert.AreEqual(viewName, result.ViewName);
            CollectionAssert.DoesNotContain(allItems, item);
        }

        [TestMethod]
        public void ItemControllerDeleteActionPostItemDoesntExist()
        {
            //arrange
            var item = Constants.ItemsNotInDatabase[0];

            //act
            var result = _controller.DeleteConfirmed(item.Id) as HttpNotFoundResult;

            //assert
            Assert.IsNotNull(result);
        }
    }
}
