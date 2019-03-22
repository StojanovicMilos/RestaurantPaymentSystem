using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantPaymentSystem.Controllers;
using RestaurantPaymentSystem.Models;
using RestaurantPaymentSystem.Tests.DB;
using System.Web.Mvc;

namespace RestaurantPaymentSystem.Tests.Controllers.TableControllerTests
{
    [TestClass]
    public class TableControllerDetailsActionTests
    {
        [TestMethod]
        public void TableControllerDetailsActionRendersRightView()
        {
            //arrange
            TableController tableController = ControllerFactory.GetTableController();
            string viewName = "Details";
            var tableID = Constants.TablesInDatabase[0].Id;

            //act
            ViewResult result = tableController.Details(tableID) as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
        }

        [TestMethod]
        public void TableControllerDetailsActionContainsRightTable()
        {
            //arrange
            TableController tableController = ControllerFactory.GetTableController();
            var table = Constants.TablesInDatabase[0];

            //act
            ViewResult result = tableController.Details(table.Id) as ViewResult;
            var model = result.Model as Table;
            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(table, model);
        }
    }
}
