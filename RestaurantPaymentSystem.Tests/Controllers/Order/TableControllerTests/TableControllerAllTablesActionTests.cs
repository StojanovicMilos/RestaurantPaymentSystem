using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantPaymentSystem.Controllers;
using RestaurantPaymentSystem.Models;
using RestaurantPaymentSystem.Tests.DB;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace RestaurantPaymentSystem.Tests.Controllers.TableControllerTests
{
    [TestClass]
    public class TableControllerAllTablesActionTests
    {
        private TableController tableController;

        [TestInitialize]
        public void TestInitialize()
        {
            this.tableController = ControllerFactory.GetTableController();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.tableController.Dispose();
        }

        [TestMethod]
        public void TableControllerAllTablesActionRendersRightView()
        {
            //arrange
            string viewName = "AllTables";

            //act
            ViewResult result = tableController.AllTables() as ViewResult;

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
            ViewResult result = tableController.AllTables() as ViewResult;

            //assert
            var model = (result.ViewData.Model as IEnumerable<Table>).ToList();
            CollectionAssert.Contains(model, table0);
            CollectionAssert.Contains(model, table1);
            CollectionAssert.Contains(model, table2);
        }
    }
}
