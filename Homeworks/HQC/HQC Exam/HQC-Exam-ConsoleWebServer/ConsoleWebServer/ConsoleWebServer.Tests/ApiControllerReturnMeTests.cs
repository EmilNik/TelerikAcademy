namespace ConsoleWebServer.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Application.Controllers;
    using Framework;

    [TestClass]
    public class ApiControllerReturnMeTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            ApiController controller = new ApiController(new HttpRequest("get", "/api/returnme/someparam123", "1.1"));
        }
    }
}
