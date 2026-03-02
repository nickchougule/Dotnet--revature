//using System;

//namespace Assignment_day2
//{
//    internal class Section8
//    {
//        static void Main(string[] args)
//        {
//            object o = 5;

//            if (o is int i)
//                Console.WriteLine(i + 1);

//            Person person = new Person { Name = "Soham", Age = 21 };

//            if (person is { Age: >= 18, Name: var n })
//                Console.WriteLine(n);

//            Console.WriteLine(Describe(null));
//            Console.WriteLine(Describe(10));
//            Console.WriteLine(Describe("hello"));
//            Console.WriteLine(Describe(3.14));
//        }

//        // Switch with type patterns
//        static string Describe(object? obj) => obj switch
//        {
//            null => "none",
//            int i => $"int {i}",
//            string s => $"str({s})",
//            _ => "other"
//        };
//    }

//    class Person
//    {
//        public string Name { get; set; }
//        public int Age { get; set; }
//    }
//}
