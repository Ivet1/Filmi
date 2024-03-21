namespace ConsoleApp19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n=int.Parse(Console.ReadLine());
            for (int i = 1; i < n; i++)
            {
                int totalLength = int.Parse(Console.ReadLine());
                decimal width = decimal.Parse(Console.ReadLine());
                int wingLength = int.Parse(Console.ReadLine());
                decimal totalYears = (totalLength * totalLength) * (width + (2 * wingLength));
                Console.WriteLine(totalYears);
        }
        }
    }
}