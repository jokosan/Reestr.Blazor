using Reestr.Database.Model;
using Reestr.Logics.Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Logics.Service
{
    public class RegisterOfEmergencyBuildingsServices
    {
        private readonly IUnitOfWork _uniOfWork;

        public RegisterOfEmergencyBuildingsServices(IUnitOfWork unitOfWork)
        {
            _uniOfWork = unitOfWork;
        }

        public async Task<IEnumerable<RegisterOfEmergencyBuildings>> GetRegisterOfEmergencyBuildings()
        {
            var items = await _uniOfWork.RegisterOfEmergencyBuildingsUnitOfWork.GetInclude("Addressing", "Addressing.Streets", "Addressing.Streets.StreetCategory");

            return await Task.FromResult(items);
        }

        public async Task<RegisterOfEmergencyBuildings> GetRegisterOfEmergencyBuildingByIdRegisterOfEmergencyBuildings(int? idRegisterOfEmergencyBuildings)
        {
            var items = await _uniOfWork.RegisterOfEmergencyBuildingsUnitOfWork.QueryObjectGraph(i => i.IdRegisterOfEmergencyBuildings == idRegisterOfEmergencyBuildings, "Addressing", "Addressing.Streets", "Addressing.Streets.StreetCategory");
            var itemToReturn = items.FirstOrDefault();

            return await Task.FromResult(itemToReturn);
        }

        public async Task<RegisterOfEmergencyBuildings > UpdateRegisterOfEmergencyBuilding(int? idRegisterOfEmergencyBuildings, RegisterOfEmergencyBuildings registerOfEmergencyBuilding)
        {
            var itemToUpdate = await GetRegisterOfEmergencyBuildingByIdRegisterOfEmergencyBuildings(idRegisterOfEmergencyBuildings);

            if (itemToUpdate == null)
            {
                throw new Exception("Item no longer available");
            }

            _uniOfWork.RegisterOfEmergencyBuildingsUnitOfWork.Update(registerOfEmergencyBuilding);
            await _uniOfWork.Save();

            return registerOfEmergencyBuilding;
        }

        public async Task<RegisterOfEmergencyBuildings> CreateRegisterOfEmergencyBuilding(RegisterOfEmergencyBuildings registerOfEmergencyBuilding)
        {
            var existingItem = await GetRegisterOfEmergencyBuildingByIdRegisterOfEmergencyBuildings(registerOfEmergencyBuilding.IdRegisterOfEmergencyBuildings);

            if (existingItem != null)
            {
                throw new Exception("Item already available");
            }

            try
            {
                _uniOfWork.RegisterOfEmergencyBuildingsUnitOfWork.Insert(registerOfEmergencyBuilding);
                await _uniOfWork.Save();
            }
            catch
            {
                throw;
            }

            return registerOfEmergencyBuilding;
        }

    }
}
