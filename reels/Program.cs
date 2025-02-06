using System;
using System.Collections.Generic;
using System.Linq;

class Reels
{
    static int MinReelsCount(int N, List<int> reels)
    {
        int count = 0;
        foreach (var reel in reels)
        {
            while (N >= reel)
            {
                N -= reel;
                count++;
            }
        }
        return count;
    }

    static Dictionary<int, int> MinReelsDetails(int N, List<int> reels)
    {
        Dictionary<int, int> reelCounts = new Dictionary<int, int>();
        foreach (var reel in reels)
        {
            while (N >= reel)
            {
                N -= reel;
                if (!reelCounts.ContainsKey(reel))
                {
                    reelCounts[reel] = 0;
                }
                reelCounts[reel]++;
            }
        }
        return reelCounts;
    }

    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int M = int.Parse(Console.ReadLine());
        List<int> reels = new List<int>();

        for (int i = 0; i < M; i++)
        {
            reels.Add(int.Parse(Console.ReadLine()));
        }

        string command = Console.ReadLine();

        if (command == "count")
        {
            Console.WriteLine(MinReelsCount(N, reels));
        }
        else if (command == "details")
        {
            var result = MinReelsDetails(N, reels);
            foreach (var reel in result.OrderByDescending(x => x.Key))
            {
                Console.WriteLine($"{reel.Value} x {reel.Key} seconds");
            }
        }
    }
}