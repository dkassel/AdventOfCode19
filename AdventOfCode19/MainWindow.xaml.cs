using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            day2.runProgram();
        }
    }
}
