﻿using Reestr.Database.Model;
using Reestr.Logics.Infrastructure.Repositories;
using System.Threading.Tasks;


namespace Reestr.Logics.Infrastructure.UnitOfWorks
{
    public interface IUnitOfWork
    {
        void Dispose();
        Task Save();

        DbRepository<Addressing> AddressingUnitOfWork { get; set; }
        DbRepository<AddressType> AddressTypeUnitOfWork { get; set; }
        DbRepository<ConstructionPassport> ConstructionPassportUnitOfWork { get; set; }
        DbRepository<Districts> DistrictsUnitOfWork { get; set; }
        DbRepository<Land> LandUnitOfWork { get; set; }
        DbRepository<PlotAssignment> PlotAssignmentUnitOfWork { get; set; }
        DbRepository<Postcode> PostcodeUnitOfWork { get; set; }
        DbRepository<ProjectArchive> ProjectArchiveUnitOfWork { get; set; }
        DbRepository<RegisterOfEmergencyBuildings> RegisterOfEmergencyBuildingsUnitOfWork { get; set; }
        DbRepository<Solution> SolutionUnitOfWork { get; set; }
        DbRepository<StreetCategory> StreetCategoryUnitOfWork { get; set; }
        DbRepository<Streets> StreetsUnitOfWork { get; set; }
        DbRepository<TargetLand> TargetLandUnitOfWork { get; set; }
        DbRepository<UrbanPlanningConditions> UrbanPlanningConditionsUnitOfWork { get; set; }
    }
}