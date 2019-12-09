﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode19.Tests {
    [TestClass()]
    public class Day3Tests {
        [TestMethod()]
        public void findMinIntersectionDistance() {

            Day3 day3 = new Day3();
            int distance = day3.findMinIntersectionDistance("R75,D30,R83,U83,L12,D49,R71,U7,L72".Split(','), "U62,R66,U55,R34,D71,R55,D58,R83".Split(','));
            Assert.AreEqual(159, distance);

            distance = day3.findMinIntersectionDistance("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51".Split(','), "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7".Split(','));
            Assert.AreEqual(135, distance);

            distance = day3.findMinIntersectionDistance("U7,R6,D4,L4".Split(','), "R8,U5,L5,D3".Split(','));
            Assert.AreEqual(6, distance);
        }
    }
}