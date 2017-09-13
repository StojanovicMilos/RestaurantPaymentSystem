using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantPaymentSystem.Controllers;

namespace RestaurantPaymentSystem.Tests.Controllers.HomeControllerTests
{
    [TestClass]
    public class HomeControllerContactActionTests
    {

        [TestMethod]
        public void HomeControllerContactActionNotNull()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void HomeControllerContactActionCheckViewBagMessage()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.AreEqual("Your contact page.", result.ViewBag.Message);
        }
    }
}