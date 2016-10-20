using System.Web.Mvc;
using Vendor.Controllers;

namespace Vendor.Tests.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [Test]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void BuyProduct_RedirectsToThankYouView()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.BuyProduct(null, null) as ViewResult;

            if (result != null)
                Assert.AreEqual(result.ViewName, "ThankYou");
        }

        [TestCase(new double[] { 1 }, "Cola", "Thank you!", TestName = "WhenCorrectChange_Retursn_ThankYou")]
        [TestCase(new double[] { 1 }, "Cola", "Thank you!", TestName = "WhenCorrectChangeMultipleCoins_Returns_ThankYou")]
        [TestCase(new double[] { 0.5, 0.1, 0.05 }, "Candy", "Thank you!", TestName = "WhenCorrectChange_Returns_ThankYou")]
        [TestCase(new double[]{0.5,0.1}, "Cola", "INSERT COINS", TestName = "WhenTooLittleChange_Returns_INSERTCOIN")]
        [TestCase(new double[] { 0.5, 1 }, "Chips", "Thank you. Your change is £1", TestName = "WhenTooMuchChange_Returns_CorrectChange")]
        [TestCase(new double[] { 1, 0.5, 1 }, "Chips", "Thank you. Your change is £2", TestName = "WhenTooMuchChange_Returns_CorrectChange")]
        public void BuyProduct_Returns_ThankYou_when_correctChangeIsGiven(double[] change, string product, string expectedMessage)
        {
            HomeController controller = new HomeController();

            var actualChange = change.ToList();

            ViewResult result = controller.BuyProduct(actualChange, product) as ViewResult;

            if (result != null)
                Assert.AreEqual(result.ViewBag.Message, expectedMessage);
        }
    }
}
