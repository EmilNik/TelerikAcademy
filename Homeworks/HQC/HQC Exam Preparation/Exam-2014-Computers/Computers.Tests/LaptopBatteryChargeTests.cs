namespace Computers.Tests
{
    using Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LaptopBatteryChargeTests
    {
        [TestMethod]
        public void ChargeShouldAddToPercentageWhenGivenPositiveNumber()
        {
            var battery = new LaptopBattery();
            battery.Percentage = 50;
            battery.Charge(10);
            Assert.AreEqual(60, battery.Percentage);
        }

        [TestMethod]
        public void ChargeShouldSubstractFromPercentageWhenGivenNegativeNumber()
        {
            var battery = new LaptopBattery();
            battery.Percentage = 50;
            battery.Charge(-10);
            Assert.AreEqual(40, battery.Percentage);
        }

        [TestMethod]
        public void ChargeShouldNotSubstractFromPercentageWhenPercentageIsZero()
        {
            var battery = new LaptopBattery();
            battery.Percentage = 0;
            battery.Charge(-10);
            Assert.AreEqual(0, battery.Percentage);
        }

        [TestMethod]
        public void ChargeShouldNotAddToPercentageWhenPercentageIs100()
        {
            var battery = new LaptopBattery();
            battery.Percentage = 100;
            battery.Charge(10);
            Assert.AreEqual(100, battery.Percentage);
        }

        [TestMethod]
        public void ChargeShouldNotDoAnythingPercentageWhenChargedWithZero()
        {
            var battery = new LaptopBattery();
            battery.Percentage = 50;
            battery.Charge(0);
            Assert.AreEqual(50, battery.Percentage);
        }
    }
}
