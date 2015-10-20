namespace ConsoleWebServer.Tests
{
    using Application.Controllers;
    using Framework;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class ApiControllerReturnMeTests
    {
        [TestMethod]
        public void ReturnMeTestWhenAValidParamIsPassed()
        {
            // Using Moq
            ApiController controller = new ApiController(new Mock<HttpRequest>().Object);
            IActionResult actionResult = controller.ReturnMe("someparam123");

            Assert.AreEqual("{\"param\":\"someparam123\"}", actionResult);
        }

        [TestMethod]
        public void ReturnMeTestWhenAnEmptyStringIsPassed()
        {
            // Using Moq
            ApiController controller = new ApiController(new Mock<HttpRequest>().Object);
            IActionResult actionResult = controller.ReturnMe(string.Empty);

            Assert.AreEqual("{\"param\":\"\"}", actionResult);
        }
    }
}
