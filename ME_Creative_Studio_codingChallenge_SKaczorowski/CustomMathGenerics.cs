namespace ME_Creative_Studio_codingChallenge_SKaczorowski
{
    public static partial class CustomMath
    {
        private static Type PowGeneric<Type>(Type n, int exponent)
        {
            dynamic powPartial;
            dynamic number = n;
            dynamic returnWhenExponent0 = 1;

            if (exponent == 0)
                return returnWhenExponent0;

            if (exponent % 2 == 1)
            {
                powPartial = Pow(number, (exponent - 1) / 2);
                return number * powPartial * powPartial;
            }

            powPartial = Pow((dynamic) number, exponent / 2);
            return powPartial * powPartial;
        }

        private static Type AbsGeneric<Type>(Type n)
        {
            dynamic number = n;

            return number > 0 ? number : -number;
        }
    }
}