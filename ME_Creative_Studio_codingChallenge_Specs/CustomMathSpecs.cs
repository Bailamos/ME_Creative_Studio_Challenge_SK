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
            float pbase = 3;
            int exponent = 3;
            float expected = 27;

            float result = CustomMath.Pow(pbase, exponent);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Pow_ShouldReturnSameNumberWhenExponentIs1()
        {
            float pbase = 3;
            int exponent = 1;
            float expected = 3;

            float result = CustomMath.Pow(pbase, exponent);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Pow_ShouldCalulatePowerOfFloatValue()
        {
            float pbase = 2.5f;
            int exponent = 2;
            float expected = 6.25f;

            float result = CustomMath.Pow(pbase, exponent);
           
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Pow_ShouldReturn1WhenExponentIs0()
        {
            float pbase = 3;
            int exponent = 0;
            float expected = 1;

            float result = CustomMath.Pow(pbase, exponent);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Abs_ShouldReturnPositiveNumberWhenGivenNegativeNumber()
        {
            float numberToAbs = -5;
            float expected = 5;

            float result = CustomMath.Abs(numberToAbs);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Abs_ShouldReturnSameNumberWhenGivenPositiveNumber()
        {
            float numberToAbs = 5;
            float expected = 5;

            float result = CustomMath.Abs(numberToAbs);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Root_ShouldCalculateSquareRoot()
        {
            float rBase = 4;
            int root = 2;
            float expected = 2;
            float epsilon = 0.00001f;

            float result = CustomMath.Root(rBase, root, epsilon);

            Assert.AreEqual(expected, result);
        }

       /* [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Root_ShouldThrowExceptionWhenBaseHasMoreThen19Digits()
        {
            float rBase = 12345678901234567890;
            int root = 2;
            float epsilon = 0.00001f;

            float result = CustomMath.Root(rBase, root, epsilon);
        }*/

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Root_ShouldThrowExceptionWhenRootIsLowerThen1()
        {
            float rBase = 1;
            int root = 0;
            float epsilon = 0.00001f;

            float result = CustomMath.Root(rBase, root, epsilon);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Root_ShouldThrowExceptionWhenRootIsHigherThen10()
        {
            float rBase = 1;
            int root = 11;
            float epsilon = 0.00001f;

            float result = CustomMath.Root(rBase, root, epsilon);
        }
    }
}
