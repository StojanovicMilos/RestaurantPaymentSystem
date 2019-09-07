using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantPaymentSystem.Controllers;
using RestaurantPaymentSystem.Models;
using RestaurantPaymentSystem.Tests.Controllers.Shared;
using RestaurantPaymentSystem.Tests.DB;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace RestaurantPaymentSystem.Tests.Controllers.Order.TableControllerTests
{
    [TestClass]
    public class TableControllerAllTablesActionTests
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
        public void TableControllerAllTablesActionRendersRightView()
        {
            //arrange
            string viewName = "AllTables";

            //act
            ViewResult result = _controller.AllTables() as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
        }

        [TestMethod]
        public void TableControllerAllTablesActionHasTables()
        {
            //arrange
            var table0 = Constants.TablesInDatabase[0];
            var table1 = Constants.TablesInDatabase[1];
            var table2 = Constants.TablesInDatabase[2];

            //act
            ViewResult result = _controller.AllTables() as ViewResult;

            //assert
            var model = (result.ViewData.Model as IEnumerable<Table>).ToList();
            CollectionAssert.Contains(model, table0);
            CollectionAssert.Contains(model, table1);
            CollectionAssert.Contains(model, table2);
        }
    }
}
