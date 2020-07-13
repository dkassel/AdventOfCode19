using AdventOfCode19.lib;
using System;
using System.Collections.Generic;

namespace AdventOfCode19.Tasks.Day7 {
    public enum ParameterMode {
        Position = 0,
        Immediate = 1,
        Relative = 2
    }

    enum OpCode {
        Add = 1,
        Mlp = 2,
        Mov = 3,
        Out = 4,
        JmpOnTrue = 5,
        JmpOnFalse = 6,
        LessThan = 7,
        Eq = 8,
        RelativeBaseOffset = 9,
        Abort = 99
    }
    public class IntCodeComputer {
        public List<int> outputList = new List<int>();
        private long relativeBase = 0;

        /*
        public int[] RunProgram(int[] program, int[] input) {
            int inputCnt = 0;
            outputList.Clear();
            OpCode code;
            for (int iPt = 0; iPt < program.Length; iPt += GetOpCodeIncrement(code)) {
                ParameterMode[] modes;
                ParseOpCodeValue(program[iPt], out code, out modes);

                if (code == OpCode.Abort) {
                    break;
                }
                else if (code == OpCode.Mov) {
                    int address = program[iPt + 1];
                    program[address] = input[inputCnt];
                    inputCnt++;
                }
                else if (code == OpCode.Out) {
                    int param1 = GetValue(program, modes[0], iPt + 1);
                    outputList.Add(param1);
                }
                else {
                    int param1 = GetValue(program, modes[0], iPt + 1);
                    int param2 = GetValue(program, modes[1], iPt + 2);
                    int outAddress = program[iPt + 3];

                    if (code == OpCode.Add)         // Add numbers
                        program[outAddress] = param1 + param2;
                    else if (code == OpCode.Mlp)    // Multiply numbers
                        program[outAddress] = param1 * param2;
                    else if ((code == OpCode.JmpOnTrue && param1 != 0) || (code == OpCode.JmpOnFalse && param1 == 0)) {   // Jump if True or False
                        iPt = param2 - GetOpCodeIncrement(code);
                    }
                    else if (code == OpCode.LessThan) { // Check if lesser than
                        if (param1 < param2) program[outAddress] = 1;
                        else program[outAddress] = 0;
                    }
                    else if (code == OpCode.Eq) {       // Check if equal
                        if (param1 == param2) program[outAddress] = 1;
                        else program[outAddress] = 0;
                    }
                }
            }
            return program;
        }
        */

        public long[] RunProgram(int[] program, int[] input) {
            return RunProgram(IntArrayToLongArray(program), IntArrayToLongArray(input));
        }

        public long[] RunProgram(long[] program, long[] input) {//, out List<long> outputList) {
            long[] buffer = new long[1000000];
            program.CopyTo(buffer, 0);
            int inputCnt = 0;
            List<long> outputList = new List<long>();
            relativeBase = 0;

            OpCode code;
            for (long iPt = 0; iPt < buffer.Length; iPt += GetOpCodeIncrement(code)) {
                ParameterMode[] modes;
                ParseOpCodeValue((int)buffer[iPt], out code, out modes);

                if (code == OpCode.Abort) {
                    break;
                }
                else if (code == OpCode.Mov) {
                    long address = buffer[iPt + 1];
                    if (modes[0] == ParameterMode.Relative) address = address + relativeBase;
                    buffer[address] = input[inputCnt];
                    inputCnt++;
                }
                else if (code == OpCode.Out) {
                    long param1 = ReadValueFromProgram(buffer, modes[0], buffer[iPt + 1]);
                    outputList.Add(param1);
                }
                else if (code == OpCode.RelativeBaseOffset) {
                    long param1 = ReadValueFromProgram(buffer, modes[0], buffer[iPt + 1]);
                    relativeBase += param1;
                }
                else {
                    long param1 = ReadValueFromProgram(buffer, modes[0], buffer[iPt + 1]);
                    long param2 = ReadValueFromProgram(buffer, modes[1], buffer[iPt + 2]);

                    if (code == OpCode.Add) {         // Add numbers
                        WriteValueToProgram(buffer, modes[2], buffer[iPt + 3], param1 + param2); //buffer[outAddress] = param1 + param2;
                    }
                    else if (code == OpCode.Mlp) {    // Multiply numbers
                        WriteValueToProgram(buffer, modes[2], buffer[iPt + 3], param1 * param2); //buffer[outAddress] = param1 * param2;
                    }
                    else if ((code == OpCode.JmpOnTrue && param1 != 0) || (code == OpCode.JmpOnFalse && param1 == 0)) {   // Jump if True or False
                        iPt = param2 - GetOpCodeIncrement(code);
                    }
                    else if (code == OpCode.LessThan) { // Check if lesser than
                        if (param1 < param2) WriteValueToProgram(buffer, modes[2], buffer[iPt + 3], 1); //buffer[outAddress] = 1;
                        else WriteValueToProgram(buffer, modes[2], buffer[iPt + 3], 0); //buffer[outAddress] = 0;
                    }
                    else if (code == OpCode.Eq) {       // Check if equal
                        if (param1 == param2) WriteValueToProgram(buffer, modes[2], buffer[iPt + 3], 1);  //buffer[outAddress] = 1;
                        else WriteValueToProgram(buffer, modes[2], buffer[iPt + 3], 0); //buffer[outAddress] = 0;
                    }
                }
            }
            return outputList.ToArray(); ;
        }

