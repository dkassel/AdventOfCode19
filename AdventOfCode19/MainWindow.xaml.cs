using AdventOfCode19.Tasks.Day10;
using AdventOfCode19.Tasks.Day12;
using AdventOfCode19.Tasks.Day13;
using AdventOfCode19.Tasks.Day6;
using AdventOfCode19.Tasks.Day7;
using AdventOfCode19.Tasks.Day8;
using AdventOfCode19.Tasks.Day9;
using System;
using System.Windows;

namespace AdventOfCode19 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            AmplificationCircuit c = new AmplificationCircuit();
            //c.SolveTask1();
            //c.SolveTask2();

            SensorBoost s = new SensorBoost();
            s.Tests();

            ArcadeCabinet ac = new ArcadeCabinet();
            ac.solveTask1();            
            /*
            N_BodyProblem prob = new N_BodyProblem();
            
            */

        }

        private void btn_day1_Click(object sender, RoutedEventArgs e) {
            Day1 day1 = new Day1();
            day1.calcTotalFuelRequirement();

        }

        private void btn_day2_Click(object sender, RoutedEventArgs e) {
            Day2 day2 = new Day2();
            int solution = day2.solveProblem1();
            Console.WriteLine("Problem 1 solution: " + solution);

            int solution2 = day2.solveProblem2();
            Console.WriteLine("Problem 2 solution: " + solution2);
        }

        private void btn_day3_Click(object sender, RoutedEventArgs e) {
            Day3 day3 = new Day3();
            day3.solveTask2();
        }

        private void btn_day4_Click(object sender, RoutedEventArgs e) {
            Day4 day4 = new Day4();
            int solution = day4.solveTask1();
            Console.WriteLine("This is it: " + solution);

            int solution2 = day4.solveTask2();
            Console.WriteLine("This is it for 2: " + solution2);
        }

        private void btn_day6_Click(object sender, RoutedEventArgs e) {
            UniversalOrbitMap map = new UniversalOrbitMap();
            Console.WriteLine("Task 1 answer = " + map.solveTask1());
            Console.WriteLine("Task 2 answer = " + map.solveTask2());

        }

        private void btn_day5_Click(object sender, RoutedEventArgs e) {
            Day5 d = new Day5();
            int[] inputArray = { 1 };
            int solution1 = d.runThermalEnvironmentSupervisionTerminal(inputArray);
            Console.WriteLine("Solution 1 " + solution1);
            Console.WriteLine(4511442 == solution1);
            inputArray[0] = 5;
            int solution2 = d.runThermalEnvironmentSupervisionTerminal(inputArray);
            Console.WriteLine("Solution 2 " + solution2);
            Console.WriteLine(12648139 == solution2);

            /*
            Day8 d = new Day8();
            d.solveTask1();
            d.solveTask2();
            */
        }

        private void btn_day10_Click(object sender, RoutedEventArgs e) {
            MonitoringStation s = new MonitoringStation();
            s.print();
            Console.WriteLine("Button 10 clicked");
        }
    }
}
