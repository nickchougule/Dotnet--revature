//4.StringBuilder

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Assignment_day2
//{
//    internal class Section4
//    {
//        static void Main()
//        {
//            string s = "Hello" + "World";
//            string template = $"User:{Environment.UserName},Date:{DateTime.Today:d}";
//            Console.WriteLine($"String:{s}");
//            Console.WriteLine($"{template}");

//            var sb = new StringBuilder();
//            sb.Append("Hello").AppendLine();
//            sb.AppendFormat("{0}item", 5);
//            string result = sb.ToString();

//            Console.WriteLine(result);


//        }
//    }
//}