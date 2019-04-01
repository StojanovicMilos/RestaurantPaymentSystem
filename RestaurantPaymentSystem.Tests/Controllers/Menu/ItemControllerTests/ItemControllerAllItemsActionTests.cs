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
    public class ItemControllerAllItemsActionTests
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
        public void ItemControllerAllItemsActionRendersRightView()
        {
            //arrange
            const string viewName = "AllItems";

            //act
            ViewResult result = _controller.AllItems() as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
        }

        [TestMethod]
        public void ItemControllerAllItemsActionHasCategories()
        {
            //arrange
            var category0 = Constants.CategoriesInDatabase[0];
            var category1 = Constants.CategoriesInDatabase[1];
            var category2 = Constants.CategoriesInDatabase[2];

            //act
            ViewResult result = _controller.AllItems() as ViewResult;

            //assert
            Debug.Assert(result != null, nameof(result) + " != null");
            var model = (result.ViewData.Model as IEnumerable<Category>).ToList();
            CollectionAssert.Contains(model, category0);
            CollectionAssert.Contains(model, category1);
            CollectionAssert.Contains(model, category2);
        }
    }
}
