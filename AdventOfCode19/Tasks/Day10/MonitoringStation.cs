using System;
using System.Collections.Generic;
using System.Windows;

namespace AdventOfCode19.Tasks.Day10 {
    public class MonitoringStation {

        private string[] fileLines2 = {
                                        ".#..#",
                                        ".....",
                                        "#####",
                                        "....#",
                                        "...##" };

        private string[] fileLines = {
                                        "#.#.#",
                                        ".....",
                                        "#.#.#",
                                        ".....",
                                        "#.#.#" };

        public Point[] line(int x, int y, int x2, int y2) {
            int w = x2 - x;
            int h = y2 - y;
            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
            if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
            if (h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
            if (w < 0) dx2 = -1; else if (w > 0) dx2 = 1;
            int longest = Math.Abs(w);
            int shortest = Math.Abs(h);
            if (!(longest > shortest)) {
                longest = Math.Abs(h);
                shortest = Math.Abs(w);
                if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
                dx2 = 0;
            }
            int numerator = longest >> 1;
            List<Point> points = new List<Point>();
            for (int i = 0; i <= longest; i++) {
                //putpixel(x, y, color);
                points.Add(new Point(x, y));
                Console.WriteLine(x + " " + y);
                numerator += shortest;
                if (!(numerator < longest)) {
                    numerator -= longest;
                    x += dx1;
                    y += dy1;
                }
                else {
                    x += dx2;
                    y += dy2;
                }
            }
            return points.ToArray();
        }

        public Point[] getAsteroids() {
            List<Point> asteroids = new List<Point>();

            for (int i = 0; i < fileLines.Length; i++) {
                string line = fileLines[i];
                for (int j = 0; j < line.Length; j++) {
                    char c = line[j];
                    if (c == '#') asteroids.Add(new Point(j, i));
                }
            }
            return asteroids.ToArray();
        }
        /*
        new Point(1,0);
        new Point(4,0);
        new Point(0,2);
        new Point(1,2);
        new Point(2,2);
        new Point(3,2);
        new Point(4,2);
        new Point(4,3);
        new Point(3,4);
        new Point(4,4);
        */

        public void print() {
            Point[] asteroids = getAsteroids();

            Dictionary<int, Point> result = getSteigungen(new Point(0, 2), asteroids);
            Console.WriteLine("print", result.Count.ToString());
        }

        public Dictionary<int, Point> getSteigungen(Point p, Point[] asteroids) {
            Dictionary<int, Point> d = new Dictionary<int, Point>();
            foreach (var asteroid in asteroids) {
                if (asteroid != p) {
                    var steigung = calcSteigung(p, asteroid);
                    Console.WriteLine("Steigung " + steigung);
                    if (!d.ContainsKey(steigung)) d.Add(steigung, asteroid);
                }
            }
            return d;
        }

        public int calcSteigung(Point p1, Point p2) {
            int deltaY = (int)(p2.Y - p1.Y);
            int deltaX = (int)(p2.X - p1.X);
            //Console.WriteLine("deltaX " + deltaX + " deltaY " + deltaY);
           
            if (deltaX == 0 && deltaY < 0)
                return -999999;
            if (deltaX == 0 && deltaY >= 0)
                return 999999;
            if (deltaY == 0 && deltaX < 0)
                return -100000;
            if (deltaY == 0 && deltaX >= 0)
                return 100000;
            return deltaY / deltaX;
        }
    }
}
