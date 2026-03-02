using System.Linq;
using System.Collections.Generic;

namespace LINQ
{
    class Program
    {
        static void Main()
        {
            List<Customer> customers = new()
            {
                new Customer { CustomerId = 1, CustomerName = "Soham" },
                new Customer { CustomerId = 2, CustomerName = "Tejas" },
                new Customer { CustomerId = 3, CustomerName = "Yogesh" }
            };

            List<Order> orders = new()
            {
                new Order { OrderId = 11, CustomerId = 1, OrderAmount = 1210 },
                new Order { OrderId = 12, CustomerId = 1, OrderAmount = 3124 },
                new Order { OrderId = 13, CustomerId = 2, OrderAmount = 2140 },
                new Order { OrderId = 14, CustomerId = 3, OrderAmount = 1895 },
                new Order { OrderId = 15, CustomerId = 3, OrderAmount = 3254 }
            };


            var result = customers
            .Join(orders,
                c => c.CustomerId,
                o => o.CustomerId,
                (c, o) => new { c.CustomerId, c.CustomerName, o.OrderId, o.OrderAmount })
            .GroupBy(x => new { x.CustomerId, x.CustomerName })
            .Select(g => new
            {
                CustomerId = g.Key.CustomerId,
                CustomerName = g.Key.CustomerName,
                OrderCount = g.Count(),
                TotalOrderValue = g.Sum(x => x.OrderAmount),
                Orders = g.Select(x => new { x.OrderId, x.OrderAmount }).ToList()
            });


            foreach (var customer in result)
            {
                Console.WriteLine($"Customer: {customer.CustomerName}");
                Console.WriteLine($"Total Orders: {customer.OrderCount}");
                Console.WriteLine($"Total Value: {customer.TotalOrderValue}");

                foreach (var order in customer.Orders)
                {
                    Console.WriteLine($"   Order ID: {order.OrderId}, Amount: {order.OrderAmount}");
                }

                Console.WriteLine();
            }



        }
    }


    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
    }

    public class Order
    {
        public int CustomerId { get; set; }
        public int OrderId { get; set; }

        public decimal OrderAmount { get; set; }



    }


}