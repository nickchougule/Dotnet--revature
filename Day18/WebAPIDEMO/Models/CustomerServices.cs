using System.Diagnostics.Contracts;
using Microsoft.EntityFrameworkCore;
using AutoMapper;


    public class CrmDbContext: DbContext
{
    public CrmDbContext(DbContextOptions<CrmDbContext>options): base(options){


    }

    public DbSet<Customers>Customers{get;set;}
}

public class Customers
{
    public int Id{get;set;}

    public string name{get;set;}

    public int age{get;set;}
}

public interface ICustomerService
{
    IEnumerable<Customers>GetAllCustomers();
}

public class CustomerService: ICustomerService
{
    private readonly CrmDbContext   dbContext;

    public CustomerService(CrmDbContext dbContext)
    {
        this.dbContext=dbContext;

    }

    public IEnumerable<Customers> GetAllCustomers()
    {
        return dbContext.Customers.ToList();
    }
}

public class CustomerDTO
{
    public string fullName{get;set;}
}

public class CustomerProfile: Profile
{
    public CustomerProfile()
    {
        CreateMap<Customers,CustomerDTO>()
            .ForMember(dest=>dest.fullName, opt=>opt.MapFrom(src=>src.name));
    }
    
}

public class CreateCustomerValidation
{
    
}
