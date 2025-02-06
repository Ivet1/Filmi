using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Combinatorics;
using Combinatorics.Collections;

namespace morse_code
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number n");
            int n = int.Parse(Console.ReadLine());
            if (n < 0 || n >= 20)
            {
                Console.WriteLine("N should be between 0 and 20");
                return;
            }
            string[] morseCode = new string[n];
            Console.WriteLine("Enter morse code, each with length n");
            for (int i = 0; i < n; i++)
            {
                string code;
                do
                {
                    code = Console.ReadLine();
                    if (code.Length != n)
                    {
                        Console.WriteLine("The morse code length must be exactly " + n + " symbols.");
                    }
                } while (code.Length != n);

                morseCode[i] = code;
            }

            var combinations = new Combinations<string>(morseCode, n, GenerateOption.WithRepetition);
            foreach(var  comb in combinations)
            {

                Console.WriteLine(string.Join("", comb));
            }
        }
        }
    }

