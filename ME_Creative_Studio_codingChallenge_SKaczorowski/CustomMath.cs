using System;

namespace ME_Creative_Studio_codingChallenge_SKaczorowski
{
    public static partial class CustomMath
    {
        private const double TARGET_EPSILON = 0.000001d;

        public static double Abs(double number)
        {
            return number > 0 ? number : -number;
        }

        public static double Pow(double number, int exponent)
        {
            double powPartial;

            if (exponent == 0)
                return 1.0d;

            if (exponent % 2 == 1)
            {
                powPartial = Pow(number, (exponent - 1) / 2);
                return number * powPartial * powPartial;
            }

            powPartial = Pow(number, exponent / 2);
            return powPartial * powPartial;
        }

        public static double Root(long number, int root)
        {
            if (!IsRootInputValid(number, root))
                throw new ArgumentOutOfRangeException("number should have maximum 17 digits and root should be between 1 and 10");

            double rootEstimation = number;
            double currentError = Abs(number - Pow(rootEstimation, root));
            double previousError;

            while (TARGET_EPSILON < currentError)
            {
                previousError = currentError;
                double rootEstimationTmp = (1.0d / root) * ((root - 1.0d) * rootEstimation + number / Pow(rootEstimation, root - 1));
                currentError = Abs(number - (Pow(rootEstimationTmp, root)));

                if (previousError <= currentError)
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
