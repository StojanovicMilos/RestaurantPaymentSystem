using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantPaymentSystem.Controllers;

namespace RestaurantPaymentSystem.Tests.Controllers.HomeControllerTests
{
    [TestClass]
    public class HomeControllerIndexActionTests
    {

        [TestMethod]
        public void HomeControllerIndexActionRendersRightView()
        {
            // Arrange
            HomeController controller = new HomeController();
            string viewName = "index";

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(viewName, result.ViewName);
        }
    }
}
