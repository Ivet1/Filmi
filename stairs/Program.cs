using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stairs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            Console.WriteLine(CountWays(N));
        }
        static int CountWays(int N)
        {
if (N==1)
            {
                return 1;
            }
if (N==2) { 
                return 2;
            }
int[] dp = new int[N+1];
            dp[1] = 1;
            dp[2] = 2;
            for(int i=3; i<N; i++)
            {
                dp[i] = dp[i-1]+ dp[i-2];
            }
            return dp[N];
        }
    }
}
