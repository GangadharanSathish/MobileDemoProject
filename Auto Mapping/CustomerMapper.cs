using AutoMapper;
using Mobile.Domain1.Model;
//using Mobile.Service1.Mapping;
using Mobile.Service1.Model;
using MobileDemoProject.Model;

namespace MobileDemoProject.Auto_Mapping
{
    public class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            CreateMap<Customer, CustomerMobile>();
            //CreateMap<PostCustomer, Customer>();
            //CreateMap<PostCustomer, customer>();
        }
    }
}