        /*
        private int GetValue(int[] program, ParameterMode mode, int address) {
            if (mode == ParameterMode.Position)
                return program[program[address]];
            else if (mode == ParameterMode.Immediate)
                return program[address];
            return 0;
        }
        

        private void WriteValue(long[] program, ParameterMode mode, long address, long value) {
            if (mode == ParameterMode.Position)
                program[program[address]] = value;
            else if (mode == ParameterMode.Immediate)
                throw new ArgumentException();
            else if (mode == ParameterMode.Relative) {
                program[program[address] + relativeBase] = value;
            }
        }

        private long GetValue(long[] program, ParameterMode mode, long address) {
            if (mode == ParameterMode.Position)
                return program[program[address]];
            else if (mode == ParameterMode.Immediate)
                return program[address];
            else if (mode == ParameterMode.Relative) {
                return program[program[address] + relativeBase];
            }
            return 0;
        }
        */
        private long ReadValueFromProgram(long[] program, ParameterMode mode, long param) {
            switch (mode) {
                case ParameterMode.Position:
                    return program[param];
                case ParameterMode.Immediate:
                    return param;
                case ParameterMode.Relative:
                    return program[param + relativeBase];
                default: throw new ArgumentException("Unknown parameter mode " + mode);
            }
        }

        private void WriteValueToProgram(long[] program, ParameterMode mode, long address, long valueToWrite) {
            switch (mode) {
                case ParameterMode.Position:
                    program[address] = valueToWrite;
                    break;
                case ParameterMode.Relative:
                    program[address + relativeBase] = valueToWrite;
                    break;
                case ParameterMode.Immediate:
                default: throw new ArgumentException("Unknown parameter mode " + mode);
            }
        }

        /*
        private long GetValue(long[] program, ParameterMode mode, int address) {
            if (mode == ParameterMode.Position)
                return program[program[address]];
            else if (mode == ParameterMode.Immediate)
                return program[address];
            return 0;
        }
        */

        private int GetDiagnosticsCode() {
            int[] arr = outputList.ToArray();
            for (int i = 0; i < arr.Length - 1; i++) {
                if (arr[i] != 0) return -1;
            }
            return arr[arr.Length - 1];
        }

        #region OPCODE MANIPULATION STUFF
        private int GetOpCodeIncrement(OpCode code) {
            switch (code) {
                case OpCode.Add:
                case OpCode.Mlp:
                case OpCode.Eq:
                case OpCode.LessThan:
                    return 4;
                case OpCode.Mov:
                case OpCode.Out:
                case OpCode.RelativeBaseOffset:
                    return 2;
                case OpCode.JmpOnFalse:
                case OpCode.JmpOnTrue:
                    return 3;
            }
            return 0;
        }


        private void ParseOpCodeValue(int opCodeValue, out OpCode opCode, out ParameterMode[] paramModes) {
            int[] digits = SantasLittleHelperClass.IntToDigitArray(opCodeValue);
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

        private long[] IntArrayToLongArray(int[] array) {
            long[] result = new long[array.Length];
            for (int i = 0; i < array.Length; i++) {
                result[i] = array[i];
            }
            return result;
        }
    }
}
