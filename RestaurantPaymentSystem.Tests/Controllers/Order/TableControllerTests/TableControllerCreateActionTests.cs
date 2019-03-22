using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantPaymentSystem.Controllers;
using RestaurantPaymentSystem.Models;
using RestaurantPaymentSystem.Tests.DB;

namespace RestaurantPaymentSystem.Tests.Controllers.TableControllerTests
{
    [TestClass]
    public class TableControllerCreateActionTests
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
        public void TableControllerCreateActionGetActionRendersRightView()
        {
            //arrange
            string viewName = "Create";

            //act
            ViewResult result = tableController.Create() as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
        }

        [TestMethod]
        public void TableControllerCreateActionPostModelStateInvalid()
        {
            //arrange
            string viewName = "Create";
            tableController.ModelState.AddModelError("test", "test");
            var table = Constants.TablesNotInDatabase[0];

            //act
            ViewResult result = tableController.Create(table) as ViewResult;

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
            ViewResult result = tableController.Create(table) as ViewResult;
            var model = (result.ViewData.Model as IEnumerable<Table>).ToList();
            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
            CollectionAssert.Contains(model, table);
        }
    }
}
