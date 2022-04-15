using Reestr.Logics.Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Reestr.Logics.Model;
using Reestr.Logics.Contract.ServiceContract;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Reestr.Database.Model;

namespace Reestr.Logics.Service
{
    public class StreetsService : IStreets
    {
        private readonly IUnitOfWork _unitOfWork;

        public StreetsService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Streets>> GetStreets()
        {
            var items = await _unitOfWork.StreetsUnitOfWork.GetInclude("StreetCategory", "Solution");

            return await Task.FromResult(items);
        }

        public async Task<Streets> CreateStreet(Streets streets)
        {
            var existingItem = await _unitOfWork.StreetCategoryUnitOfWork.GetById(streets.IdStreets);

            if (existingItem != null)
            {
                throw new Exception("Item already available");
            }

            try
            {
                _unitOfWork.StreetsUnitOfWork.Insert(streets);
                await _unitOfWork.Save();
            }
            catch
            {
                throw;
            }

            return streets;
        }

        public async Task<Streets> UpdateStreet(int? idStreet, Streets streets)
        {
            var itemToUpdate = await _unitOfWork.StreetsUnitOfWork.GetById(idStreet);

            if (itemToUpdate == null)
            {
                throw new Exception("Item no longer available");
            }

            _unitOfWork.StreetsUnitOfWork.Update(streets);
            await _unitOfWork.Save();

            return streets;
        }

        public async Task<Streets> GetStreetByIdStreets(int? idStreets)
        {
            var items = await _unitOfWork.StreetsUnitOfWork.FirstOrDefaultAsyncInclude(x => x.IdStreets ==idStreets, "StreetCategory", "Solution");

            return await Task.FromResult(items);
        }
    }
}
