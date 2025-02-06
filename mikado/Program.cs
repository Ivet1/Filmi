using System;
using System.Collections.Generic;
using System.Linq;

namespace MikadoGame
{
    class Program
    {
        static List<int>[] graph;   // Списъци със зависимости (граф)
        static int[] inDegree;      // Брои колко клечки лежат върху всяка клечка (входна степен)
        static List<int> result = new List<int>();  // Резултатът за текущото сортиране
        static List<List<int>> allResults = new List<List<int>>();  // Всички валидни сортирания

        static void Main(string[] args)
        {
            // Четене на броя на клечките
            int n = int.Parse(Console.ReadLine());

            // Инициализация на графа и входните степени
            graph = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }
            inDegree = new int[n];

            // Четене на зависимостите (двойки числа)
            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "hopstop")
                {
                    break;
                }

                var sticks = input.Split().Select(int.Parse).ToArray();
                int a = sticks[0];
                int b = sticks[1];

                // Клечка a лежи върху клечка b (b не може да се вземе преди a)
                graph[a].Add(b);
                inDegree[b]++;
            }

            // Генериране на всички възможни валидни редове
            FindAllTopologicalSorts(n);

            // Извеждане на резултатите
            foreach (var validOrder in allResults)
            {
                Console.WriteLine(string.Join(" -> ", validOrder));
            }
        }

        // Backtracking функция за намиране на всички валидни топологични сортирания
        static void FindAllTopologicalSorts(int n)
        {
            bool isSorted = false;

            for (int i = 0; i < n; i++)
            {
                // Ако можем да извадим текущата клечка (входна степен == 0)
                if (inDegree[i] == 0)
                {
                    // "Махаме" клечката временно от купчината
                    result.Add(i);
                    inDegree[i] = -1;  // Маркираме клечката като вече взета

                    // Намаляме входната степен на зависимите клечки
                    foreach (int neighbor in graph[i])
                    {
                        inDegree[neighbor]--;
                    }

                    // Рекурсия за следващите клечки
                    FindAllTopologicalSorts(n);

                    // Възстановяване на състоянието (backtrack)
                    result.RemoveAt(result.Count - 1);
                    inDegree[i] = 0;
                    foreach (int neighbor in graph[i])
                    {
                        inDegree[neighbor]++;
                    }

                    isSorted = true;
                }
            }

            // Ако всички клечки са взети (намиране на едно валидно сортиране)
            if (!isSorted)
            {
                allResults.Add(new List<int>(result));
            }
        }
    }
}