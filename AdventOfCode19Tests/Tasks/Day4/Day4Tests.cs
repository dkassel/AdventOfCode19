using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode19.Tests {
    [TestClass()]
    public class Day4Tests {
        [TestMethod()]
        public void isValidPassword() {
            Day4 day4 = new Day4();
            Assert.IsTrue(day4.isValidPassword(111111));
            Assert.IsFalse(day4.isValidPassword(223450));
            Assert.IsFalse(day4.isValidPassword(123789));
        }

        [TestMethod()]
        public void isSuperSpecialValidPassword() {
            Day4 day4 = new Day4();
            Assert.IsTrue(day4.isSuperSpecialValidPassword(112233));
            Assert.IsFalse(day4.isSuperSpecialValidPassword(123444));
            Assert.IsTrue(day4.isSuperSpecialValidPassword(111122));

        }
    }
}