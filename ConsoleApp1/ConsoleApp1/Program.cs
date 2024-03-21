namespace ConsoleApp1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> data = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, Dictionary<string, int>> cache = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();
            while (input != "thetinggoesskrra")
            {
                string[] tokens = input.Split(new[] { "->", "|", " " }, StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length == 1)
                {
                    string dataSet = tokens[0];
                    if (!data.ContainsKey(dataSet))
                    {
                        data[dataSet] = new Dictionary<string, int>();
                    }
                    if (cache.ContainsKey(dataSet))
                    {
                        foreach (var kvp in cache[dataSet])
                        {
                            data[dataSet][kvp.Key] = kvp.Value;
                        }
                        cache.Remove(dataSet);
                    }
                }
                else
                {
                    string dataKey = tokens[0];
                    int dataSize = int.Parse(tokens[1]);
                    string dataSet = tokens[2];
                    if (!data.ContainsKey(dataSet))
                    {
                        if (!cache.ContainsKey(dataSet))
                        {
                            cache[dataSet] = new Dictionary<string, int>();
                        }
                        cache[dataSet][dataKey] = dataSize;
                    }
                    else
                    {
                        data[dataSet][dataKey] = dataSize;
                        if (cache.ContainsKey(dataSet))
                        {
                            foreach (var kvp in cache[dataSet])
                            {
                                data[dataSet][kvp.Key] = kvp.Value;
                            }
                            cache.Remove(dataSet);
                        }
                    }
                }
                input = Console.ReadLine();
            }

            var dataSetSizes = data
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Values.Sum()
                );
            var dataSetMaxSize = dataSetSizes.Max(kvp => kvp.Value);
            var maxDataSet = dataSetSizes
                .FirstOrDefault(kvp => kvp.Value == dataSetMaxSize)
                .Key;
            if (maxDataSet != null)
            {
                Console.WriteLine($"Data Set: {maxDataSet}, Total Size: {dataSetMaxSize}");
                foreach (var kvp in data[maxDataSet])
                {
                    Console.WriteLine($"${kvp.Key}");
                }
            }
        }
    }
}