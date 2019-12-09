using AdventOfCode19.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace AdventOfCode19 {

    public class Day3 {
        private const string INPUT_FILE_PATH = @"..\..\Tasks\Day3\input.txt";

        private string[] wire1_dirs;
        private string[] wire2_dirs;

        public Day3() {
            try {
                loadDirectionsFromFile();
            }
            catch (Exception e) { }
        }

        private void loadDirectionsFromFile() {
            string[] input = SantasLittleHelperClass.textfileToStringArray(INPUT_FILE_PATH);
            List<string> directions = new List<string>();

            for (int i = 0; i < input.Length; i++) {
                directions.Add(input[i]);
            }

            wire1_dirs = directions.ToArray()[0].Split(',');
            wire2_dirs = directions.ToArray()[1].Split(',');
        }

        public int solveTask1() {
            int minDistance = findMinIntersectionDistance(wire1_dirs, wire2_dirs);
            Console.WriteLine(minDistance);
            return minDistance;
        }

        public int solveTask2() {
            int dist = findMinIntersectionDistance(wire1_dirs, wire2_dirs);

            Dictionary<Point, int> wire1_dic = instructionsToWireDictionary(wire1_dirs);
            Dictionary<Point, int> wire2_dic = instructionsToWireDictionary(wire2_dirs);
            var intersections = wire1_dic.Keys.Intersect(wire2_dic.Keys).ToList();

            List<int> totalDistances = new List<int>();

            foreach (Point p in intersections) {
                int distance1;
                int distance2;
                wire1_dic.TryGetValue(p, out distance1);
                wire2_dic.TryGetValue(p, out distance2);
                totalDistances.Add(distance1 + distance2);
            }
            totalDistances.Min();
            Console.WriteLine(totalDistances.Min());
            return totalDistances.Min();

        }

        private int findMinDistance(List<Point> intersections) {
            List<int> distances = new List<int>();
            foreach (Point p in intersections) {
                distances.Add(calculateDistance(p));
            }
            return distances.Min();
        }

        public int findMinIntersectionDistance(string[] wire1_instructions, string[] wire2_instructions) {
            List<Point> wire1_set = handleInstruction(wire1_instructions);
            List<Point> wire2_set = handleInstruction(wire2_instructions);

            List<Point> intersections = wire1_set.Intersect(wire2_set).ToList();

            return findMinDistance(intersections);
        }

        private int calculateDistance(Point p) {
            int x = Math.Abs(Convert.ToInt32(p.X));
            int y = Math.Abs(Convert.ToInt32(p.Y));
            return x + y;
        }

        private List<Point> handleInstruction(string[] instructions) {
            int x = 0;
            int y = 0;
            List<Point> result = new List<Point>();
            foreach (string instruction in instructions) {
                char c = instruction[0];
                int steps = SantasLittleHelperClass.stringToInt(instruction.Substring(1));

                int step = (c == 'D') || (c == 'L') ? -1 : 1;

                int goal = 0;
                if (c == 'U') {
                    goal = y + steps;
                    while (y < goal) {
                        y += step;
                        result.Add(new Point(x, y));
                    }
                }
                else if (c == 'D') {
                    goal = y - steps;
                    while (y > goal) {
                        y += step;
                        result.Add(new Point(x, y));
                    }
                }
                else if (c == 'R') {
                    goal = x + steps;
                    while (x < goal) {
                        x += step;
                        result.Add(new Point(x, y));
                    }
                }
                else if (c == 'L') {
                    goal = x - steps;
                    while (x > goal) {
                        x += step;
                        result.Add(new Point(x, y));
                    }
                }
            }
            return result;
        }

        private Dictionary<Point, int> instructionsToWireDictionary(string[] instructions) {
            Dictionary<Point, int> result = new Dictionary<Point, int>();
            int wire_length = 0;
            int x = 0;
            int y = 0;

            foreach (string instruction in instructions) {
                char c = instruction[0];
                int steps = SantasLittleHelperClass.stringToInt(instruction.Substring(1));


                int step = (c == 'D') || (c == 'L') ? -1 : 1;

                int goal = 0;
                if (c == 'U') {
                    goal = y + steps;
                    while (y < goal) {
                        y += step;
                        wire_length++;
                        try {
                            result.Add(new Point(x, y), wire_length);
                        }
                        catch (Exception e) { }
                    }
                }
                else if (c == 'D') {
                    goal = y - steps;
                    while (y > goal) {
                        y += step;
                        wire_length++;
                        try {
                            result.Add(new Point(x, y), wire_length);
                        }
                        catch (Exception e) { }
                    }
                }
                else if (c == 'R') {
                    goal = x + steps;
                    while (x < goal) {
                        x += step;
                        wire_length++;
                        try {
                            result.Add(new Point(x, y), wire_length);
                        }
                        catch (Exception e) { }
                    }
                }
                else if (c == 'L') {
                    goal = x - steps;
                    while (x > goal) {
                        x += step;
                        wire_length++;
                        try {
                            result.Add(new Point(x, y), wire_length);
                        }
                        catch (Exception e) { }
                    }
                }
            }
            return result;

        }

    }
}
