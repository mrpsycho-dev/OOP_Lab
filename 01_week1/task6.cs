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
            String str;
            str = Console.ReadLine();
            Console.WriteLine("You have inputted: ");
            int num = int.Parse(str);
            Console.WriteLine("The number is: ");
            Console.Write(num);
            Console.ReadKey();
        }
    }
}