using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode19.lib;

namespace AdventOfCode19 {
    public class Day4 {
        private const string input = "172930-683082";
        private readonly int min;
        private readonly int max;

        public Day4() {
            var minAndMaxVal = input.Split('-');
            if (minAndMaxVal.Length != 2) throw new ArgumentException("wrong kind of input string, must be two numbers seperated by a '-'");

            min = SantasLittleHelperClass.stringToInt(minAndMaxVal[0]);
            max = SantasLittleHelperClass.stringToInt(minAndMaxVal[1]);

            if (min > max) throw new ArgumentException("wrong kind of input string, first number must be smaller than the second");
        }

        public int solveTask1() {
            return getPossiblePasswords().Count();
        }

        public int solveTask2() {
            List<int> possiblePws = getPossiblePasswords();
            List<int> possibleSuperSpecialPws = new List<int>();

            foreach (int pw in possiblePws) {
                if (isSuperSpecialValidPassword(pw)) possibleSuperSpecialPws.Add(pw);
            }
            return possibleSuperSpecialPws.Count();
        }

        private List<int> getPossiblePasswords() {
            List<int> possiblePasswords = new List<int>();
            for (int pw = min; pw <= max; pw++) {
                if (isValidPassword(pw)) possiblePasswords.Add(pw);
            }
            return possiblePasswords;
        }

        public bool isValidPassword(int pw) {
            int[] pwDigits = SantasLittleHelperClass.intToDigitArray(pw);

            // It is a six-digit number.
            if (pwDigits.Length != 6) return false;
            //Two adjacent digits are the same (like 22 in 122345).
            if (!areThereAdjacentDigits(pwDigits)) return false;
            //Going from left to right, the digits never decrease; they only ever increase or stay the same (like 111123 or 135679).
            if (!doDigitsIncrease(pwDigits)) return false;

            return true;
        }

        private bool doDigitsIncrease(int[] pw) {
            int formerNr = 0;
            for (int i = 0; i < pw.Length; i++) {
                int number = pw[i];
                if (formerNr > number) return false;
                else formerNr = number;
            }
            return true;
        }

        private bool areThereAdjacentDigits(int[] pw) {
            for (int i = 0; i < 5; i++) {
                int number = pw[i];
                int adjNumber = pw[i + 1];
                if (number == adjNumber) return true;
            }
            return false;
        }


        public bool isSuperSpecialValidPassword(int pw) {
            int[] pwDigits = SantasLittleHelperClass.intToDigitArray(pw);

            int nr = pwDigits[0];
            int end = pwDigits.Length - 1;

            if (nr == pwDigits[1] && nr != pwDigits[2]) return true;
            nr = pwDigits[end];
            if (nr == pwDigits[end - 1] && nr != pwDigits[end - 2]) return true;

            for (int i = 1; i < end - 1; i++) {
                int current = pwDigits[i];
                int before = pwDigits[i - 1]; ;
                int next = pwDigits[i + 1]; ;
                int afterNext = pwDigits[i + 2]; ;
                if (current == next && current != before && current != afterNext) return true;
            }
            return false;
        }
    }
}