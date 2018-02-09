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
    public class TableControllerTests
    {
        private TableController GetTableController()
        {
            return new TableController(new InMemoryRestaurantPaymentSystemDB());
        }

        //[TestMethod]
        //public void TableControllerAllTablesActionNotNull()
        //{
        //    //arrange
        //    TableController tableController = GetTableController();

        //    //act
        //    ActionResult result = tableController.AllTables();

        //    //assert
        //    Assert.IsNotNull(result);
        //}

        [TestMethod]
        public void TableControllerAllTablesActionHasTables()
        {
            //arrange
            var table0 = Constants.tables[0];
            var table1 = Constants.tables[1];
            var table2 = Constants.tables[2];
            TableController tableController = GetTableController();

            //act
            ActionResult result = tableController.AllTables();

            //assert
            var model = (IEnumerable<TableViewModel>)((ViewResult)result).ViewData.Model;
            CollectionAssert.Contains(model.ToList(), table0);
            CollectionAssert.Contains(model.ToList(), table1);
            CollectionAssert.Contains(model.ToList(), table2);
        }

        //[TestMethod]
        //public void TableControllerCreateTableActionNotNull()
        //{
        //    //arrange
        //    TableController tableController = GetTableController();

        //    //act
        //    ActionResult result = tableController.Create();

        //    //assert
        //    Assert.IsNotNull(result);
        //}
    }
}
