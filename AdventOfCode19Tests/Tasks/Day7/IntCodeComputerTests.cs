using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode19.Tasks.Day7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode19.Tasks.Day7.Tests {
    [TestClass()]
    public class IntCodeComputerTests {

        [TestMethod()]
        public void BasicTest() {
            // Using position mode, consider whether the input is equal to 8; output 1 (if it is) or 0 (if it is not).
            long[] testProgram1 = { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8 };
            long[] input = { 8 };
            long[] outputList = RunTest(testProgram1, input);
            Assert.AreEqual(outputList[0], 1);
            input[0] = 7;
            outputList = RunTest(testProgram1, input);
            Assert.AreEqual(outputList[0], 0);

            // Using position mode, consider whether the input is less than 8; output 1 (if it is) or 0 (if it is not).
            testProgram1 = new long[] { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8 };
            input[0] = 7;
            outputList = RunTest(testProgram1, input);
            Assert.AreEqual(outputList[0], 1);
            input[0] = 9;
            outputList = RunTest(testProgram1, input);
            Assert.AreEqual(outputList[0], 0);

            // Using immediate mode, consider whether the input is equal to 8; output 1 (if it is) or 0 (if it is not).
            testProgram1 = new long[] { 3, 3, 1108, -1, 8, 3, 4, 3, 99 };
            input[0] = 8;
            outputList = RunTest(testProgram1, input);
            Assert.AreEqual(outputList[0], 1);
            input[0] = 7;
            outputList = RunTest(testProgram1, input);
            Assert.AreEqual(outputList[0], 0);
            // Using immediate mode, consider whether the input is less than 8; output 1 (if it is) or 0 (if it is not).
            testProgram1 = new long[] { 3, 3, 1107, -1, 8, 3, 4, 3, 99 };
            input[0] = 7;
            outputList = RunTest(testProgram1, input);
            Assert.AreEqual(outputList[0], 1);
            input[0] = 8;
            outputList = RunTest(testProgram1, input);
            Assert.AreEqual(outputList[0], 0);

            testProgram1 = new long[] { 3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9 };
            input[0] = 0;
            outputList = RunTest(testProgram1, input);
            Assert.AreEqual(outputList[0], 0);
            input[0] = 10;
            outputList = RunTest(testProgram1, input);
            Assert.AreEqual(outputList[0], 1);

            testProgram1 = new long[] { 3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1 };
            input[0] = 0;
            outputList = RunTest(testProgram1, input);
            Assert.AreEqual(outputList[0], 0);
            input[0] = 10;
            outputList = RunTest(testProgram1, input);
            Assert.AreEqual(outputList[0], 1);



            testProgram1 = new long[] { 3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20, 1006, 20, 31, 1106, 0, 36, 98, 0, 0, 1002, 21, 125, 20, 4, 20, 1105, 1, 46, 104, 999, 1105, 1, 46, 1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99 };
            input[0] = 0;
            outputList = RunTest(testProgram1, input);
            Assert.AreEqual(outputList[0], 999);
            input[0] = 8;
            outputList = RunTest(testProgram1, input);
            Assert.AreEqual(outputList[0], 1000);
            input[0] = 100;
            outputList = RunTest(testProgram1, input);
            Assert.AreEqual(outputList[0], 1001);

        }

        [TestMethod()]
        public void RunDay9Test() {
            long[] testProgram1 = { 109, 1, 204, -1, 1001, 100, 1, 100, 1008, 100, 16, 101, 1006, 101, 0, 99 };
            long[] outputList = RunTest(testProgram1, null);
            Assert.IsTrue(outputList.SequenceEqual(testProgram1));

            long[] testProgram2 = { 1102, 34915192, 34915192, 7, 4, 7, 99, 0 };
            outputList = RunTest(testProgram2, null);
            Assert.IsTrue(outputList.Length == 1 && outputList[0].ToString().Length == 16);


            long[] testProgram3 = { 104, 1125899906842624, 99 };
            outputList = RunTest(testProgram3, null);
            Assert.IsTrue(outputList.Length == 1 && outputList[0] == 1125899906842624);

            long[] input2 = { 1 };
            long[] testProgram4 = { 109, 1, 203, 2, 204, 2, 99 };
            outputList = RunTest(testProgram4, input2);
            bool testResult = outputList[0] == 1;
        }

        private long[] RunTest(long[] program, long[] input) {
            IntCodeComputer computer = new IntCodeComputer();
            long[] outputList = computer.RunProgram(program, input);
            return outputList;
        }
    }
}