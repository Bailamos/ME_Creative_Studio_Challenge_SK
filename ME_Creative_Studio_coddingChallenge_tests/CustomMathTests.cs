using System;
using ME_Creative_Studio_codingChallenge_SKaczorowski;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ME_Creative_Studio_coddingChallenge_Tests
{
    [TestClass]
    public class CustomMathTests
    {
        private const decimal TARGET_ERROR_ROOT = 0.000001m;
        private const decimal TARGET_ERROR_POW = 0.000001m;

        [DataTestMethod]
        [DataRow(0, 1, 0)]
        [DataRow(3, 1, 3)]
        [DataRow(-3, 1, -3)]
        [DataRow(2, 2, 4)]
        [DataRow(3, 3, 27)]
        [DataRow(4, 3, 64)]
        [DataRow(10, 2, 100)]
        [DataRow(10, 10, 10000000000)]
        [DataRow(-10, 9, -1000000000)]
        [DataRow(5.5, 2, 30.25)]
        [DataRow(3.141, 2, 9.865881)]
        [DataRow(3.1415926, 2, 9.86960406437476)]
        [DataRow(3.14159265358979, 2, 9.869604401089338)]
        public void Pow_ShouldRaiseNumberToGivenExponent(double n, int e, double exp)
        {
            decimal number = (decimal)n;
            int exponent = e;
            decimal expected = (decimal)exp;

            decimal result = CustomMath.Pow(number, exponent);

            Assert.IsTrue(CustomMath.Abs(result - expected) < TARGET_ERROR_POW);
        }

        [TestMethod]
        public void Pow_ShouldReturn1WhenExponentIs0()
        {
            decimal number = 3;
            int exponent = 0;
            decimal expected = 1;

            decimal result = CustomMath.Pow(number, exponent);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Abs_ShouldReturnPositiveNumberWhenGivenNegativeNumber()
        {
            decimal number = -5;
            decimal expected = 5;

            decimal result = CustomMath.Abs(number);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Abs_ShouldReturnSameNumberWhenGivenPositiveNumber()
        {
            decimal number = 5;
            decimal expected = 5;

            decimal result = CustomMath.Abs(number);

            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(0, 1)]
        [DataRow(0, 2)]
        [DataRow(1, 1)]
        [DataRow(1, 2)]
        [DataRow(1000, 1)]
        [DataRow(1000, 2)]
        [DataRow(1000, 3)]
        [DataRow(1000, 4)]
        [DataRow(1000, 5)]
        [DataRow(1000, 6)]
        [DataRow(1000, 7)]
        [DataRow(1000, 8)]
        [DataRow(1000, 9)]
        [DataRow(1000, 10)]
        public void Root_ShouldCalculateRootOfNumber(long n, int r)
        {
            long number = n;
            int root = r;

            decimal result = CustomMath.Root(number, root);

            Assert.IsTrue(
                CustomMath.Abs(CustomMath.Pow(result, r) - number) <= TARGET_ERROR_ROOT * number);
        }

        [DataTestMethod]
        [DataRow(11111111111111111, 2)]
        [DataRow(11111111111111111, 10)]
        [DataRow(44444444444444444, 2)]
        [DataRow(44444444444444444, 10)]
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
        public void Root_ShouldCalculateRootOfLargeNumber(long n, int r)
        {
            long number = n;
            int root = r;

            decimal result = CustomMath.Root(number, root);

            Assert.IsTrue(
                CustomMath.Abs(CustomMath.Pow(result, r) - number) <= TARGET_ERROR_ROOT * number);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Root_ShouldThrowExceptionWhenNumberIsLongerThan17()
        {
            long number = 123456789123456789;
            int root = 2;

            CustomMath.Root(number, root);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Root_ShouldThrowExceptionWhenRootIsLowerThan1()
        {
            long number = 4;
            int root = 0;

            CustomMath.Root(number, root);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Root_ShouldThrowExceptionWhenRootIsHigherThan10()
        {
            long number = 4;
            int root = 11;

            CustomMath.Root(number, root);
        }
    }
}
