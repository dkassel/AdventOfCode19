using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode19.lib {
    class SantasLittleHelperClass {

        public static string[] textfileToStringArray(string txtFilePath) {
            try {
                return System.IO.File.ReadAllLines(txtFilePath);
            }
            catch (System.IO.FileNotFoundException ex) {
                Console.WriteLine(ex.Message);
            }
            return new string[0];
        }

        public static int stringToInt(string input) {
            try {
                return int.Parse(input);
            }
            catch (FormatException) {
                Console.WriteLine("Unable to parse " + input);
            }
            return -1;
        }

        public static int[] stringArrayToIntArray(string[] input) {
            int[] result = new int[input.Length];
            for (int j = 0; j < input.Length; j++) {
                result[j] = SantasLittleHelperClass.stringToInt(input[j]);
            }
            return result;
        }

        public static int[] intToDigitArray(int value) {
            List<int> digits = new List<int>();
            for (; value != 0; value /= 10) {
                digits.Add(value % 10);
            }
            digits.Reverse();
            return digits.ToArray();
        }

        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length) {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }
    }
}
