using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Mobile.Service1.Interface;
using MobileDemoProject.Model;

namespace MobileDemoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class HttpCustomerController : Controller
    {
        private readonly ICustomerService _customers;
        private readonly IMapper _mapper;
        public HttpCustomerController(ICustomerService customers, IMapper mapper)
        {

            _customers = customers;
            _mapper = mapper;

        }

    

       // [HttpGet("GetAllCustomer")]

        //public async Task<ActionResult<List<CustomerMobile>>> GetCustomers()
        //{
        //    //static async Task Main(string[] args) 
        //    //{
        //    using var httpClient = new HttpClient();

        //    var response = await httpClient.GetAsync("https://localhost:7290/api/CustomerDetails/GetAllCustomer");


        //    //var customer = await _customers.GetAllCustomerAsync();
        //   // var result = _mapper.Map<List<CustomerMobile>>(customer);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var content = await response.Content.ReadAsStringAsync();
        //        Console.WriteLine(content);
        //    }
        //    else
        //    {
        //        Console.WriteLine($"Request failed with status code {response.StatusCode}");
        //    }
        //    //}
        //}

        [HttpGet("GetAllCustomer")]

        public async Task<ActionResult<List<CustomerMobile>>> GetCustomers()
        {
            List<CustomerMobile> customers = new List<CustomerMobile>();

           

            // logic to retrieve customers from database or API
            if (customers != null && customers.Count > 0)
            {
                return customers;
               
                    var client = new HttpClient();

                    var response = await client.GetAsync("https://localhost:7290/api/CustomerDetails/GetAllCustomer");
                    response.EnsureSuccessStatusCode();

                    var content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(content);
                
            }
            else
            {
                // handle the case when no customers are found
                return new List<CustomerMobile>();

                
            }
          

        }



    }
}
