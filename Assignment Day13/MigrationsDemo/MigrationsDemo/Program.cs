using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;

var _context = new CrmDbContext();

var customers = _context.Customers.ToList();

foreach (var customer in customers)
{
    Console.WriteLine($"Customer ID: {customer.CustomerId}, Name: {customer.Name}, Email: {customer.Email}");
}
Console.WriteLine();
Console.WriteLine("FILTER -> SORT -> SELECT");
var resultsA = _context.Customers
    .Where(c => c.Email.Contains("@example.com"))
    .OrderBy(c => c.Name)
    .Select(c => new { c.CustomerId, c.Name, c.Email })
    .ToList();

foreach (var item in resultsA)
{
    Console.WriteLine($"Id: {item.CustomerId}, Name: {item.Name}, Email: {item.Email}");
}

Console.WriteLine();
Console.WriteLine("FILTER -> SELECT -> SORT");
var resultsB = _context.Customers
    .Where(c => c.Name.Length >= 4)
    .Select(c => new { c.Name, c.Email })
    .OrderBy(c => c.Name)
    .ToList();

foreach (var item in resultsB)
{
    Console.WriteLine($"Name: {item.Name}, Email: {item.Email}");
}

static void SeedData(CrmDbContext context)
{
    if (!context.Customers.Any())
    {
        context.Customers.AddRange(
            new Customer { Name = "Alice", Email = "alice@example.com" },
            new Customer { Name = "Bob", Email = "bob@example.com" },
            new Customer { Name = "Sara", Email = "sara@example.com" }
        );
        context.SaveChanges();
    }
}


class CrmDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=MigrationDemo;User Id=sa;Password=Soham@2212;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerType>()
            .HasData(
                new CustomerType { Id = 1, TypeName = "Regular" },
                new CustomerType { Id = 2, TypeName = "Premium" }
            );

        modelBuilder.Entity<Order>()
            .HasKey(o => o.OrderId);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Customer)
            .WithMany()
            .HasForeignKey(o => o.CustomerId);
    }
}

public class Customer
{
    public int CustomerId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}

public class CustomerType
{
    public int Id { get; set; }
    public string TypeName { get; set; }
}

public class Order
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }

    [ForeignKey("Customer")]
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
}