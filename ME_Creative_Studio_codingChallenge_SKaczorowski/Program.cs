using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ME_Creative_Studio_codingChallenge_SKaczorowski
{
    class Program
    {
       
        static void Main(string[] args)
        {
            float number;
            int root;
            float epsilon = 0.00001f;
            
            System.Console.WriteLine("Input number");
            number = float.Parse(System.Console.ReadLine());        
            System.Console.WriteLine("Input root");
            root = int.Parse(System.Console.ReadLine());

            try
            {
                float value = CustomMath.Root(number, root, epsilon);
                System.Console.WriteLine(root + "th root of number " + number + " is: " + value + " with estimated max error of: " + epsilon);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                System.Console.WriteLine(ex);
            }
        }
    }
}
