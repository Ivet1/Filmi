using System;

namespace ReelSelectionDP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine()); // Времето, което Пешо трябва да запълни в секунди
            int M = int.Parse(Console.ReadLine()); // Броят на различните дължини на рийлове

            int[] reelLengths = new int[M];
            for (int i = 0; i < M; i++)
            {
                reelLengths[i] = int.Parse(Console.ReadLine()); // Прочитане на дължините на рийловете
            }

            string command = Console.ReadLine(); // Команда ("count" или "details")

            // Инициализация на dp масив
            int[] dp = new int[N + 1];
            int[] track = new int[N + 1]; // За проследяване на използваните дължини

            // Запълваме dp масива с максимална стойност (int.MaxValue)
            for (int i = 1; i <= N; i++)
            {
                dp[i] = int.MaxValue;
            }
            dp[0] = 0; // 0 рийла за време 0

            // Приложение на динамично програмиране
            for (int i = 0; i < M; i++) // За всяка дължина на рийл
            {
                for (int j = reelLengths[i]; j <= N; j++) // Обновяване на dp за всяко време j
                {
                    if (dp[j - reelLengths[i]] != int.MaxValue && dp[j - reelLengths[i]] + 1 < dp[j])
                    {
                        dp[j] = dp[j - reelLengths[i]] + 1;
                        track[j] = i; // Запомняме индекса на последно използвания рийл
                    }
                }
            }

            // Ако командата е "count", извеждаме минималния брой рийлове
            if (command.ToLower() == "count")
            {
                Console.WriteLine(dp[N]);
            }
            // Ако командата е "details", извеждаме броя на рийловете от всяка дължина
            else if (command.ToLower() == "details")
            {
                int[] reelCount = new int[M]; // За броя на рийловете от всяка дължина
                int remainingTime = N;

            
                while (remainingTime > 0)
                {
                    int reelIndex = track[remainingTime];
                    reelCount[reelIndex]++;
                    remainingTime -= reelLengths[reelIndex];
                }

                // Извеждане на резултата
                for (int i = 0; i < M; i++)
                {
                    if (reelCount[i] > 0)
                    {
                        Console.WriteLine($"{reelCount[i]} x {reelLengths[i]} seconds");
                    }
                }
            }
        }
    }
}
