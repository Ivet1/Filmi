using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradska_turgoviq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine(0);//base case - no cities, no cost
                return;
            }
            int[] costs = Array.ConvertAll(input.Split(' '), int.Parse);
            int n = costs.Length;
            if (n == 0)
            {
                Console.WriteLine(0);//base case
                return;
            }
            else if (n==1)
            {
                Console.WriteLine(costs[0]);
            }
            else if(n==2) {
                Console.WriteLine(Math.Min(costs[0], costs[1]));
                return;
            }
            int[] dp = new int[n];
            dp[0] = costs[0]; // Cost to reach first city
            dp[1] = costs[1]; // Cost to reach second city

            
            for (int i = 2; i < n; i++)
            {
                // The minimum cost to reach city i is either:
                // - Coming from city i-1 (one step)
                // - Coming from city i-2 (two steps)
                dp[i] = Math.Min(dp[i - 1], dp[i - 2]) + costs[i];
            }

            // Minimum cost to exit from the last city
            int minCost = Math.Min(dp[n - 1], dp[n - 2]);

            Console.WriteLine(minCost);
        }
    }
}
