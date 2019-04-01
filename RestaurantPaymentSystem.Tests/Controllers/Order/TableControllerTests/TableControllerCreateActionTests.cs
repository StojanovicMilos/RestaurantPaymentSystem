using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantPaymentSystem.Controllers;
using RestaurantPaymentSystem.Models;
using RestaurantPaymentSystem.Tests.Controllers.Shared;
using RestaurantPaymentSystem.Tests.DB;

namespace RestaurantPaymentSystem.Tests.Controllers.Order.TableControllerTests
{
    [TestClass]
    public class TableControllerCreateActionTests
    {
        private TableController _controller;

        [TestInitialize]
        public void TestInitialize()
        {
            this._controller = ControllerFactory.GetTableController();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this._controller.Dispose();
        }

        [TestMethod]
        public void TableControllerCreateActionGetActionRendersRightView()
        {
            //arrange
            string viewName = "Create";

            //act
            ViewResult result = _controller.Create() as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
        }

        [TestMethod]
        public void TableControllerCreateActionPostModelStateInvalid()
        {
            //arrange
            string viewName = "Create";
            _controller.ModelState.AddModelError("test", "test");
            var table = Constants.TablesNotInDatabase[0];

            //act
            ViewResult result = _controller.Create(table) as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
        }

        [TestMethod]
        public void TableControllerCreateActionPostModelStateValid()
        {
            //arrange
            string viewName = "AllTables";
            var table = Constants.TablesNotInDatabase[0];

            //act
            ViewResult result = _controller.Create(table) as ViewResult;
            var model = (result.ViewData.Model as IEnumerable<Table>).ToList();
            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
            CollectionAssert.Contains(model, table);
        }
    }
}
