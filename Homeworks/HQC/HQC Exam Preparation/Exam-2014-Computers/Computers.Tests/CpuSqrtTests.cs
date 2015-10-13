namespace Computers.Tests
{
    using Logic;
    using Logic.CPUs;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class CpuSqrtTests
    {
        [TestMethod]
        public void SquareNumberShouldOutputCorrectValues()
        {
            var cpu = new Cpu32(4);
            var motherboard = new Mock<IMotherboard>();
            motherboard.Setup(x => x.LoadRamValue()).
                Returns(123);
            cpu.AttachTo(motherboard.Object);
            cpu.SquareNumber();

            motherboard.Verify(x => x.DrawOnVideoCard(
                It.Is<string>(y => y.Contains("15129"))));
        }

        [TestMethod]
        public void SquareNumberShouldOutputErrorMessageWhenValueIsLessThanZero()
        {
            var cpu = new Cpu32(4);
            var motherboard = new Mock<IMotherboard>();
            motherboard.Setup(x => x.LoadRamValue()).
                Returns(-123);
            cpu.AttachTo(motherboard.Object);
            cpu.SquareNumber();

            motherboard.Verify(x => x.DrawOnVideoCard(
                It.Is<string>(y => y.Contains(Cpu.NumberTooLowMessage))));
        }

        [TestMethod]
        public void SquareNumberShouldOutputErrorMessageWhenValueIsTooHigh()
        {
            var cpu = new Cpu32(4);
            var motherboard = new Mock<IMotherboard>();
            motherboard.Setup(x => x.LoadRamValue()).
                Returns(123123);
            cpu.AttachTo(motherboard.Object);
            cpu.SquareNumber();

            motherboard.Verify(x => x.DrawOnVideoCard(
                It.Is<string>(y => y.Contains(Cpu.NumberTooHighMessage))));
        }
    }
}
