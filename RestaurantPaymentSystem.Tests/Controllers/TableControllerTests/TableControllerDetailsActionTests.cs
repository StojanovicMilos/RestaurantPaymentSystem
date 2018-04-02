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
            string viewName = "details";
            var tableID = Constants.tables[0].ID;

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
            var table = Constants.tables[0];

            //act
            ViewResult result = tableController.Details(table.ID) as ViewResult;
            var model = result.Model as TableViewModel;
            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(table, model);
        }
    }
}
