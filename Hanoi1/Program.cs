using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanoi1
{
    internal class Program
    {
        static void HanoiTowers(string startRod, string midRod, string destRod, int n)
        {
            
                if (n == 1)

            {
                Console.WriteLine($"{startRod} -> {destRod}");
                return;
            }
            HanoiTowers(startRod, destRod, midRod, n - 1);
            HanoiTowers(startRod, midRod, destRod, 1);
            HanoiTowers(midRod, startRod, destRod, n-1);
        }
        static void Main(string[] args)
        {
            HanoiTowers("1", "2", "3", 4);
        }
    }
}