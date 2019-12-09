using AdventOfCode19.lib;
using System;
using System.Collections.Generic;

namespace AdventOfCode19 {

    public enum ParameterMode {
        Position,
        Immediate
    }

    public class Day5 {
        private const string INPUT_FILE_PATH = @"..\..\Tasks\Day5\input.txt";
        private int[] memory;
        private readonly int[] originalMemory;
        private List<int> diagnostics = new List<int>();

        #region MEMORY MANAGEMENT
        public Day5() {
            string[] fileLines = SantasLittleHelperClass.textfileToStringArray(INPUT_FILE_PATH);
            List<int> program = new List<int>();

            for (int i = 0; i < fileLines.Length; i++) {
                string[] split = fileLines[i].Split(',');
                for (int j = 0; j < split.Length; j++) {
                    program.Add(SantasLittleHelperClass.stringToInt(split[j]));
                }
            }
            originalMemory = program.ToArray();
        }

        private void resetMemory() {
            memory = new int[originalMemory.Length];
            originalMemory.CopyTo(memory, 0);
        }
        #endregion MEMORY MANAGEMENT



        public int runThermalEnvironmentSupervisionTerminal(int input, int[] program = null) {
            diagnostics.Clear();
            int result = 0;

            if (program != null) {
                resetMemory();
                result = runShipComputer(program, input)[0];
            }
            else {
                resetMemory();
                result = runShipComputer(memory, input)[0];
            }
            var diaArray = diagnostics.ToArray();
            return diaArray[diaArray.Length - 1];
        }

        private int getValue(int[] program, ParameterMode mode, int address) {
            if (mode == ParameterMode.Position)
                return program[program[address]];
            else if (mode == ParameterMode.Immediate)
                return program[address];
            return 0;
        }

        private int[] runShipComputer(int[] program, int input) {
            OpCode code;
            for (int iPt = 0; iPt < program.Length; iPt += getOpCodeIncrement(code)) {
                ParameterMode[] modes;
                parseOpCodeValue(program[iPt], out code, out modes);

                if (code == OpCode.ABORT) {
                    break;
                }
                else if (code == OpCode.MOV) {
                    int address = program[iPt + 1];
                    program[address] = input;
                }
                else if (code == OpCode.OUT) {
                    int param1 = getValue(program, modes[0], iPt + 1);
                    diagnostics.Add(param1);
                }
                else {
                    int param1 = getValue(program, modes[0], iPt + 1);
                    int param2 = getValue(program, modes[1], iPt + 2);
                    int outAddress = program[iPt + 3];

                    if (code == OpCode.ADD)         // Add numbers
                        program[outAddress] = param1 + param2;
                    else if (code == OpCode.MLP)    // Multiply numbers
                        program[outAddress] = param1 * param2;
                    else if ((code == OpCode.JMP_TRUE && param1 != 0) || (code == OpCode.JMP_FALSE && param1 == 0)) {   // Jump if True or False
                        iPt = param2 - getOpCodeIncrement(code);
                    }
                    else if (code == OpCode.LESS_THAN) { // Check if lesser than
                        if (param1 < param2) program[outAddress] = 1;
                        else program[outAddress] = 0;
                    }
                    else if (code == OpCode.EQ) {       // Check if equal
                        if (param1 == param2) program[outAddress] = 1;
                        else program[outAddress] = 0;
                    }
                }
            }
            return program;
        }

        #region OPCODE MANIPULATION STUFF
        private int getOpCodeIncrement(OpCode code) {
            switch (code) {
                case OpCode.ADD:
                case OpCode.MLP:
                case OpCode.EQ:
                case OpCode.LESS_THAN:
                    return 4;
                case OpCode.MOV:
                case OpCode.OUT:
                    return 2;
                case OpCode.JMP_FALSE:
                case OpCode.JMP_TRUE:
                    return 3;
            }
            return 0;
        }

        private void parseOpCodeValue(int opCodeValue, out OpCode opCode, out ParameterMode[] paramModes) {
            int[] digits = SantasLittleHelperClass.intToDigitArray(opCodeValue);
            opCode = (OpCode)(opCodeValue % 100);
            if (!Enum.IsDefined(typeof(OpCode), opCode)) throw new ArgumentException();

            List<ParameterMode> modes = new List<ParameterMode>();
            for (int i = digits.Length - 3; i >= 0; i--) {
                modes.Add((ParameterMode)digits[i]);
            }

            while (modes.Count < 3) modes.Add(ParameterMode.Position);
            paramModes = modes.ToArray();
        }
        #endregion OPCODE MANIPULATION STUFF

    }
}
