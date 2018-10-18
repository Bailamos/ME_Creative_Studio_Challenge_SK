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

            while (true) {
                try
                {
                    Console.WriteLine("Input number");
                    number = long.Parse(System.Console.ReadLine());
                    Console.WriteLine("Input root");
                    root = int.Parse(Console.ReadLine());

                    decimal value = CustomMath.Root(number, root, epsilon);
                    Console.WriteLine(root + "th root of number " + number + " is: " + value + " with estimated max error of: " + epsilon);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
