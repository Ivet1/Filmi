using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        List<string> clients = Console.ReadLine().Split(',').ToList();
        while (true)
        {
            string str = Console.ReadLine();
            if (str == "Add owner") clients.Add(Console.ReadLine());
            else
                if (str == "Add owner on position")
            {
                string temp = Console.ReadLine();
                int pos = int.Parse(Console.ReadLine());
                clients.Insert(pos, temp);
            }
            else
                if (str == "Remove owner on position")
            {
                int pos = int.Parse(Console.ReadLine());
                clients.RemoveAt(pos);
            }
            else
                if (str == "Remove last owner") clients.RemoveAt(clients.Count - 1);
            else
                if (str == "Remove first owner") clients.RemoveAt(0);
            else break;
        }
        Console.WriteLine(string.Join(" ", clients));


    }
}