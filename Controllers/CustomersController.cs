using AutoMapper;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Mobile.Domain1.Data;
using Mobile.Domain1.Interface;
//using Mobile.Domain1.Mapping;
using Mobile.Domain1.Model;
using Mobile.Domain1.Repository;
using Mobile.Service1.Interface;
using Mobile.Service1.Model;
using MobileDemoProject.Model;

namespace MobileDemoProject.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        //private readonly ICustomerRepository _customers;
        private readonly ICustomerService _customers;
        private readonly IMapper _mapper;
        public CustomersController(ICustomerService customers, IMapper mapper)
        {

            _customers = customers;
            _mapper = mapper;

        }



        // GET: api/Customers   
        [HttpGet("GetAllCustomer")]
        public async Task<ActionResult<List<CustomerMobile>>> GetCustomers()
        {
            try
            {
                var customer = await _customers.GetAllCustomerAsync();
                var result = _mapper.Map<List<CustomerMobile>>(customer);

                //var result = _mapper.Map<List<CustomerMobile>>(await _customers.GetAllCustomerAsync());
              //  return Ok(result);

                if (customer.Count == 0)
                {
                    return NoContent();

                }
                return Ok(result);
               
                //return StatusCode(StatusCodes.Status404NotFound,
                //new Error { Message = "No Records ." });

                //return Ok(await _customers.GetAllCustomerAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex);
            }
        }



        // GET: api/Customers/5
        [HttpGet("Getid")]
        public async Task<ActionResult<customer>> GetCustomer(int id)
        {
            try
            {
                //if (id <= 0)
                //{
                //    return BadRequest($"Invalid id:{id}");
                //}
                //return Ok(await _customers.GetCustomerByIdAsync(id));

                //if (id <= 0)
                //    return Problem(statusCode: 400, detail: $"account number not less than zero");
                //throw new Exception("account number not less than zero");
                var customer = await _customers.GetCustomerByIdAsync(id);
                //var result = _mapper.Map<List<CustomerMapperList>>(customer);
                //return Ok(result);

                if (customer == null) 
                {
                    return NoContent();
                }
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex);
            }
        }



        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Editid")]
        public async Task<IActionResult> PutCustomer(int id, customer customer)
        {
            try
            {
                if (String.IsNullOrEmpty(customer.CustomerName))
                    return Problem(statusCode: 400, detail: $"Name should not be empty");
                //   return BadRequest("CustomerName is Empty");
                //if (String.IsNullOrEmpty(customer.Email))
                //    return BadRequest("Email is Empty");
                //if (String.IsNullOrEmpty(customer.Password))
                //    return BadRequest("Password is Empty");
                ////if (long.IsNullOrEmpty(customer.PhoneNumber))
                ////    return BadRequest("PhoneNumber is Empty");
                //if (String.IsNullOrEmpty(customer.Address))
                //    return BadRequest("Address is Empty");

                return Ok(await _customers.UpdateCustomerAsync(id, customer));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }



        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Createid")]
        public async Task<ActionResult> Postcustomer(customer mobile)
        {
            try
            {
                if (string.IsNullOrEmpty(mobile.CustomerName))
                    return Problem(statusCode: 400, detail: $"Name should not be empty");

               
               return Ok(await _customers.CreateCustomerAsync(mobile));
               // var result = _mapper.Map<List<Customer>>(await _customers.CreateCustomerAsync(customer));
               
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex);
            }
        }



        // DELETE: api/Customers/5
        [HttpDelete("Deleteid")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                //if (id <= 0)
                //{
                //    return BadRequest($"Invalid id:{id}");
                //}
               var customer = await _customers.DeleteCustomerAsync(id);
               // return Ok("deleted successfully");

                if (customer == null)
                {
                    return Problem(statusCode: 400, detail: $"unable to delete customer: {id}");
                }
                return Ok("Removed Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex);
            }
        }

        //Http
        //public class HttpClientCalls
        //{
        //    static async Task Main(string[] args)
        //    {
        //        using var httpClient = new HttpClient();

        //        var response = await httpClient.GetAsync("https://localhost:7290/api/CustomerDetails/GetAllCustomer");

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var content = await response.Content.ReadAsStringAsync();
        //            Console.WriteLine(content);
        //        }
        //        else
        //        {
        //            Console.WriteLine($"Request failed with status code {response.StatusCode}");
        //        }
        //    }
        //}
    }
}
 
