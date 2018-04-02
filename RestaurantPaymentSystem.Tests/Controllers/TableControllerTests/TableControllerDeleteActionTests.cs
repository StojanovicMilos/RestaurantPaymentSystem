using System;
using System.Collections;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantPaymentSystem.Controllers;
using RestaurantPaymentSystem.Tests.DB;

namespace RestaurantPaymentSystem.Tests.Controllers.TableControllerTests
{
    [TestClass]
    public class TableControllerDeleteActionTests
    {

        [TestMethod]
        public void TableControllerDeleteTableGetActionRendersRightView()
        {
            //arrange
            TableController tableController = ControllerFactory.GetTableController();
            string viewName = "delete";
            var table = Constants.tables[0];

            //act
            ViewResult result = tableController.Delete(table.ID) as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
        }

        [TestMethod]
        public void TableControllerDeleteTablePostTableDoesntExistInDatabase()
        {
            //arrange
            TableController tableController = ControllerFactory.GetTableController();
            var table = Constants.table4;

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
            string viewName = "alltables";
            var table = Constants.tables[0];

            //act
            ViewResult result = tableController.Delete(table) as ViewResult;
            var model = result.Model as ICollection;
            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
            CollectionAssert.DoesNotContain(model, table);
        }
    }
}
