using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode19.Tasks.Day8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode19.Tasks.Day8.Tests {
    [TestClass()]
    public class Day8Tests {
        private Day8 d = new Day8();

        [TestMethod()]
        public void countNumberOccourenceInLayerTest() {
            Pixel[] test = { 0, 0, 0, Pixel.TRP, Pixel.TRP, Pixel.WHT };
            Assert.AreEqual(d.countNumberOccourenceInLayer(test, 0), 3);
            Assert.AreEqual(d.countNumberOccourenceInLayer(test, Pixel.TRP), 2);
            Assert.AreEqual(d.countNumberOccourenceInLayer(test, Pixel.WHT), 1);
        }
    }
}