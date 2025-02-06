using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Combinatorics;
using Combinatorics.Collections;

namespace reverse_lottery
{
    internal class Program
    {
        static void Main(string[] args)
        {
      int k =int.Parse(Console.ReadLine());
            int n =int.Parse(Console.ReadLine());
            if (k == 0)
            {
                Console.WriteLine("No combinations possible for K=0.");
                return;
            }
            if (k < 0 || k > 10 || n < 1 || n > 49)
            {
                Console.WriteLine("Invalid input values.");
                return;
            }
            List<int> elements = new List<int>();
            for(int i=0; i<=n; i++)
            {
elements.Add(i);
            }
            var combinations = new Combinations<int>(elements, k);
         foreach (var combination in combinations)
            {
                Console.WriteLine(string.Join(".", combination));
            }
        }
    }
}
