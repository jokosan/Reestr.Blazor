using Reestr.Database.Model;
using Reestr.Logics.Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Logics.Service
{
    public class PhotographicFixationServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public PhotographicFixationServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PhotographicFixation> CreateAddressing(PhotographicFixation photographicFixation)
        {
            var existingItem = await _unitOfWork.PhotographicFixationUnitOfWork.GetById(photographicFixation.IdPhotographicFixation);

            if (existingItem != null)
            {
                throw new Exception("Item already available");
            }

            try
            {
                _unitOfWork.PhotographicFixationUnitOfWork.Insert(photographicFixation);
                await _unitOfWork.Save();
            }
            catch(Exception e)
            {
                throw new Exception($"Update photo Error: {e.Message}");
            }

            return photographicFixation;
        }

        public async Task<IEnumerable<PhotographicFixation>> GetById(int id)
            => await _unitOfWork.PhotographicFixationUnitOfWork.QueryObjectGraph(x => x.RegisterOfEmergencyBuildingsId == id);
    }
}
