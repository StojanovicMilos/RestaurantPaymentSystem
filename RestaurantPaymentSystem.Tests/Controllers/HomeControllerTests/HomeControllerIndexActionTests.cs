using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
