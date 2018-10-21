using System;

namespace ME_Creative_Studio_codingChallenge_SKaczorowski
{
    public static partial class CustomMath
    {
        private const decimal TARGET_EPSILON = 0.000001m;

        public static decimal Abs(decimal number)
        {
            return number > 0 ? number : -number;
        }

        public static decimal Pow(decimal number, int exponent)
        {
            decimal powPartial;

            if (exponent == 0)
                return 1.0m;

            try
            {
                if (exponent % 2 == 1)
                {
                    powPartial = Pow(number, (exponent - 1) / 2);
                    return number * powPartial * powPartial;
                }

                powPartial = Pow(number, exponent / 2);
                return powPartial * powPartial;

            }
            catch (OverflowException)
            {
                return decimal.MaxValue;
            }
        }

        public static decimal Root(long number, int root)
        {
            if (!IsRootInputValid(number, root))
                throw new ArgumentOutOfRangeException("number should have maximum 17 digits and root should be between 1 and 10");

            decimal rootEstimation = number;
            decimal currentError = Abs(number - Pow(rootEstimation, root));
            decimal previousError;

            while (TARGET_EPSILON < currentError)
            {
                previousError = currentError;
                decimal rootEstimationTmp = (1.0m / root) * ((root - 1.0m) * rootEstimation + number / Pow(rootEstimation, root - 1));
                currentError = Abs(number - (Pow(rootEstimationTmp, root)));

                if (previousError <= currentError && currentError < number)
                    break;

                rootEstimation = rootEstimationTmp;
            }

            return rootEstimation;
        }

        private static bool IsRootInputValid(long number, int root)
        {
            return root > 0 && root <= 10 &&
                number.ToString().Length > 0 && number.ToString().Length <= 17;
        }
    }

}
