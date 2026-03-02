using Microsoft.AspNetCore.Mvc;

namespace CustomerApp.Controllers;

[ApiController]
[Route("api/v1/[controller]")] // URL: api/v1/customer
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _service;

    // Dependency Injection: The service is "injected" through the constructor
    public CustomerController(ICustomerService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _service.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var customer = await _service.GetByIdAsync(id);
        return customer == null ? NotFound() : Ok(customer);
    }

    // POST: Used to CREATE data
    [HttpPost]
    public async Task<IActionResult> Create(CustomerDTO customer)
    {
        var created = await _service.CreateAsync(customer);
        // Returns Status 201 (Created) and tells the client where the new item is
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    // PUT: Used to UPDATE data
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, CustomerDTO customer)
    {
        var success = await _service.UpdateAsync(id, customer);
        // Status 204 (No Content) is the standard response for a successful update
        return success ? NoContent() : NotFound();
    }

    // DELETE: Used to REMOVE data
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _service.DeleteAsync(id);
        return success ? NoContent() : NotFound();
    }

    // PATCH: Used for partial updates (e.g., just changing the email)
    [HttpPatch("{id:int}")]
    public async Task<IActionResult> Patch(int id, [FromBody] CustomerDTO patchData)
    {
        // In a real app, you'd check which fields are not null.
        // For this example, we'll assume we are patching the email.
        var success = await _service.UpdateAsync(id, patchData);

        if (!success) return NotFound();

        return NoContent(); // 204 Success
    }
}