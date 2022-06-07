using Reestr.Database.Model;
using Reestr.Logics.Infrastructure.Repositories;
using System.Threading.Tasks;


namespace Reestr.Logics.Infrastructure.UnitOfWorks
{
    public interface IUnitOfWork
    {
        void Dispose();
        Task Save();

        DbRepository<ConstructionPassport> ConstructionPassportUnitOfWork { get; set; }
        DbRepository<Districts> DistrictsUnitOfWork { get; set; }
        DbRepository<Land> LandUnitOfWork { get; set; }
        DbRepository<PlotAssignment> PlotAssignmentUnitOfWork { get; set; }
        DbRepository<ProjectArchive> ProjectArchiveUnitOfWork { get; set; }
        DbRepository<RegisterOfEmergencyBuildings> RegisterOfEmergencyBuildingsUnitOfWork { get; set; }
        DbRepository<Solution> SolutionUnitOfWork { get; set; }
        DbRepository<StreetCategory> StreetCategoryUnitOfWork { get; set; }
        DbRepository<TargetLand> TargetLandUnitOfWork { get; set; }
        DbRepository<UrbanPlanningConditions> UrbanPlanningConditionsUnitOfWork { get; set; }
        DbRepository<TypeOfOwnership> TypeOfOwnershipUnitOfWork { get; set; }
        DbRepository<BuildingType> BuildingTypeUnitOfWork { get; set; }
        DbRepository<Microdistrict> MicrodistrictUnitOfWork { get; set; }
        DbRepository<PhotographicFixation> PhotographicFixationUnitOfWork { get; set; }
        DbRepository<PossibilityOfReconstruction> PossibilityOfReconstructionUnitOfWork { get; set; }
        DbRepository<InfoUser> InfoUserUnitOfWork { get; set; }
        DbRepository<AddressingApi> AddressingApiUnitOfWork {get; set;}
    }
}
