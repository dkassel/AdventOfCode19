﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode19.Tests {
    [TestClass()]
    public class Day1Tests
    {
        [TestMethod()]
        public void calculateFuelTest()
        {
            Day1 day1 = new Day1();
            Assert.AreEqual(day1.calcFuelEquation(12), 2);
            Assert.AreEqual(day1.calcFuelEquation(14), 2);
            Assert.AreEqual(day1.calcFuelEquation(1969), 654);
            Assert.AreEqual(day1.calcFuelEquation(100756), 33583);

        }
    }
}