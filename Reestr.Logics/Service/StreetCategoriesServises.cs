using Reestr.Database.Model;
using Reestr.Logics.Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Logics.Service
{
    public class StreetCategoriesServises
    {
        private readonly IUnitOfWork _unitOfWork;

        public StreetCategoriesServises(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<StreetCategory> CreateStreetCategory(StreetCategory streetCategory)
        {
            var existingItem = await _unitOfWork.StreetCategoryUnitOfWork.GetById(streetCategory.IdStreetCategory);

            if (existingItem != null)
            {
                throw new Exception("Item already available");
            }

            try
            {
                _unitOfWork.StreetCategoryUnitOfWork.Insert(streetCategory);
                await _unitOfWork.Save();
            }
            catch
            {
                throw;
            }

            return streetCategory;
        }

        public async Task<StreetCategory> GetStreetCategoryByIdStreetCategory(int? idStreetCategory)
        {
            var items = await _unitOfWork.StreetCategoryUnitOfWork.GetById(idStreetCategory);

            return await Task.FromResult(items);
        }

        public async Task<StreetCategory> UpdateStreetCategory(int? idStreetCategory, StreetCategory streetCategory)
        {
            var itemToUpdate = await _unitOfWork.StreetCategoryUnitOfWork.GetById(streetCategory.IdStreetCategory);

            if (itemToUpdate == null)
            {
                throw new Exception("Item no longer available");
            }

            _unitOfWork.StreetCategoryUnitOfWork.Update(streetCategory);
            await _unitOfWork.Save();

            return streetCategory;
        }
    }
}
