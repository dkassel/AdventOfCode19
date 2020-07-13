using AdventOfCode19.lib;
using AdventOfCode19.Tasks.Day7;
using System;
using System.Collections.Generic;

namespace AdventOfCode19 {


    public class Day5 {
        private const string INPUT_FILE_PATH = @"..\..\Tasks\Day5\input.txt";
        private List<int> diagnostics = new List<int>();
        private IntCodeComputer intCodeComputer = new IntCodeComputer();

        private int[] inputFileToIntArray() {
            string[] fileLines = SantasLittleHelperClass.TextfileToStringArray(INPUT_FILE_PATH);
            List<int> program = new List<int>();
            for (int i = 0; i < fileLines.Length; i++) {
                string[] split = fileLines[i].Split(',');
                for (int j = 0; j < split.Length; j++) {
                    program.Add(SantasLittleHelperClass.StringToInt(split[j]));
                }
            }
            return program.ToArray();
        }


        public int runThermalEnvironmentSupervisionTerminal(int[] input) {
            return runThermalEnvironmentSupervisionTerminal(input, inputFileToIntArray());
        }
        public int runThermalEnvironmentSupervisionTerminal(int[] input, int[] diagnosticProgram = null) {
            intCodeComputer.RunProgram(diagnosticProgram, input);
            return getDiagnosticsCode();
        }

        private int getDiagnosticsCode() {
            var arr = intCodeComputer.outputList.ToArray();
            return arr[arr.Length - 1];
        }
    }
}
