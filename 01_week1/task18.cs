using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRewards
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=================================================");
            Console.WriteLine("  KamyabLife Autonomous Pizza Drone Rewards  ");
            Console.WriteLine("=================================================\n");

            // Standard Test Case from Lab Manual:
            Console.WriteLine("Running Test Case: pizza_points(5, 20)");
            pizza_points(5, 20);

            Console.WriteLine("\n-------------------------------------------------");
            Console.WriteLine("Enter custom criteria to test:");
            Console.Write("Enter minimum orders (N): ");
            string nInput = Console.ReadLine();
            
            if (!string.IsNullOrWhiteSpace(nInput) && int.TryParse(nInput, out int minOrders))
            {
                Console.Write("Enter minimum order price (Y): ");
                if (int.TryParse(Console.ReadLine(), out int minPrice))
                {
                    Console.WriteLine($"\nResults for pizza_points({minOrders}, {minPrice}):");
                    pizza_points(minOrders, minPrice);
                }
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void pizza_points(int minOrders, int minPrice)
        {
            string filePath = "Customers.txt";

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Error: Customers.txt not found.");
                return;
            }

            string[] lines = File.ReadAllLines(filePath);
            bool anyQualified = false;

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                int openBracketIndex = line.IndexOf('[');
                int closeBracketIndex = line.IndexOf(']');

                if (openBracketIndex == -1 || closeBracketIndex == -1) continue;
                string headerPart = line.Substring(0, openBracketIndex).Trim();
                int lastSpaceIndex = headerPart.LastIndexOf(' ');
                if (lastSpaceIndex == -1) continue;

                string customerName = headerPart.Substring(0, lastSpaceIndex).Trim();
                string ordersBody = line.Substring(openBracketIndex + 1, closeBracketIndex - openBracketIndex - 1).Trim();
                string[] orderStrings = ordersBody.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                int qualifyingCount = 0;
                foreach (string orderStr in orderStrings)
                {
                    if (int.TryParse(orderStr.Trim(), out int price))
                    {
                        if (price >= minPrice)
                        {
                            qualifyingCount++;
                        }
                    }
                }

                if (qualifyingCount >= minOrders)
                {
                    Console.WriteLine($"\"{customerName}\"");
                    anyQualified = true;
                }
            }

            if (!anyQualified)
            {
                Console.WriteLine("No customers currently qualify for a free pizza.");
            }
        }
    }
}