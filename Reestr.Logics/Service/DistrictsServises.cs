using Reestr.Logics.Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Reestr.Database.Model;
using Microsoft.EntityFrameworkCore;
using Reestr.Logics.Contract.ServiceContract;

namespace Reestr.Logics.Service
{
    public class DistrictsServises
    {
        private readonly IUnitOfWork _unitOfWork;

        public DistrictsServises(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Districts> CreateDistrict(Districts districts)
        {
            var existingItem = await _unitOfWork.DistrictsUnitOfWork.GetById(districts.IdDistricts);

            if (existingItem != null)
            {
                throw new Exception("");
            }

            try
            {
                _unitOfWork.DistrictsUnitOfWork.Insert(districts);
                await _unitOfWork.Save();
            }
            catch
            {
                throw;
            }

            return districts;
        }

        public async Task<Districts> GetDistrictByIdDistricts(int? idDistricts)
        {
            var items = await _unitOfWork.DistrictsUnitOfWork.GetById(idDistricts);

            return await Task.FromResult(items);
        }

        public async Task<Districts> UpdateDistrict(int? idDistricts, Districts district)
        {
            var itemToUpdate = await _unitOfWork.DistrictsUnitOfWork.GetById(idDistricts);

            if (itemToUpdate == null)
            {
                throw new Exception("Item no longer available");
            }

            _unitOfWork.DistrictsUnitOfWork.Update(district);
            await _unitOfWork.Save();

            return district;
        }
    }
}
