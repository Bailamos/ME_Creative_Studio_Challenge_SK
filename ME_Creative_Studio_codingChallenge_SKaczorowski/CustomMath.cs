using System;

namespace ME_Creative_Studio_codingChallenge_SKaczorowski
{
    public static partial class CustomMath
    {
        private static double TARGET_EPSILON = 0.0001d;

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

            double rootValueEstimation = number;
            double currentError = Abs(number - Pow(rootValueEstimation, root));
            double previousError;

            while (TARGET_EPSILON < currentError)
            {
                previousError = currentError;
                rootValueEstimation = (1.0d / root) * ((root - 1.0d) * rootValueEstimation + number / Pow(rootValueEstimation, root - 1));
                currentError = Abs(number - (Pow(rootValueEstimation, root)));

                if (previousError <= currentError)
                    break;
            }

            return rootValueEstimation;
        }

        private static bool IsRootInputValid(long number, int root)
        {
            return root > 0 && root <= 10 &&
                number.ToString().Length > 0 && number.ToString().Length <= 17;
        }
    }

}
