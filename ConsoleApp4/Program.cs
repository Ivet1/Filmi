using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int k = int.Parse(Console.ReadLine()); 
        int n = int.Parse(Console.ReadLine()); 

        List<int> currentCombination = new List<int>(); 
        List<List<int>> result = new List<List<int>>(); 

        FindCombinations(k, n, 1, currentCombination, result);

        foreach (var combination in result)
        {
            Console.WriteLine(string.Join(" ", combination));
        }
    }

    static void FindCombinations(int k, int n, int start, List<int> currentCombination, List<List<int>> result)
    {
        if (currentCombination.Count == k && n == 0)
        {
            result.Add(new List<int>(currentCombination)); 
            return;
        }

        if (currentCombination.Count >= k || n <= 0)
        {
            return; 
        }

        for (int i = start; i <= 9; i++) 
        {
            currentCombination.Add(i); 
            FindCombinations(k, n - i, i + 1, currentCombination, result); 
            currentCombination.RemoveAt(currentCombination.Count - 1); 
        }
    }
}
