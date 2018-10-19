using System;

namespace ME_Creative_Studio_codingChallenge_SKaczorowski
{
    public static partial class CustomMath
    {
        public static double Abs(double number)
        {
            return AbsGeneric(number);
        }

        public static decimal Abs(decimal number)
        {
            return AbsGeneric(number);
        }

        public static double Pow(double number, int exponent)
        {
            return PowGeneric(number, exponent);
        }

        public static decimal Pow(decimal number, int exponent)
        {
            return PowGeneric(number, exponent);
        }

        public static decimal Root(long number, int root, double epsilon)
        {
            if (!IsRootInputValid(number, root))
                throw new ArgumentOutOfRangeException("number should have maximum 17 digits and root should be between 1 and 10");

            double rootValueEstimated = number;
            double currentError = Abs(number - Pow(rootValueEstimated, root));
            double previousError;

            while (epsilon < currentError)
            {
                previousError = currentError;
                rootValueEstimated = (1.0d / root) * ((root - 1.0d) * rootValueEstimated + number / Pow(rootValueEstimated, root - 1));
                currentError = Abs(number - Pow(rootValueEstimated, root));

                if (previousError <= currentError)
                {
                    decimal valueEstimatedPrecise = RootWithEnhancedPrecision(rootValueEstimated, number, root, epsilon);
                    return valueEstimatedPrecise;
                }
            }

            return (decimal)rootValueEstimated;
        }

        private static decimal RootWithEnhancedPrecision(double currentEstimatedValue, long number, int root, double epsilon)
        {
            decimal rootValueHighPrecisionEstimated = (decimal)currentEstimatedValue;
            decimal currentError = Abs(number - Pow(rootValueHighPrecisionEstimated, root));
            decimal previousError;

            while ((decimal)epsilon < currentError)
            {
                previousError = currentError;
                rootValueHighPrecisionEstimated = (1.0m / root) * ((root - 1.0m) * rootValueHighPrecisionEstimated + number / Pow(rootValueHighPrecisionEstimated, root - 1));
                currentError = Abs(number - Pow(rootValueHighPrecisionEstimated, root));

                if (previousError <= currentError)
                    break;
            }

            return rootValueHighPrecisionEstimated;
        }

        private static bool IsRootInputValid(long number, int root)
        {
            return root > 0 && root <= 10 &&
                number.ToString().Length > 0 && number.ToString().Length <= 17;
        }
    }

}
