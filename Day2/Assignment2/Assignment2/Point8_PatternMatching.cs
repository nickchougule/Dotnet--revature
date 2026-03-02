// using System;

// class Program
// {
//     static void Main()
//     {
//         object obj = 15;

//         if (obj is int value)
//             Console.WriteLine("Integer value: " + value);

//         Console.WriteLine(Describe(obj));
//     }

//     static string Describe(object obj) => obj switch
//     {
//         null => "Null value",
//         int i => $"Integer: {i}",
//         string s => $"String: {s}",
//         _ => "Unknown type"
//     };
// }
