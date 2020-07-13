using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode19.Tasks.Day7.Tests {
    [TestClass()]
    public class AmplificationCircuitTests {

        [TestMethod()]
        public void StartAmplificationCircuitTest() {
            AmplificationCircuit c = new AmplificationCircuit();
            int[] testProgram = { 3, 15, 3, 16, 1002, 16, 10, 16, 1, 16, 15, 15, 4, 15, 99, 0, 0 };
            int[] testPhaseSetting = { 4, 3, 2, 1, 0 };
            int result = c.StartAmplificationCircuit(testProgram, testPhaseSetting);
            Assert.AreEqual(43210, result);

            int[] testProgram2 = { 3, 23, 3, 24, 1002, 24, 10, 24, 1002, 23, -1, 23, 101, 5, 23, 23, 1, 24, 23, 23, 4, 23, 99, 0, 0 };
            int[] testPhaseSetting2 = { 0, 1, 2, 3, 4 };
            int result2 = c.StartAmplificationCircuit(testProgram2, testPhaseSetting2);
            Assert.AreEqual(54321, result2);

            int[] testProgram3 = { 3, 31, 3, 32, 1002, 32, 10, 32, 1001, 31, -2, 31, 1007, 31, 0, 33, 1002, 33, 7, 33, 1, 33, 31, 31, 1, 32, 31, 31, 4, 31, 99, 0, 0, 0 };
            int[] testPhaseSetting3 = { 1, 0, 4, 3, 2 };
            int result3 = c.StartAmplificationCircuit(testProgram3, testPhaseSetting3);
            Assert.AreEqual(65210, result3);
        }
    }
}