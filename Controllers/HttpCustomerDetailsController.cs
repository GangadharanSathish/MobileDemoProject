using Azure.Core;
using DocumentFormat.OpenXml.Math;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System;
using System.Text.Json;

namespace MobileDemoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HttpCustomerDetailsController : ControllerBase
    {


        [HttpGet("GetAllCustomer")]
        public async Task Main(string[] args)
        {
            //using var httpClient = new HttpClient();

            //var response = await httpClient.GetAsync("https://localhost:7290/api/CustomerDetails/GetAllCustomer");

            //if (response.IsSuccessStatusCode)
            //{
            //    var content = await response.Content.ReadAsStringAsync();
            //    Console.WriteLine(content); 
            //    //return Ok ("Added");
            //}
            //else
            //{
            //    Console.WriteLine($"Request failed with status code {response.StatusCode}");
            //}

            var client = new HttpClient();

            var response = await client.GetAsync("https://localhost:7290/api/CustomerDetails/GetAllCustomer");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);
        }

        [HttpDelete("Deleteid")]
        public async Task Main( int CustomerId)
        {
            using var client = new HttpClient();

           
            var response = await client.DeleteAsync("https://localhost:7290/api/CustomerDetails/Deleteid?CustomerId?");
            response.EnsureSuccessStatusCode();

            Console.WriteLine("Resource deleted successfully.");
        }




        [HttpGet("Getid")]
        public async Task main()
        {
            using var client = new HttpClient();

            var resourceId = 1234;
            var response = await client.GetAsync($"https://localhost:7290/api/CustomerDetails/Getid?EnterId=4/{resourceId}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);
        }

        [HttpPost("Createid")]
        public async Task MAin()
        {
            using var client = new HttpClient();

            // Create a new object representing the resource to be created
            var newResource = new
            {
                //Name = "New Resource",
                //Description = "A description of the new resource",

                //CustomerName: "string",
                //email: "user@example.com",
                //password: "string",
                //phoneNumber: 0,
                //address: "string",

            };

            // Serialize the object to JSON
            var json = JsonSerializer.Serialize(newResource);

            // Create a new StringContent object with the JSON content and content type header
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Send the POST request with the content to the appropriate URL
            var response = await client.PostAsync("https://example.com/resources", content);
            response.EnsureSuccessStatusCode();

            // Read the response content and print it to the console
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseContent);
        }


        [HttpDelete("DeleteCustomerid")]
        public async Task Demo(int Id)
        {
            using var client = new HttpClient();


            var response = await client.DeleteAsync("https://localhost:7090/api/Customers/Deleteid=3");
            response.EnsureSuccessStatusCode();

            Console.WriteLine("Resource deleted successfully.");
        }




    }
}

