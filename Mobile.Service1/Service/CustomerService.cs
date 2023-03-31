using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Mobile.Domain1.Interface;
using Mobile.Domain1.Model;
using Mobile.Domain1.Repository;
using Mobile.Service1.Interface;
//using Mobile.Service1.Mapping;
using Mobile.Service1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using ICustomerService = Mobile.Service1.Interface.ICustomerService;

namespace Mobile.Service1.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;

        }
        //public async Task<customer> CreateCustomerAsync(customer customer)
        //{
        //    return await _customerRepository.CreateCustomerAsync(customer);

        //    //var customerList = await _customerRepository.CreateCustomerAsync(mobile);
        //    //return _mapper.Map<List<Customer>>(customerList);
        //}



        public async Task<customer> DeleteCustomerAsync(int id)
        {
           return await _customerRepository.DeleteCustomerAsync(id);
        }



        public async Task<List<Customer>> GetAllCustomerAsync()
        {
            var customerList = await _customerRepository.GetAllCustomerAsync();
            //var result = _mapper.Map<Customer>(customerList);
            //return _mapper.Map<List<Customer>>(customerList);
            // return await _customerRepository.GetAllCustomerAsync();

            // return await _customerRepository.GetAllCustomerAsync(_mapper.Map<ServiceCustomerMapperList>());
            //var customer = await _customerRepository.GetAllCustomerAsync();
            var result = _mapper.Map<List<Customer>>(customerList);
            return result;


        }



        public async Task<customer>GetCustomerByIdAsync(int id)
        {
            //return await _customerRepository.GetCustomerByIdAsync(_mapper.Map<Customer>(id));
            return await _customerRepository.GetCustomerByIdAsync(id);
        }



        public async Task<customer> UpdateCustomerAsync(int id, customer customer)
        {
            return await _customerRepository.UpdateCustomerAsync(id, customer);
        }

        public async Task<customer> CreateCustomerAsync(customer customer)
        {
            //var customerList = await _customerRepository.CreateCustomerAsync(_mapper.Map<customer>(mobile));
            //return _mapper.Map<customer>(customerList);

            // return _mapper.Map<Customer>(await _customerRepository.CreateCustomerAsync(_mapper.Map<customer>(mobile)));
            return await _customerRepository.CreateCustomerAsync(customer);
        }
    }
    

}
