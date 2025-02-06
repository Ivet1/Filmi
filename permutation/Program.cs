using System;
using System.Collections.Generic;
using System.Linq;
using Combinatorics.Collections;

namespace permutation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter up to 5 numbers:");
            string input = Console.ReadLine();
            string[] numberStrings = input.Split(' ');

            if (numberStrings.Length > 5)
            {
                Console.WriteLine("You can only enter up to 5 numbers.");
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

            var permutations = new Permutations<int>(numbers);

            List<int[]> cutePermutations = new List<int[]>(); 

            foreach (var perm in permutations)
            {
                if (CountSpins(perm.ToArray()) % 2 == 0)
                {
                    cutePermutations.Add(perm.ToArray()); 
                }
            }

            Console.WriteLine("Cute permutations:");
            foreach (var cutePerm in cutePermutations)
            {
                Console.WriteLine(string.Join(" ", cutePerm)); 
            }
        }

        static int CountSpins(int[] perm)
        {
            int spins = 0;
            for (int i = 0; i < perm.Length - 1; i++)
            {
                if (perm[i] > perm[i + 1])
                {
                    spins++;
                }
            }
            return spins;
        }
    }
}
