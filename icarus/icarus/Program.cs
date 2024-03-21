using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
namespace icarus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int start=int.Parse(Console.ReadLine());
            int initialDamage = 1;
            string command=Console.ReadLine();
            
            while (command != "Supernova")
            {
                string[] sequence = command.Split(' ');
                int steps = int.Parse(sequence[1]);  
                string direction = sequence[0];

                if (command == "right")
                {
                    for (int i = 0; i < steps; i++)
                    {
                         start++;
                        if(start > nums.Count - 1)
                        {
                            start -= nums.Count;
                            initialDamage++;
                        }
                        nums[start] -= initialDamage;
                    }
                }

                else if (command == "left")
                {
                    for(int j=0;j<steps;j++)
                    {
                        start--;
                        if (start== -1)
                        {
                            start += nums.Count;
                            initialDamage++;
                        }
                        nums[start] -= initialDamage;
                    }
                }
                command = Console.ReadLine();


            }
            Console.WriteLine(String.Join(" ",nums));
           
        }
    }
}