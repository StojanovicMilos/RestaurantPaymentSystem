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
    public class TableControllerDeleteActionTests
    {

        [TestMethod]
        public void TableControllerDeleteTableGetActionRendersRightView()
        {
            //arrange
            TableController tableController = ControllerFactory.GetTableController();
            string viewName = "Delete";
            var table = Constants.TablesInDatabase[0];

            //act
            ViewResult result = tableController.Delete(table.Id) as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
        }

        [TestMethod]
        public void TableControllerDeleteActionGetActionTableNotFound()
        {
            //arrange
            TableController tableController = ControllerFactory.GetTableController();
            var table = Constants.TablesNotInDatabase[0];

            //act
            HttpNotFoundResult result = tableController.Delete(table.Id) as HttpNotFoundResult;

            //assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }

        [TestMethod]
        public void TableControllerDeleteTablePostTableDoesntExistInDatabase()
        {
            //arrange
            TableController tableController = ControllerFactory.GetTableController();
            var table = Constants.TablesNotInDatabase[0];

            //act
            var result = tableController.Delete(table) as HttpNotFoundResult;

            //assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TableControllerDeleteTableExistsInDatabase()
        {
            //arrange
            TableController tableController = ControllerFactory.GetTableController();
            string viewName = "AllTables";
            var table = Constants.TablesInDatabase[0];

            //act
            ViewResult result = tableController.Delete(table) as ViewResult;
            var model = (result.ViewData.Model as IEnumerable<Table>).ToList();
            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
            CollectionAssert.DoesNotContain(model, table);
        }
    }
}
