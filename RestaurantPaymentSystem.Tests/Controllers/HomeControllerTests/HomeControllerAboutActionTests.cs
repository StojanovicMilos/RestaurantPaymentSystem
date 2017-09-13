using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantPaymentSystem.Controllers;

namespace RestaurantPaymentSystem.Tests.Controllers.HomeControllerTests
{
    [TestClass]
    public class HomeControllerAboutActionTests
    {

        [TestMethod]
        public void HomeControllerAboutActionNotNull()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void HomeControllerAboutActionCheckViewBagMessage()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }
    }
}


    