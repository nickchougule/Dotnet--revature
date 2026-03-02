using Microsoft.AspNetCore.Mvc;



[ApiController]
[Route("api/v1/[controller]")]
public class CustomerController : ControllerBase
{
    // [HttpGet]
    // public IActionResult Get()
    // {
    //     return Ok("Hello Customers");
    // }


    ICustomerService customerService;
    public CustomerController(ICustomerService customerService)
    {
        this.customerService = customerService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(customerService.GetAllCustomers());
    }
}