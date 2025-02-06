using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha1._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter three numbers.");
            string input = Console.ReadLine();
            string[] numberStrings = input.Split(' ');
            if (numberStrings.Length != 3 ) 
            {
                Console.Write("Invalid input");
                return;
            }
            int[] numbers;
            try
            {
                numbers = Array.ConvertAll(numberStrings, int.Parse);
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter valid integers.");
                return;
            }
            Array.Sort(numbers);
            int median = numbers[1];
            int totalDistance= Math.Abs(numbers[0]- median)
                + Math.Abs(numbers[1]- median)
                + Math.Abs(numbers[2]- median);
            Console.WriteLine(totalDistance);


        }
    }
}
