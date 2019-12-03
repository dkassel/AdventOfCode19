using AdventOfCode19.lib;
using System;
using System.Collections.Generic;

namespace AdventOfCode19 {


    enum OpCmd {
        ADD = 1,
        MLP = 2,
        ABORT = 99
    }
    public class Day2 {
        private const string INPUT_FILE_PATH = @"..\..\Tasks\Day2\input.txt";
        private int[] program;

        public Day2() {
            string[] fileLines = SantasLittleHelperClass.textfileToStringArray(INPUT_FILE_PATH);
            List<int> program = new List<int>();

            for (int i = 0; i < fileLines.Length; i++) {
                string[] split = fileLines[i].Split(',');
                for (int j = 0; j < split.Length; j++) {
                    program.Add(SantasLittleHelperClass.stringToInt(split[j]));
                }
            }
            this.program = program.ToArray();
        }

        private bool isOpCode(int code) {
            return code == 1 || code == 2 || code == 99;
        }

        private void bugFix(ref int[] program) {
            program[1] = 12;
            program[2] = 2;
        }

        private int computeNumbers(OpCmd code, int value1, int value2) {
            if (code == OpCmd.ADD) return value1 + value2;
            if (code == OpCmd.MLP) return value1 * value2;
            return 0;
        }

        public int[] runProgram(int[] program) {
            for (int i = 0; i < program.Length;) {
                OpCmd command = (OpCmd)program[i];
                if (!Enum.IsDefined(typeof(OpCmd), command)) throw new ArgumentException();

                if (command == OpCmd.ABORT) break;

                int index1 = program[i + 1];
                int index2 = program[i + 2];
                int outputIndex = program[i + 3];
                program[outputIndex] = computeNumbers(command, program[index1], program[index2]);
                i += 4;

            }
            return program;
        }

        public int[] runProgram() {
            bugFix(ref program);
            return runProgram(program);
        }

    }



}
