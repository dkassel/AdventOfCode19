using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode19 {
     

    enum OpCmd {
        ADD = 1,
        MLP = 2,
        ABORT = 99
    }
    public class Day2 {

        private bool isOpCode(int code) {
            return code == 1 || code == 2 || code == 99;
        }

        private void bugFix(ref int[] program) {
            program[1] = 12;
            program[2] = 2;
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

        private int computeNumbers(OpCmd code, int value1, int value2) {
            if (code == OpCmd.ADD) return value1 + value2;
            if (code == OpCmd.MLP) return value1 * value2;
            return 0;
        }

    }



}
