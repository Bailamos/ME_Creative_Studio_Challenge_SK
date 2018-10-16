using System;

namespace ME_Creative_Studio_codingChallenge_SKaczorowski
{
    public static class CustomMath
    {
        public static double Abs(double value)
        {
            return value > 0 ? value : -value;
        }

        public static double Pow(double powbase, int exponent)
        {
            double result = 1.0f;

            if (exponent == 0)
            {
                return result;
            }

            if (exponent % 2 == 1)
            {
                return powbase * Pow(powbase, (exponent - 1) / 2) * Pow(powbase, (exponent - 1) / 2);
            }

            return Pow(powbase, exponent / 2) * Pow(powbase, exponent / 2);
        }

        public static double Root(long rBase, int root, double epsilon)
        {
            if (!IsRootInputValidate(rBase, root))
                throw new ArgumentOutOfRangeException("root base should have maximum 19 digits and root should be between 0 and 10");

            double valueEstimated = rBase;
            while (epsilon < Abs(rBase - Pow(valueEstimated, root)))
            {
                //double v = Pow(valueEstimated, root);
                //Console.WriteLine("Przyblizona wartosc: " + v + " Blad+ " + Abs(rBase - v));
               
                valueEstimated = (1 / (double)root) * (((double)root - 1) * valueEstimated + rBase / Pow(valueEstimated, root - 1));
            }

            return valueEstimated;
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
