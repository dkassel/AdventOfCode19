
using AdventOfCode19.lib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode19.Tasks.Day7 {
    enum PhaseSetting {
        Zero, One, Two, Three, Four
    }
    class Amplifier {
        private IntCodeComputer computer = new IntCodeComputer();
        public int RunAmplifier(int[] program, PhaseSetting phaseSetting, int inputSignal) {
            int[] inputs = { (int)phaseSetting, inputSignal };
            computer.RunProgram(program, inputs);
            if (computer.outputList.Count == 1)
                return computer.outputList[0];
            else throw new ArgumentException();
        }
    }

    public class AmplificationCircuit {
        private const string InputFilePath = @"..\..\Tasks\Day7\AmplifierControllerSoftware.txt";

        public AmplificationCircuit() {
            //amplifiers = new Amplifier[] { amplifierA, amplifierB, amplifierC, amplifierD };
        }

        private int[] inputFileToIntArray() {
            string[] fileLines = SantasLittleHelperClass.TextfileToStringArray(InputFilePath);
            List<int> program = new List<int>();
            for (int i = 0; i < fileLines.Length; i++) {
                string[] split = fileLines[i].Split(',');
                for (int j = 0; j < split.Length; j++) {
                    program.Add(SantasLittleHelperClass.StringToInt(split[j]));
                }
            }
            return program.ToArray();
        }

        public void SolveTask1() {
            var program = inputFileToIntArray();
            int[][] phaseCombinations = GetPermutationsArray(new int[] { 0, 1, 2, 3, 4 });
            int highestSignal = 0;
            foreach (int[] combination in phaseCombinations) {
                int signal = StartAmplificationCircuit(program, combination);
                if (signal > highestSignal) highestSignal = signal;
            }
            Console.WriteLine(highestSignal);
        }

        public void SolveTask2() {
            var program = inputFileToIntArray();
            int[][] phaseCombinations = GetPermutationsArray(new int[] { 5, 6, 7, 8, 9 });

            int highestSignal = 0;
            foreach (int[] combination in phaseCombinations) {
                int signal = StartAmplificationCircuit(program, combination);
                if (signal > highestSignal) highestSignal = signal;
            }
            Console.WriteLine(highestSignal);
        }

        public int StartAmplificationCircuit(int[] program, int[] phaseSettings) {
            int inputSignal = 0;
            for (int phaseIndex = 0; phaseIndex < phaseSettings.Length; phaseIndex++) {
                inputSignal = new Amplifier().RunAmplifier(program, (PhaseSetting)phaseSettings[phaseIndex], inputSignal);
            }
            return inputSignal;
        }


        public void StartFeedbackLoop() {

        }

        private int[][] GetPermutationsArray(int[] numberSet) {
            var permutationsCollection = GetPermutations(numberSet, numberSet.Length).ToArray();
            List<int[]> combinations = new List<int[]>();
            int i = 0;
            foreach (var permutation in permutationsCollection) {
                combinations.Add(permutation.ToArray());
                i++;
            }
            return combinations.ToArray();
        }


        static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length) {
            if (length == 1) return list.Select(t => new T[] { t });
            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(o => !t.Contains(o)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }
    }
}
