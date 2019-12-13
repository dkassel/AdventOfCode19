using System;
using System.Windows;

namespace AdventOfCode19 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
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
            int solution1 = d.runThermalEnvironmentSupervisionTerminal(1);
            Console.WriteLine("Solution 1 " + solution1);

            int solution2 = d.runThermalEnvironmentSupervisionTerminal(5);
            Console.WriteLine("Solution 2 " + solution2);
        }
    }
}
