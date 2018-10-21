using System;

namespace ME_Creative_Studio_codingChallenge_SKaczorowski
{
    class Program
    {

        static void Main(string[] args)
        {
            long number;
            int root;

            try
            {
                Console.WriteLine("Input number");
                number = long.Parse(Console.ReadLine());
                Console.WriteLine("Input root");
                root = int.Parse(Console.ReadLine());

                decimal value = CustomMath.Root(number, root);             
                Console.WriteLine("{0} th root of number {1} is: {2}", root, number, value);
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
