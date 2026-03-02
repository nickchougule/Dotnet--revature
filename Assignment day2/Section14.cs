using System;
using System.Text; // brings StringBuilder into scope

namespace Assignment_day2
{
    internal class Section14
    {
        static void Main(string[] args)
        {
            Worker worker = new Worker();

            StringBuilder sb = new StringBuilder();
            sb.Append("Worker created successfully");

            Console.WriteLine(sb.ToString());
        }
    }

    public class Worker
    {
        // Empty by design — placeholder class
    }
}
