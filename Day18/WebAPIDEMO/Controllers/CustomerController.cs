using Microsoft.AspNetCore.Mvc;
using AutoMapper;



[ApiController]
[Route("api/v1/[controller]")]
public class CustomerController : ControllerBase
{
    // [HttpGet]
    // public IActionResult Get()
    // {
    //     return Ok("Hello Customers");
    // }




    private readonly ICustomerService customerService;
    private readonly IMapper mapper;
    public CustomerController(ICustomerService customerService,IMapper mapper)
    {
        this.customerService = customerService;
        this.mapper = mapper;
    }

    [HttpGet]
    public IActionResult Get()

    {
        var customers = customerService.GetAllCustomers();
        var customerDTOs = mapper.Map<List<CustomerDTO>>(customers);
        return Ok(customerDTOs);


    }
}