using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double machinePrice = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());
            CheckWashingMachinePurchase(age, machinePrice, toyPrice);

            Console.ReadKey();
        }

        static void CheckWashingMachinePurchase(int age, double machinePrice, int toyPrice)
        {
            double savedCash = 0.0;
            double currentCashGift = 10.0;
            int toyCount = 0;
            int cashBirthdayCount = 0;

            for (int birthday = 1; birthday <= age; birthday++)
            {
                if (birthday % 2 == 0)
                {
                    savedCash += currentCashGift;
                    currentCashGift += 10.0;
                    cashBirthdayCount++;
                }
                else
                {
                    toyCount++;
                }
            }

            double brotherDeduction = cashBirthdayCount * 1.0;
            double toyRevenue = toyCount * toyPrice;

            double totalSavings = (savedCash - brotherDeduction) + toyRevenue;

            if (totalSavings >= machinePrice)
            {
                double remaining = totalSavings - machinePrice;
                Console.WriteLine("Yes! {0:F2}", remaining);
            }
            else
            {
                double shortfall = machinePrice - totalSavings;
                Console.WriteLine("No! {0:F2}", shortfall);
            }
        }
    }
}