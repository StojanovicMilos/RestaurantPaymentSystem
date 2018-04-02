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
        [TestMethod]
        public void TableControllerAllTablesActionRendersRightView()
        {
            //arrange
            TableController tableController = ControllerFactory.GetTableController();
            string viewName = "alltables";

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
            var table0 = Constants.tables[0];
            var table1 = Constants.tables[1];
            var table2 = Constants.tables[2];
            TableController tableController = ControllerFactory.GetTableController();

            //act
            ViewResult result = tableController.AllTables() as ViewResult;

            //assert

            var model = (result.ViewData.Model as System.Collections.ICollection);
            CollectionAssert.Contains(model, table0);
            CollectionAssert.Contains(model, table1);
            CollectionAssert.Contains(model, table2);
        }

    }
}
