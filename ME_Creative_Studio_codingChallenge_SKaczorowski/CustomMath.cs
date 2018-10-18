using System;
using System.Collections.Generic;

namespace ME_Creative_Studio_codingChallenge_SKaczorowski
{
    public static class CustomMath
    {
        public static double Abs(double value)
        {
            return value > 0 ? value : -value;
        }

        public static double Pow(double powBase, int exponent)
        {
            double powPartial;

            if (exponent == 0)
            {
                return 1.0d;
            }

            if (exponent % 2 == 1)
            {
                powPartial = Pow(powBase, (exponent - 1) / 2);
                return powBase * powPartial * powPartial;
            }

            powPartial = Pow(powBase, exponent / 2);
            return powPartial * powPartial;
        }

        public static decimal Abs(decimal value)
        {
            return value > 0 ? value : -value;
        }

        public static decimal Pow(decimal powBase, int exponent)
        {
            decimal powPartial;

            if (exponent == 0)
            {
                return 1.0m;
            }

            if (exponent % 2 == 1)
            {
                powPartial = Pow(powBase, (exponent - 1) / 2);
                return powBase * powPartial * powPartial;
            }

            powPartial = Pow(powBase, exponent / 2);
            return powPartial * powPartial;
        }

        //66666666666666666
        //99999999999999999
        public static decimal Root(long rBase, int root, double epsilon)
        {
            if (!IsRootInputValidate(rBase, root))
                throw new ArgumentOutOfRangeException("root base should have maximum 17 digits and root should be between 1 and 10");
            
            double valueEstimated = rBase;
            double currentError = Abs(rBase - Pow(valueEstimated, root));
            double previousError;
        
            while (epsilon < currentError)
            {
                previousError = currentError;
                valueEstimated = (1 / (double)root) * (((double)root - 1) * valueEstimated + rBase / Pow(valueEstimated, root - 1));
                currentError = Abs(rBase - Pow(valueEstimated, root));

                if (previousError <= currentError)
                {
                    decimal valueEstimatedPrecise = RootWithEnchancedPrecision(valueEstimated, rBase, root, epsilon);
                    return valueEstimatedPrecise;
                }
            }

            return (decimal)valueEstimated;
        }

        private static decimal RootWithEnchancedPrecision(double currentEstimatedValue, long rBase, int root, double epsilon)
        {
            decimal valueEstimatedPrecise = (decimal)currentEstimatedValue;
            decimal currentError = Abs(rBase - Pow(valueEstimatedPrecise, root));
            decimal previousError;

            while ((decimal)epsilon < currentError)
            {
                previousError = currentError;
                valueEstimatedPrecise = (1 / (decimal)root) * (((decimal)root - 1) * valueEstimatedPrecise + rBase / Pow(valueEstimatedPrecise, root - 1));
                currentError = Abs(rBase - Pow(valueEstimatedPrecise, root));

                if (previousError <= currentError)
                {                
                    break;
                }
            }

            return valueEstimatedPrecise;
        }

        private static bool IsRootInputValidate(long rBase, int root)
        {
            if (root > 0 && root <= 10 && 
                rBase.ToString().Length > 0  && rBase.ToString().Length <= 17)
                return true;
            return false;
        }
    }
}
