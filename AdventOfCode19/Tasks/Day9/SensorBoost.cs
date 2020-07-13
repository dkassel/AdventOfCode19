using AdventOfCode19.lib;
using AdventOfCode19.Tasks.Day7;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode19.Tasks.Day9 {
    class SensorBoost {
        private IntCodeComputer computer = new IntCodeComputer();
        private const string InputFilePath = @"..\..\Tasks\Day9\Input.txt";

        private long[] GetBoostProgram() {
            string[] fileLines = SantasLittleHelperClass.TextfileToStringArray(InputFilePath);
            List<long> program = new List<long>();
            for (int i = 0; i < fileLines.Length; i++) {
                string[] split = fileLines[i].Split(',');
                for (int j = 0; j < split.Length; j++) {
                    program.Add(SantasLittleHelperClass.StringToLong(split[j]));
                }
            }
            return program.ToArray();
        }

        public void Tests() {
            /*
            long[] testProgram1 = { 109, 1, 204, -1, 1001, 100, 1, 100, 1008, 100, 16, 101, 1006, 101, 0, 99 };
            long[] outputList1 = computer.RunProgram(testProgram1, null);
            bool testResult1 = outputList1.SequenceEqual(testProgram1);

            long[] testProgram2 = { 1102, 34915192, 34915192, 7, 4, 7, 99, 0 };
            long[] outputList2 = computer.RunProgram(testProgram2, null);
            bool testResult2 = outputList2.Length == 1 && outputList2[0].ToString().Length == 16;

            long[] testProgram3 = { 104, 1125899906842624, 99 };
            long[] outputList3 = computer.RunProgram(testProgram3, null);
            bool testResult3 = outputList3.Length == 1 && outputList3[0] == 1125899906842624;


            if (!testResult1 || !testResult2 || !testResult3) throw new System.Exception();
            */
            long[] input2 = { 1 };
            long[] testProgram4 = { 109, 1, 203, 2, 204, 2, 99 };
            long[] outputList4 = computer.RunProgram(testProgram4, input2);

            bool testResult = outputList4[0] == 1;




            long[] boostProgram = GetBoostProgram();
            long[] input = { 1 };
            long[] testModeOutput = computer.RunProgram(boostProgram, input);

        }
    }
}
