using AdventOfCode19.lib;
using AdventOfCode19.Tasks.Day7;
using System;
using System.Collections.Generic;

namespace AdventOfCode19 {


    public enum OpCode {
        ADD = 1,
        MLP = 2,
        MOV = 3,
        OUT = 4,
        JMP_TRUE = 5,
        JMP_FALSE = 6,
        LESS_THAN = 7,
        EQ = 8,
        ABORT = 99
    }

    class Instruction {
        private OpCode opCode;
        public OpCode OpCode {
            get { return opCode; }
            set { opCode = value; }
        }

        private int param1;
        public int Param1 {
            get { return param1; }
            set { param1 = value; }
        }

        private int param2;
        public int Param2 {
            get { return param2; }
            set { param2 = value; }
        }

        private int param3;
        public int Param3 {
            get { return param3; }
            set { param3 = value; }
        }

        public ParameterMode Mode {
            get {
                return mode;
            }

            set {
                mode = value;
            }
        }

        private ParameterMode mode;


        public Instruction(OpCode opCode, int param1, int param2, int param3) {
            OpCode = opCode;
            Param1 = param1;
            Param2 = param2;
            Param3 = param3;
        }


    }


    public class Day2 {
        private const string INPUT_FILE_PATH = @"..\..\Tasks\Day2\input.txt";
        private int[] memory;
        private int[] originalMemory;

        public Day2() {
            string[] fileLines = SantasLittleHelperClass.TextfileToStringArray(INPUT_FILE_PATH);
            List<int> program = new List<int>();

            for (int i = 0; i < fileLines.Length; i++) {
                string[] split = fileLines[i].Split(',');
                for (int j = 0; j < split.Length; j++) {
                    program.Add(SantasLittleHelperClass.StringToInt(split[j]));
                }
            }
            originalMemory = program.ToArray();
        }


        private int executeInstruction(Instruction inst, int[] program) {
            int value1 = program[inst.Param1];
            int value2 = program[inst.Param2];
            if (inst.OpCode == OpCode.ADD) return value1 + value2;
            if (inst.OpCode == OpCode.MLP) return value1 * value2;
            return 0;
        }

        public int[] runShipComputer(int[] program) {

            for (int iPt = 0; iPt < program.Length; iPt += 4) {
                OpCode opCode = (OpCode)program[iPt];

                if (!Enum.IsDefined(typeof(OpCode), opCode)) throw new ArgumentException();
                if (opCode == OpCode.ABORT) break;

                int ad1 = iPt + 1;
                int ad2 = iPt + 2;
                int ad3 = iPt + 3;
                int param1 = program[ad1];
                int param2 = program[ad2];
                int outParam = program[ad3];

                Instruction inst = new Instruction(opCode, param1, param2, outParam);

                program[inst.Param3] = executeInstruction(inst, program);


            }
            return program;
        }

        public int solveProblem1() {
            resetMemory();

            // "Bug fix"
            memory[1] = 12;
            memory[2] = 2;

            return runShipComputer(memory)[0];
        }

        public int solveProblem2() {
            for (int noun = 0; noun < 100; noun++) {
                for (int verb = 0; verb < 100; verb++) {
                    resetMemory();

                    memory[1] = noun;
                    memory[2] = verb;

                    int[] result = runShipComputer(memory);
                    if (result[0] == 19690720) {
                        return 100 * noun + verb;
                    }
                }
            }
            throw new Exception("This should never have happened, Problem is UNSOLVABLE!!!");
        }

        private void resetMemory() {
            memory = new int[originalMemory.Length];
            originalMemory.CopyTo(memory, 0);
        }

    }



}
