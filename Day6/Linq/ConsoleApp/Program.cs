using System.Linq;

namespace Linq
{
    class Program
    {
        static void Main()
        {
            CustomerDataResult();
        }



        static List<Customer> customers = new()
            {
                new Customer { CustomerId = 1, CustomerName = "Nikhil" },
                new Customer { CustomerId = 2, CustomerName = "Soham" },
                new Customer { CustomerId = 3, CustomerName = "Vishal" }
            };

        static List<Order> orders = new()
            {
                new Order { OrderId = 101, CustomerId = 1, OrderAmount = 1500 },
                new Order { OrderId = 102, CustomerId = 1, OrderAmount = 2500 },
                new Order { OrderId = 103, CustomerId = 2, OrderAmount = 3000 },
                new Order { OrderId = 104, CustomerId = 3, OrderAmount = 1800 },
                new Order { OrderId = 105, CustomerId = 3, OrderAmount = 2200 }
            };



        static void CustomerDataResult()
        {
            var CustomerOrder = customers
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


            foreach (var customer in CustomerOrder)
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


