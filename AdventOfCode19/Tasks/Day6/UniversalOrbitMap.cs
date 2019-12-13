
using AdventOfCode19.lib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode19.Tasks.Day6 {

    public class Planet {
        public Planet inOrbitOf;
        public string name;
        public Planet(string name, Planet inOrbitOf) {
            this.inOrbitOf = inOrbitOf;
            this.name = name;
        }

        public Planet(string name) {
            this.name = name;
            inOrbitOf = null;
        }

        /// <summary>
        /// The total number of direct orbits and indirect orbits.
        /// </summary>
        public int getOrbitCountChecksum() {
            Planet p = inOrbitOf;
            int cntOfPlanets = 0;
            while (p != null) {
                cntOfPlanets++;
                p = p.inOrbitOf;
            }
            return cntOfPlanets;
        }

        public Planet[] getAllOrbits() {
            Planet p = inOrbitOf;
            List<Planet> list = new List<Planet>();
            while (p != null) {
                list.Add(p);
                p = p.inOrbitOf;
            }
            return list.ToArray(); ;
        }

        public int howManyStepsToReachAPlanet(string destinationName) {
            var orbits = getAllOrbits().ToArray();
            for (int i = 0; i < orbits.Length; i++) {
                if (orbits[i].name == destinationName) return i;
            }
            return -1;
        }
    }

    public class UniversalOrbitMap {

        private const string INPUT_FILE_PATH = @"..\..\Tasks\Day6\input.txt";
        private string[] exampleMap = {
            "COM)B",
            "B)C",
            "C)D",
            "D)E",
            "E)F",
            "B)G",
            "G)H",
            "D)I",
            "E)J",
            "J)K",
            "K)L"
        };

        private string[] exampleMap2 = {
            "COM)B",
            "B)C",
            "C)D",
            "D)E",
            "E)F",
            "B)G",
            "G)H",
            "D)I",
            "E)J",
            "J)K",
            "K)L",
            "K)YOU",
            "I)SAN"
        };


        public int solveTask2() {
            var map = createMap(getCommandsFromFile());

            Planet YOU;
            map.TryGetValue("YOU", out YOU);
            Planet SANTA;
            map.TryGetValue("SAN", out SANTA);

            var YOU_Orbits = YOU.getAllOrbits();
            var SANTA_Orbits = SANTA.getAllOrbits();
            Planet destination = YOU_Orbits.Intersect(SANTA_Orbits).First();
            return YOU.howManyStepsToReachAPlanet(destination.name) + SANTA.howManyStepsToReachAPlanet(destination.name);
        }

        public int solveTask1() {
            int sum = totalNumberDirectIndirectOrbits(createMap(getCommandsFromFile()));
            return sum;
        }

        public int totalNumberDirectIndirectOrbits(Dictionary<string, Planet> orbitMap) {
            int totalSum = 0;
            foreach (var entry in orbitMap) {
                Planet p = entry.Value;
                totalSum += p.getOrbitCountChecksum();
            }
            return totalSum;
        }

        private string[] getCommandsFromFile() {
            return SantasLittleHelperClass.textfileToStringArray(INPUT_FILE_PATH);
        }

        public Dictionary<string, Planet> createMap(string[] input) {
            Dictionary<string, Planet> orbitMap = new Dictionary<string, Planet>();
            foreach (string line in input) {
                string[] split = line.Split(')');
                if (split.Length != 2) throw new ArgumentException("somethings wrong with the input");
                string name_planet1 = split[0];
                string name_planet2 = split[1];

                if (!orbitMap.ContainsKey(name_planet1))
                    orbitMap.Add(name_planet1, new Planet(name_planet1));

                Planet planet1;
                orbitMap.TryGetValue(name_planet1, out planet1);

                if (!orbitMap.ContainsKey(name_planet2))
                    orbitMap.Add(name_planet2, new Planet(name_planet2));

                Planet planet2;
                orbitMap.TryGetValue(name_planet2, out planet2);
                planet2.inOrbitOf = planet1;
            }
            return orbitMap;
        }

    }
}
