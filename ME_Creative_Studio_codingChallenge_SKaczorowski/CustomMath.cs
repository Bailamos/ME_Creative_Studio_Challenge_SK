using System;

namespace ME_Creative_Studio_codingChallenge_SKaczorowski
{
    public static class CustomMath
    {
        public static double Abs(double number)
        {
            return number > 0 ? number : -number;
        }

        public static decimal Abs(decimal number)
        {
            return number > 0 ? number : -number;
        }

        public static double Pow(double number, int exponent)
        {
            double powPartial;

            if (exponent == 0)
            {
                return 1.0d;
            }

            if (exponent % 2 == 1)
            {
                powPartial = Pow(number, (exponent - 1) / 2);
                return number * powPartial * powPartial;
            }

            powPartial = Pow(number, exponent / 2);
            return powPartial * powPartial;
        }

        public static decimal Pow(decimal number, int exponent)
        {
            decimal powPartial;

            if (exponent == 0)
            {
                return 1.0m;
            }

            if (exponent % 2 == 1)
            {
                powPartial = Pow(number, (exponent - 1) / 2);
                return number * powPartial * powPartial;
            }

            powPartial = Pow(number, exponent / 2);
            return powPartial * powPartial;
        }

        //66666666666666666
        //99999999999999999
        public static decimal Root(long number, int root, double epsilon)
        {
            if (!IsRootInputValidate(number, root))
                throw new ArgumentOutOfRangeException("root base should have maximum 17 digits and root should be between 1 and 10");
            
            double rootValueEstimated = number;
            double currentError = Abs(number - Pow(rootValueEstimated, root));
            double previousError;
        
            while (epsilon < currentError)
            {
                previousError = currentError;
                rootValueEstimated = (1 / (double)root) * (((double)root - 1) * rootValueEstimated + number / Pow(rootValueEstimated, root - 1));
                currentError = Abs(number - Pow(rootValueEstimated, root));

                if (previousError <= currentError)
                {
                    decimal valueEstimatedPrecise = RootWithEnchancedPrecision(rootValueEstimated, number, root, epsilon);
                    return valueEstimatedPrecise;
                }
            }

            return (decimal)rootValueEstimated;
        }

        private static decimal RootWithEnchancedPrecision(double currentEstimatedValue, long number, int root, double epsilon)
        {
            decimal rootValueEstimatedPrecise = (decimal)currentEstimatedValue;
            decimal currentError = Abs(number - Pow(rootValueEstimatedPrecise, root));
            decimal previousError;

            while ((decimal)epsilon < currentError)
            {
                previousError = currentError;
                rootValueEstimatedPrecise = (1 / (decimal)root) * (((decimal)root - 1) * rootValueEstimatedPrecise + number / Pow(rootValueEstimatedPrecise, root - 1));
                currentError = Abs(number - Pow(rootValueEstimatedPrecise, root));

                if (previousError <= currentError)
                {                
                    break;
                }
            }

            return rootValueEstimatedPrecise;
        }

        private static bool IsRootInputValidate(long number, int root)
        {
            if (root > 0 && root <= 10 && 
                number.ToString().Length > 0  && number.ToString().Length <= 17)
                return true;
            return false;
        }
    }
}
