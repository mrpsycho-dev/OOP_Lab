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
            // Reading Lilly's age [1 ... 77]
            int age = int.Parse(Console.ReadLine());

            // Reading Washing machine price [1.00 ... 10,000.00]
            double machinePrice = double.Parse(Console.ReadLine());

            // Reading unit price of each toy [0 ... 40]
            int toyPrice = int.Parse(Console.ReadLine());

            // Calling function to compute financial feasibility
            CheckWashingMachinePurchase(age, machinePrice, toyPrice);

            Console.ReadKey();
        }

        /// <summary>
        /// Calculates total savings accumulated across Lilly's birthdays
        /// and determines whether she can afford the washing machine.
        /// </summary>
        /// <param name="age">Lilly's age in years (1 - 77)</param>
        /// <param name="machinePrice">Price of the washing machine</param>
        /// <param name="toyPrice">Unit price for selling each toy</param>
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
                    // Even birthday: receives money
                    savedCash += currentCashGift;
                    currentCashGift += 10.0;
                    cashBirthdayCount++;
                }
                else
                {
                    // Odd birthday: receives a toy
                    toyCount++;
                }
            }

            // Brother takes 1.00 USD from each cash birthday
            double brotherDeduction = cashBirthdayCount * 1.0;
            double toyRevenue = toyCount * toyPrice;

            // Total net funds saved
            double totalSavings = (savedCash - brotherDeduction) + toyRevenue;

            // Evaluating purchase feasibility
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