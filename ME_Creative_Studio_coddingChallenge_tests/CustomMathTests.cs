using System;
using ME_Creative_Studio_codingChallenge_SKaczorowski;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ME_Creative_Studio_coddingChallenge_Tests
{
    [TestClass]
    public class CustomMathTests
    {
        private const double PERCENTAGE_ERROR = 0.0000001d;

        [TestMethod]
        public void Pow_ShouldRaiseNumberToGivenExponent()
        {
            double number = 3;
            int exponent = 3;
            double expected = 27;

            double result = CustomMath.Pow(number, exponent);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Pow_ShouldReturnSameNumberWhenExponentIs1()
        {
            double number = 3;
            int exponent = 1;
            double expected = 3;

            double result = CustomMath.Pow(number, exponent);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Pow_ShouldReturn1WhenExponentIs0()
        {
            double number = 3;
            int exponent = 0;
            double expected = 1;

            double result = CustomMath.Pow(number, exponent);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Abs_ShouldReturnPositiveNumberWhenGivenNegativeNumber()
        {
            double number = -5;
            double expected = 5;

            double result = CustomMath.Abs(number);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Abs_ShouldReturnSameNumberWhenGivenPositiveNumber()
        {
            double number = 5;
            double expected = 5;

            double result = CustomMath.Abs(number);
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(1024, 1)]
        [DataRow(1024, 2)]
        [DataRow(1024, 3)]
        [DataRow(1024, 4)]
        [DataRow(1024, 5)]
        [DataRow(1024, 6)]
        [DataRow(1024, 7)]
        [DataRow(1024, 8)]
        [DataRow(1024, 9)]
        [DataRow(1024, 10)]
        [DataRow(32, 5)]
        [DataRow(200, 7)]
        [DataRow(1, 2)]
        [DataRow(1, 5)]
        [DataRow(0, 2)]
        public void Root_ShouldCalculateRootOfNumber(long n, int r)
        {
            long number = n;
            int root = r;

            double result = CustomMath.Root(number, root);

            Assert.IsTrue(
                CustomMath.Abs(CustomMath.Pow(result, r) - number) <= (number * PERCENTAGE_ERROR));
        }

        [DataTestMethod]
        [DataRow(99999999999999999, 1)]
        [DataRow(99999999999999999, 2)]
        [DataRow(99999999999999999, 3)]
        [DataRow(99999999999999999, 4)]
        [DataRow(99999999999999999, 5)]
        [DataRow(99999999999999999, 6)]
        [DataRow(99999999999999999, 7)]
        [DataRow(99999999999999999, 8)]
        [DataRow(99999999999999999, 9)]
        [DataRow(99999999999999999, 10)]
        [DataRow(11111111111111111, 2)]
        [DataRow(44444444444444444, 10)]
        public void Root_ShouldCalculateRootOfLargeNumber(long n, int r)
        {
            long number = n;
            int root = r;

            double result = CustomMath.Root(number, root);

            Assert.IsTrue(
                CustomMath.Abs(CustomMath.Pow(result, r) - number) <= (number * PERCENTAGE_ERROR));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Root_ShouldThrowExceptionWhenRbaseIsLongerThan17()
        {
            long number = 123456789123456789;
            int root = 2;

            double result = CustomMath.Root(number, root);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Root_ShouldThrowExceptionWhenRootIsLowerThan1()
        {
            long number = 4;
            int root = 0;

            double result = CustomMath.Root(number, root);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Root_ShouldThrowExceptionWhenRootIsHigherThan10()
        {
            long number = 4;
            int root = 11;

            double result = CustomMath.Root(number, root);
        }
    }
}
