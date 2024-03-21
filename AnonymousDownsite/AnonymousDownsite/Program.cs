using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousDownsite
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            double securityKey = double.Parse(Console.ReadLine());
            double siteVisits = 0;
            double siteCommercialPricePerVisit = 0;
            double totallLoss = 0;
            List<string> webSites = new List<string>();
            for (int i = 0; i < count; i++)
            {
                var array = Console.ReadLine().Split(' ').ToArray();
                siteVisits = int.Parse(array[1]);
                siteCommercialPricePerVisit = double.Parse(array[2]);
                totallLoss = totallLoss + (siteVisits * siteCommercialPricePerVisit);
                webSites.Add(array[0]);


            }
            var result = Math.Pow(securityKey, count);
            foreach (var sites in webSites)
            {
                Console.WriteLine(sites);
            }
            Console.WriteLine("Total Loss: {totallLoss:f20}");
            Console.WriteLine($"Security Token: {result}");
        }
    }
}