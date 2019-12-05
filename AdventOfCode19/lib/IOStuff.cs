using System;
using System.Collections.Generic;

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

        public static int[] intToDigitArray(int value) {
            List<int> digits = new List<int>();
            for (; value != 0; value /= 10) {
                digits.Add(value % 10);
            }
            digits.Reverse();
            return digits.ToArray();
        }
    }
}
