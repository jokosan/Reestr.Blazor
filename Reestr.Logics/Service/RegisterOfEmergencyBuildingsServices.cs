using Microsoft.AspNetCore.Components;
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
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Reestr.Logics.Service
{
    public class RegisterOfEmergencyBuildingsServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DbContextReestr _dbContextReestr;
        private readonly NavigationManager _navigationManager;

        public RegisterOfEmergencyBuildingsServices(IUnitOfWork unitOfWork, DbContextReestr dbContextReestr, NavigationManager navigationManager)
        {
            _unitOfWork = unitOfWork;
            _dbContextReestr = dbContextReestr;
            _navigationManager = navigationManager;
        }

        public async Task<IQueryable<RegisterOfEmergencyBuildings>> GetRegisterOfEmergencyBuildings(Query query = null)
        {
            var items = _dbContextReestr.RegisterOfEmergencyBuildings.AsQueryable();

            items = items.Include(i => i.Microdistrict);

            items = items.Include(i => i.BuildingType);

            items = items.Include(i => i.TypeOfOwnership);

            items = items.Include(i => i.PossibilityOfReconstruction);

            items = items.Include(i => i.PhotographicFixation);

            items = items.Include(i => i.AddressingApi);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach (var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            return await Task.FromResult(items);
        }

        public async Task<RegisterOfEmergencyBuildings> GetRegisterOfEmergencyBuildingByIdRegisterOfEmergencyBuildings(int? idRegisterOfEmergencyBuildings)
        {
            var items = _dbContextReestr.RegisterOfEmergencyBuildings
                             .Where(i => i.IdRegisterOfEmergencyBuildings == idRegisterOfEmergencyBuildings);

            items = items.Include(i => i.Microdistrict);

            items = items.Include(i => i.BuildingType);

            items = items.Include(i => i.TypeOfOwnership);

            items = items.Include(i => i.PossibilityOfReconstruction);

            items = items.Include(i => i.AddressingApi);

            var itemToReturn = items.FirstOrDefault();

            return await Task.FromResult(itemToReturn);
        }

        public async Task<RegisterOfEmergencyBuildings> UpdateRegisterOfEmergencyBuilding(int? idRegisterOfEmergencyBuildings, RegisterOfEmergencyBuildings registerOfEmergencyBuilding)
        {
            var itemToUpdate = await GetRegisterOfEmergencyBuildingByIdRegisterOfEmergencyBuildings(idRegisterOfEmergencyBuildings);

            if (itemToUpdate == null)
            {
                throw new Exception("Item no longer available");
            }

            try
            {
                _unitOfWork.RegisterOfEmergencyBuildingsUnitOfWork.Update(registerOfEmergencyBuilding, itemToUpdate);
                await _unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception($"Update Error {e.Message}");
            }

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
                _unitOfWork.RegisterOfEmergencyBuildingsUnitOfWork.Insert(registerOfEmergencyBuilding);
                await _unitOfWork.Save();
            }
            catch(Exception ex)
            {
                throw new Exception("Item already available");
            }

            return registerOfEmergencyBuilding;
        }

        public async Task<bool> CheckingForMatches(int id)
        {
            var checkingId = await _unitOfWork.RegisterOfEmergencyBuildingsUnitOfWork.QueryObjectGraph(x => x.AddressesApiId == id);
            var result = checkingId.Any(x => x.AddressesApiId == id);

            return result;
        }

        //public async Task ExportRegisterOfEmergencyBuildingsToExcel(Query query = null, string fileName = null)
        //{
        //    _navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reestrdbdga/registerofemergencybuildings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reestrdbdga/registerofemergencybuildings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        //}

        //public async Task ExportRegisterOfEmergencyBuildingsToCSV(Query query = null, string fileName = null)
        //{
        //    _navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reestrdbdga/registerofemergencybuildings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reestrdbdga/registerofemergencybuildings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        //}
    }
}
