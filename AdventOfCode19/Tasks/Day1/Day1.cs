using AdventOfCode19.lib;
using System;

namespace AdventOfCode19 {
    public class Day1 {

        // private const string INPUT_FILE_PATH = "C:\\Users\\dkassel\\Desktop\\AdventOfCode19\\AdventOfCode19\\Tasks\\Day1\\input.txt";
        private const string INPUT_FILE_PATH = @"..\..\Tasks\Day1\input.txt";

        /*
         * Fuel calculation description:
         * Fuel required to launch a given module is based on its mass. Specifically, to find the fuel 
         * required for a module, take its mass, divide by three, round down, and subtract 2. For example:
         * - For a mass of 12, divide by 3 and round down to get 4, then subtract 2 to get 2.
         * - For a mass of 14, dividing by 3 and rounding down still yields 4, so the fuel required is also 2.
         * - For a mass of 1969, the fuel required is 654.
         * - For a mass of 100756, the fuel required is 33583.
         */
        /// <summary>
        /// Takes the mass as an integer and calculates the appropriate fuel quantity.
        /// </summary>
        /// <param name="mass"></param>
        /// <returns>The calculate fuel as a integer value.</returns>
        public int calculateFuel(int mass) {
            return (mass / 3) - 2;
        }

        public void calcTotalFuelRequirement() {
            string[] fileLines = SantasLittleHelperClass.textfileToStringArray(INPUT_FILE_PATH);
            int[] masses = new int[fileLines.Length];
            for (int i = 0; i < fileLines.Length; i++) {
                masses[i] = SantasLittleHelperClass.stringToInt(fileLines[i]);
            }
            int fuelReq = 0;
            for (int i = 0; i < masses.Length; i++) {
                fuelReq += calculateFuel(masses[i]);
            }
            Console.WriteLine(fuelReq);
        }
    }
}
