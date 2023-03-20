using AutoMapper;
using Azure.Core;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Office2016.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Mobile.Domain1.Data;
using Mobile.Domain1.Interface;
//using Mobile.Domain1.Mapping;
using Mobile.Domain1.Migrations;
using Mobile.Domain1.Model;
using Mobile.Domain1.Repository;
using Mobile.Service1.Interface;
using Mobile.Service1.Model;
using System.Runtime.InteropServices;

namespace MobileDemoProject.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MobileController : Controller
    {
        // private readonly IMobileRepository _mobile;
        private readonly IMobileService _mobile;
        // private readonly ICustomerService _customerService;
        //private readonly IMapper _mapper;
        // private IMobileService @object;
        private IMobileService object1;



        // private readonly MobileDbContext _ctx;

        public MobileController(IMobileService mobile/*, MobileDbContext ctx*//*, IMapper mapper*/)
        {
            _mobile = mobile;
            //_customerService = customerService;
            // _mapper = mapper;
            // _ctx = ctx;

        }
        [HttpGet("GetAllMobiles")]
        public async Task<ActionResult<List<mobile>>> GetAllMobile()
        {

            try
            {

                var mobileresult = await _mobile.GetAllMobileAsync();
                //return Ok(mobileresult, StatusCode =204);

                if (mobileresult.Count == 0)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(mobileresult);
                }


            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


        // GET: api/mobile
        [HttpGet("Getid")]
        public async Task<ActionResult<List<mobile>>> GetMobile(int MobileId)
        {

            try
            {
                //if (MobileId <= 0)
                //{
                //    return BadRequest($"Invalid id:{MobileId}");
                //}

                var mobileresult = await _mobile.GetMobileByIdAsync(MobileId);
                return Ok(mobileresult);
                //var mobile = await _mobile.GetMobileByIdAsync(MobileId);
                //var result = _mapper.Map<List<CustomerMapperList>>(mobile);
                //return Ok(mobile);


            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

            // return NotFound();

            //var mobile = await _mobile.mobiles.Where(b => b.MobileId == MobileId).ToListAsync();
            //return Ok(Customers);
        }




        // PUT: api/Mobile/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMobile(int id, mobile mobile)
        {
            try
            {


                //    return Ok(await _mobile.UpdateMobileAsync(id, mobile));
                //}
                //catch (Exception ex)
                //{
                //    return BadRequest(ex.Message);
                //}

                var customer = await _mobile.UpdateMobileAsync(id, mobile);
                // return Ok("deleted successfully");

                if (customer == null)
                {
                    return Problem(statusCode: 400, detail: $"unable to update customer: {id}");
                }
                return Ok("Updated Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }



        // POST: api/mobile
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Createid")]
     

        public async Task<ActionResult<mobile>> Postmobile(mobile request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.MobileName))
                    return Problem(statusCode: 400, detail: $"Name should not be empty");



                return Ok(await _mobile.CreateMobileAsync(request));


            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete("Deleteid")]
        public async Task<IActionResult> DeleteMobile(int id)
        {
            try
            {
                //if (id <= 0)
                //{
                //    return BadRequest($"Invalid id:{id}");
                //}
                var customer = await _mobile.DeleteMobileAsync(id);
                // return Ok("deleted successfully");

                if (customer == null)
                {
                    return Problem(statusCode: 400, detail: $"unable to delete customer: {id}");
                }
                return Ok("Removed Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
