using System.Collections;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantPaymentSystem.Controllers;
using RestaurantPaymentSystem.Tests.DB;

namespace RestaurantPaymentSystem.Tests.Controllers.TableControllerTests
{
    [TestClass]
    public class TableControllerCreateActionTests
    {
        [TestMethod]
        public void TableControllerCreateTableGetActionRendersRightView()
        {
            //arrange
            TableController tableController = ControllerFactory.GetTableController();
            string viewName = "create";

            //act
            ViewResult result = tableController.Create() as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
        }

        [TestMethod]
        public void TableControllerCreateTablePostModelStateInvalid()
        {
            //arrange
            TableController tableController = ControllerFactory.GetTableController();
            string viewName = "create";
            tableController.ModelState.AddModelError("test", "test");
            var table = Constants.table4;

            //act
            ViewResult result = tableController.Create(table) as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
        }

        [TestMethod]
        public void TableControllerCreateTablePostModelStateValid()
        {
            //arrange
            TableController tableController = ControllerFactory.GetTableController();
            string viewName = "alltables";
            var table = Constants.table4;

            //act
            ViewResult result = tableController.Create(table) as ViewResult;
            var model = result.Model as ICollection;
            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
            CollectionAssert.Contains(model, table);
        }
    }
}
