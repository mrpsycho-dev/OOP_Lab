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
            Console.WriteLine("Enter Floating Point Value: ");
            str = Console.ReadLine();
            float num = float.Parse(str);
            Console.WriteLine("The Flaoting Value is: ");
            Console.Write(num);
            Console.ReadKey();
        }
    }
}