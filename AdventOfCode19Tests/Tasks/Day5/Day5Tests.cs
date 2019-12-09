using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode19;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode19.Tests {
    [TestClass()]
    public class Day5Tests {
        [TestMethod()]
        public void runThermalEnvironmentSupervisionTerminalTest() {
            Day5 d = new Day5();
            int[] program = { 3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9 };
            Assert.AreEqual(0, d.runThermalEnvironmentSupervisionTerminal(0, program));
            Assert.AreEqual(1, d.runThermalEnvironmentSupervisionTerminal(1, program));
            program = new int[] { 3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20, 1006, 20, 31, 1106, 0, 36, 98, 0, 0, 1002, 21, 125, 20, 4, 20, 1105, 1, 46, 104, 999, 1105, 1, 46, 1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99 };

            // LESS EQUALS TESTS
            Assert.AreEqual(999, d.runThermalEnvironmentSupervisionTerminal(7, program));
            Assert.AreEqual(1000, d.runThermalEnvironmentSupervisionTerminal(8, program));
            Assert.AreEqual(1001, d.runThermalEnvironmentSupervisionTerminal(9, program));
        }

    }
}