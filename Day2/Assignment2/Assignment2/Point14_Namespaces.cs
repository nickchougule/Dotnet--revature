using System;
using MyApp.Utilities;

namespace MyApp
{
    class Program
    {
        static void Main()
        {
            Helper.Display();
        }
    }
}

namespace MyApp.Utilities
{
    class Helper
    {
        public static void Display()
        {
            Console.WriteLine("Namespace & Using Example Executed");
        }
    }
}
