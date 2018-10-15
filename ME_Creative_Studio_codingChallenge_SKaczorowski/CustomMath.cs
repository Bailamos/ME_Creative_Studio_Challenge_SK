using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ME_Creative_Studio_codingChallenge_SKaczorowski
{
    public static class CustomMath
    {
        public static float Abs(float value)
        {
            return value > 0 ? value : -value;
        }

        public static float Pow(float powbase, int exponent)
        {
            float result = 1.0f;

            if (exponent == 0)
            {
                return result;
            }

            for (int i = 0; i < exponent; i++)
            {
                result *= powbase;
            }

            return result;
        }

        public static float Root(float rBase, int root, float epsilon)
        {
            if (!IsRootInputValidate(rBase, root))
                throw new ArgumentOutOfRangeException("root base should have maximum 19 digits and root should be between 0 and 10");

            float xprevious = rBase;
            float xnext;

            float floatRoot = (float)root;
            while (epsilon < CustomMath.Abs(rBase - CustomMath.Pow(xprevious, root)))
            {
                xnext = (1 / floatRoot) * ((floatRoot - 1) * xprevious + rBase / CustomMath.Pow(xprevious, root - 1));
                xprevious = xnext;
            }

            return xprevious;
    
        }

        private static bool IsRootInputValidate(float rBase, int root)
        {
            string rBaseString = rBase.ToString("r").Replace(",", "");
            System.Console.WriteLine(rBaseString + " length: " + rBaseString.Length + " value " + rBase.ToString("r"));
            if ((root >= 0 && root <= 10) && rBaseString.Length < 19)
                return true;
            return false;
        }
    }
}
