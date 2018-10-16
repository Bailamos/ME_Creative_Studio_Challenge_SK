using System;
using ME_Creative_Studio_codingChallenge_SKaczorowski;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ME_Creative_Studio_coddingChallenge_Specs
{
    [TestClass]
    public class CustomMathSpecs
    {
        [TestMethod]
        public void Pow_ForBase3AndExponent3ShouldReturn27()
        {
            double pbase = 3;
            int exponent = 3;
            double expected = 27;

            double result = CustomMath.Pow(pbase, exponent);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Pow_ShouldReturnSameNumberWhenExponentIs1()
        {
            double pbase = 3;
            int exponent = 1;
            double expected = 3;

            double result = CustomMath.Pow(pbase, exponent);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Pow_ShouldReturn1WhenExponentIs0()
        {
            double pbase = 3;
            int exponent = 0;
            double expected = 1;

            double result = CustomMath.Pow(pbase, exponent);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Abs_ShouldReturnPositiveNumberWhenGivenNegativeNumber()
        {
            double numberToAbs = -5;
            double expected = 5;

            double result = CustomMath.Abs(numberToAbs);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Abs_ShouldReturnSameNumberWhenGivenPositiveNumber()
        {
            double numberToAbs = 5;
            double expected = 5;

            double result = CustomMath.Abs(numberToAbs);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Root_ShouldCalculateSquareRootOfNumberWithinGivenEpsilon()
        {
            long rBase = 4;
            int root = 2;
            double epsilon = 0.01;

            double result = CustomMath.Root(rBase, root, epsilon);

            Assert.IsTrue(CustomMath.Abs((result * result) - rBase) < epsilon);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Root_ShouldThrowExceptionWhenRbaseIsToLongerThan17()
        {
            long rBase = 123456789123456789;
            int root = 2;
            double epsilon = 0.01;

            double result = CustomMath.Root(rBase, root, epsilon);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Root_ShouldThrowExceptionWhenRootIsLowerThan1()
        {
            long rBase = 4;
            int root = 0;
            double epsilon = 0.01;

            double result = CustomMath.Root(rBase, root, epsilon);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Root_ShouldThrowExceptionWhenRootIsHigherThan10()
        {
            long rBase = 4;
            int root = 11;
            double epsilon = 0.01;

            double result = CustomMath.Root(rBase, root, epsilon);
        }
    }
}
