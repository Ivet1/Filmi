using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int k=int.Parse(Console.ReadLine());
            int n =int.Parse(Console.ReadLine());
            FindCombinations(k, n, 1, new List<int>());
        }
        static void FindCombinations (int k, int n, int start,List<int> current)
        {
            if (current.Count == k && n==0)
            {
                Console.WriteLine(string.Join(",", current));
                return;
            }
            for (int i = start; i < n; i++)
            {
                if (n - 1 < 0) break;
                current.Add(i);
                FindCombinations(k, n-1,i+1,current);
                current.RemoveAt(current.Count-1);
            }
        }
    }
}
