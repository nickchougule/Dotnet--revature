namespace CustomerApp;

// The Data Transfer Object: What the API sends and receives
public class CustomerDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

// The Interface: Defines the "Contract" for our business logic
public interface ICustomerService
{
    Task<List<CustomerDTO>> GetAllAsync();
    Task<CustomerDTO?> GetByIdAsync(int id);
    Task<CustomerDTO> CreateAsync(CustomerDTO customer);
    Task<bool> UpdateAsync(int id, CustomerDTO updatedCustomer);
    Task<bool> DeleteAsync(int id);
}

public class CustomerService : ICustomerService
{
    // 'static' ensures this list stays alive in memory as long as the app is running.
    // If it's not static, it will reset every time a controller calls it.
    private static List<CustomerDTO> _customers = new()
    {
        new CustomerDTO { Id = 1, Name = "Soham", Email = "soham@gmail.com" },
        new CustomerDTO { Id = 2, Name = "Naik", Email = "Naik@gmail.com" }
    };

    // GET ALL: Returns the full list
    public async Task<List<CustomerDTO>> GetAllAsync() => await Task.FromResult(_customers);

    // GET BY ID: Returns one customer or null if not found
    public async Task<CustomerDTO?> GetByIdAsync(int id) =>
        await Task.FromResult(_customers.FirstOrDefault(c => c.Id == id));

    // POST: Adds a new customer to the list
    public async Task<CustomerDTO> CreateAsync(CustomerDTO customer)
    {
        // Simple logic to find the highest ID and add 1
        customer.Id = _customers.Any() ? _customers.Max(c => c.Id) + 1 : 1;
        _customers.Add(customer);
        return await Task.FromResult(customer);
    }

    // PUT: Updates an existing customer
    public async Task<bool> UpdateAsync(int id, CustomerDTO updatedCustomer)
    {
        var existing = _customers.FirstOrDefault(c => c.Id == id);
        if (existing == null) return false;

        // Only update the Name if the user actually sent a new one
        if (!string.IsNullOrEmpty(updatedCustomer.Name))
        {
            existing.Name = updatedCustomer.Name;
        }

        // Only update the Email if it's not null or empty
        if (!string.IsNullOrEmpty(updatedCustomer.Email))
        {
            existing.Email = updatedCustomer.Email;
        }

        return await Task.FromResult(true);
    }

    // DELETE: Removes a customer by ID
    public async Task<bool> DeleteAsync(int id)
    {
        var customer = _customers.FirstOrDefault(c => c.Id == id);
        if (customer == null) return false;

        _customers.Remove(customer);
        return await Task.FromResult(true);
    }
}