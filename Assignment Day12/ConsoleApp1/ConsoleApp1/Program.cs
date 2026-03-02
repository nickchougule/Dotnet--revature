// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
CrmContext _context = new CrmContext();
//var customers = _context.Customers.Where(e=>e.Email=="Nikhil@gmail.com").ToList();
//var customers = _context.Customers.ToList();
//_context.Customers.Add(new Customer { Name = "Govind", Email = "Govind@gmail.com" });
//_context.SaveChanges();
//var john = _context.Customers.FirstOrDefault(c => c.Name == "John Doe");
//if (john != null) john.Email= "john@gmail.com";
_context.SaveChanges();
//foreach (var customer in customers)
//{
//    Console.WriteLine($"Id:{customer.Id },Customer Name: {customer.Name}, Email: {customer.Email}");
//}

class CrmContext : DbContext
{
    //public DbSet<Customer> Customers { get; set; }

    public DbSet<Order> Orders { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=CrmDb;User Id=sa;Password=Soham@2212;TrustServerCertificate=True;");
    }

}
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}
public class Order
{
    [Key]
    public int OrderId { get; set; }

    [Required]
    [MaxLength(100)]
    [MinLength(3)]
    public string Product { get; set; }

    [Required]
    [Precision(18, 2)]
    public decimal Price { get; set; }

    [ForeignKey("CustomerId")]
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
}

