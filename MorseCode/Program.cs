using System;
using System.Collections.Generic;

namespace morse_code
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            string[] morseCode = new string[N];

            for (int i = 0; i < N; i++)
            {
                morseCode[i] = Console.ReadLine();
            }

            GenerateAndPrintCombinations(morseCode, N);
        }
        static void GenerateAndPrintCombinations(string[] morseCode, int N)
        {
            int numberOfCodes = morseCode.Length;
            List<string> results = new List<string>();
            for (int i = 0; i < numberOfCodes; i++)
            {
                for (int j = 0; j < numberOfCodes; j++)
                {
                   
                    results.Add(morseCode[i] + morseCode[j]);
                }
            }

            foreach (var combination in results)
            {
                Console.WriteLine(combination);
            }
        }
    }
}

