using System;
using ME_Creative_Studio_codingChallenge_SKaczorowski;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ME_Creative_Studio_coddingChallenge_Tests
{
    [TestClass]
    public class CustomMathTests
    {
        [TestMethod]
        public void Pow_ForBase3AndExponent3ShouldReturn27()
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

        [TestMethod]
        public void Root_ShouldCalculateSquareRootOfNumberWithinGivenEpsilon()
        {
            long number = 4;
            int root = 2;
            double epsilon = 0.01;

            decimal result = CustomMath.Root(number, root, epsilon);

            Assert.IsTrue(CustomMath.Abs((result * result) - number) < (decimal)epsilon);
        }

        [TestMethod]
        public void Root_ShouldCalculate10thRootOfNumberWithinGivenEpsilon()
        {
            long number = 1024;
            int root = 10;
            double epsilon = 0.01;

            decimal result = CustomMath.Root(number, root, epsilon);


            Assert.IsTrue(CustomMath.Abs(
                (result * result * result * result * result *
                result * result * result * result * result ) - number) < (decimal)epsilon);
        }

        [TestMethod]
        public void Root_ShouldCalculate10thRootOfLargeNumberWithinGivenEpsilon()
        {
            long number = 99999999999999999;
            int root = 10;
            double epsilon = 0.01;

            decimal result = CustomMath.Root(number, root, epsilon);


            Assert.IsTrue(CustomMath.Abs(
                (result * result * result * result * result *
                result * result * result * result * result) - number) < (decimal)epsilon);
        }

        [TestMethod]
        public void Root_ShouldCalculateSquareRootOfLargeNumberWithinGivenEpsilon()
        {
            long number = 99999999999999999;
            int root = 2;
            double epsilon = 0.01;

            decimal result = CustomMath.Root(number, root, epsilon);

            Assert.IsTrue(CustomMath.Abs((result * result) - number) < (decimal)epsilon);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Root_ShouldThrowExceptionWhenRbaseIsLongerThan17()
        {
            long number = 123456789123456789;
            int root = 2;
            double epsilon = 0.01;

            decimal result = CustomMath.Root(number, root, epsilon);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Root_ShouldThrowExceptionWhenRootIsLowerThan1()
        {
            long number = 4;
            int root = 0;
            double epsilon = 0.01;

            decimal result = CustomMath.Root(number, root, epsilon);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Root_ShouldThrowExceptionWhenRootIsHigherThan10()
        {
            long number = 4;
            int root = 11;
            double epsilon = 0.01;

            decimal result = CustomMath.Root(number, root, epsilon);
        }
    }
}
