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

            try
            {
                System.Console.WriteLine("Input number");
                number = long.Parse(System.Console.ReadLine());
                System.Console.WriteLine("Input root");
                root = int.Parse(System.Console.ReadLine());

                decimal value = CustomMath.Root(number, root, epsilon);
                System.Console.WriteLine(root + "th root of number " + number + " is: " + value + " with estimated max error of: " + epsilon);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}
