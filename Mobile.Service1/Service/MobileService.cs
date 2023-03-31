using Microsoft.EntityFrameworkCore;
using Mobile.Domain1.Interface;
using Mobile.Domain1.Model;
using Mobile.Service1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Service1.Service
{
    public class MobileService : IMobileService
    {
        private readonly IMobileRepository _mobileRepository;
        public MobileService(IMobileRepository mobileRepository)
        {
            _mobileRepository = mobileRepository;   
        }
        //public async Task<mobile> CreateMobileAsync(AddMobile request)
        //{
        //   return await _mobileRepository.CreateMobileAsync(request);
        //}

        public async Task<mobile> CreateMobileAsync(mobile request)
        {
            return await _mobileRepository.CreateMobileAsync(request);
        }

        public async Task<mobile> DeleteMobileAsync(int id)
        {
            return await _mobileRepository.DeleteMobileAsync(id);
        }



        public async Task<List<mobile>> GetAllMobileAsync()
        {
           return await _mobileRepository.GetAllMobileAsync();
        }



        public async Task<mobile> GetMobileByIdAsync(int id)
        {
          return await _mobileRepository.GetMobileByIdAsync(id);
        }



        public async Task<mobile> UpdateMobileAsync(int id, mobile mobile)
        {
           return await _mobileRepository.UpdateMobileAsync(id, mobile);
        }

    }
}
