using Microsoft.EntityFrameworkCore;
using Radzen;
using Reestr.Database.Context;
using Reestr.Database.Model;
using Reestr.Logics.Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Logics.Service
{
    public class SolutionServises
    {
        private readonly IUnitOfWork _unitOfWork;

        public SolutionServises(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
      
        }

     
        public async Task<Solution> UpdateSolution(int? idSolution, Solution solution)
        {
            var itemToUpdate = await _unitOfWork.SolutionUnitOfWork.GetById(idSolution);
           
            if (itemToUpdate == null)
            {
                throw new Exception("Item no longer available");
            }

            _unitOfWork.SolutionUnitOfWork.Update(solution);
            await _unitOfWork.Save();

            return solution;
        }

        public async Task<Solution> CreateSolution(Solution solution)
        {
            var existingItem = await _unitOfWork.SolutionUnitOfWork.GetById(solution.IdSolution);

            if (existingItem != null)
            {
                throw new Exception("Item already available");
            }

            try
            {
                _unitOfWork.SolutionUnitOfWork.Insert(solution);
                await _unitOfWork.Save();
            }
            catch
            {
                throw;
            }


            return solution;
        }
    }
}
