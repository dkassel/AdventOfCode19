using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode19;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode19.Tests {
    [TestClass()]
    public class Day2Tests {
        [TestMethod()]
        public void runProgramTest() {
            Day2 day2 = new Day2();
            int[] test = { 1, 0, 0, 0, 99 };
            int[] testResult = { 2, 0, 0, 0, 99 };
            Assert.IsTrue(Enumerable.SequenceEqual(day2.runShipComputer(test), testResult));

            int[] test2 = { 2, 3, 0, 3, 99 };
            int[] test2Result = { 2, 3, 0, 6, 99 };
            Assert.IsTrue(Enumerable.SequenceEqual(day2.runShipComputer(test2), test2Result));

            int[] test3 = { 2, 4, 4, 5, 99, 0 };
            int[] test3Result = { 2, 4, 4, 5, 99, 9801 };
            Assert.IsTrue(Enumerable.SequenceEqual(day2.runShipComputer(test3), test3Result));

            int[] test4 = { 1, 1, 1, 4, 99, 5, 6, 0, 99 };
            int[] test4Result = { 30, 1, 1, 4, 2, 5, 6, 0, 99 };
            Assert.IsTrue(Enumerable.SequenceEqual(day2.runShipComputer(test4), test4Result));
        }
    }
}