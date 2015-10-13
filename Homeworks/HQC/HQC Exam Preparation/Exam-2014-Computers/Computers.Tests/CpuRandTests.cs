namespace Computers.Tests
{
    using System;
    using System.Collections.Generic;
    using Logic;
    using Logic.CPUs;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class CpuRandTests
    {
        [TestMethod]
        public void RandShouldNotProduceNumbersLessThanNimValue()
        {
            var cpu = new Cpu32(2);
            var motherboard = new Mock<IMotherboard>();
            cpu.AttachTo(motherboard.Object);

            var currentMin = int.MaxValue;

            motherboard.Setup(x => x.SaveRamValue(It.IsAny<int>()))
                .Callback<int>(y => currentMin = Math.Min(currentMin, y));

            for (int i = 0; i < 10000; i++)
            {
                cpu.Rand(1, 10);
            }

            Assert.AreEqual(1, currentMin);
        }

        [TestMethod]
        public void RandShouldNotProduceNumbersHigherThanMaxValue()
        {
            var cpu = new Cpu32(2);
            var motherboard = new Mock<IMotherboard>();
            cpu.AttachTo(motherboard.Object);

            var currentMax = int.MinValue;

            motherboard.Setup(x => x.SaveRamValue(It.IsAny<int>()))
                .Callback<int>(y => currentMax = Math.Max(currentMax, y));

            for (int i = 0; i < 10000; i++)
            {
                cpu.Rand(1, 10);
            }

            Assert.AreEqual(10, currentMax);
        }

        [TestMethod]
        public void RandShouldReturnRandomNumbers()
        {
            var hashSet = new HashSet<int>();
            var cpu = new Cpu32(2);
            var motherboard = new Mock<IMotherboard>();
            cpu.AttachTo(motherboard.Object);

            motherboard.Setup(x => x.SaveRamValue(It.IsAny<int>()))
                .Callback<int>(y => hashSet.Add(y));

            for (int i = 0; i < 10000; i++)
            {
                cpu.Rand(1, 10);
            }

            Assert.AreEqual(10, hashSet.Count);
        }
    }
}
