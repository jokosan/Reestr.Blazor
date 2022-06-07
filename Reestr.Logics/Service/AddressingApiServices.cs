using Reestr.Database.Context;
using Reestr.Database.Model;
using Reestr.Logics.Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Logics.Service
{
    public class AddressingApiServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DbContextReestr _dbContextReestr;

        public AddressingApiServices(
            IUnitOfWork unitOfWork, 
            DbContextReestr dbContextReestr)
        {
            _unitOfWork = unitOfWork;
            _dbContextReestr = dbContextReestr;
        }

        public async Task<AddressingApi> GetByAddressingApi(int? id)
        {
            var items = await _unitOfWork
                .AddressingApiUnitOfWork
                .QueryObjectGraph(x => x.IdAddressingApi == id);

            var itemToReturn = items.FirstOrDefault();

            return await Task.FromResult(itemToReturn);
        }

        public async Task<AddressingApi> UpdateAddressingApi(int? id, AddressingApi itemAddressingAli)
        {
            var itemToUpdate = await GetByAddressingApi(id);

            if (itemToUpdate == null)
            {
                throw new Exception("Item no longer available");
            }

            try
            {
                _unitOfWork.AddressingApiUnitOfWork.Update(itemAddressingAli, itemToUpdate);
                await _unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception($"Update Error {e.Message}");
            }

            return itemAddressingAli;
        }

        public async Task<AddressingApi> CreateAddressingApi(AddressingApi itemAddressingAli)
        {
            var existingItem = await GetByAddressingApi(itemAddressingAli.IdAddressingApi);

            if (existingItem != null)
            {
                throw new Exception("Item already available");
            }

            try
            {
                _unitOfWork.AddressingApiUnitOfWork.Insert(itemAddressingAli);
                await _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Item already available");
            }

            return itemAddressingAli;
        }

        public async Task<bool> GetExistingItem(int id)
        {
            var itemToUpdate = await GetByAddressingApi(id);

            return itemToUpdate != null ? false : true;
        }
    }
}
