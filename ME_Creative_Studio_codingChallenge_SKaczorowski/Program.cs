using System;

namespace ME_Creative_Studio_codingChallenge_SKaczorowski
{
    class Program
    {

        static void Main(string[] args)
        {
            long number;
            int root;
            double epsilon = 0.0001d;
            System.Console.WriteLine(CustomMath.Pow(1.234567m, 3));
            System.Console.WriteLine(CustomMath.Pow(1.234567d, 3));
            try
            {
                Console.WriteLine("Input number");
                number = long.Parse(Console.ReadLine());
                Console.WriteLine("Input root");
                root = int.Parse(Console.ReadLine());

                decimal value = CustomMath.Root(number, root, epsilon);
                Console.WriteLine("{0} th root of number {1} is: {2} with estimated max error of: {3}", root, number, value, epsilon);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
