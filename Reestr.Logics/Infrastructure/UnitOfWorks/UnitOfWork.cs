using Reestr.Database.Context;
using Reestr.Database.Model;
using Reestr.Logics.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Logics.Infrastructure.UnitOfWorks
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private DbContextReestr _dbContextReestr;
        public UnitOfWork(DbContextReestr dbContextReestr)
        {
            _dbContextReestr = dbContextReestr;
        }

        private DbRepository<Addressing> AddressingUW { get; set; }
        private DbRepository<AddressType> AddressTypeUW { get; set; }
        private DbRepository<ConstructionPassport> ConstructionPassportUW { get; set; }
        private DbRepository<Districts> DistrictsUW { get; set; }
        private DbRepository<Land> LandUW { get; set; }
        private DbRepository<PlotAssignment> PlotAssignmentUW { get; set; }
        private DbRepository<Postcode> PostcodeUW { get; set; }
        private DbRepository<ProjectArchive> ProjectArchiveUW { get; set; }
        private DbRepository<RegisterOfEmergencyBuildings> RegisterOfEmergencyBuildingsUW { get; set; }
        private DbRepository<Solution> SolutionUW { get; set; }
        private DbRepository<StreetCategory> StreetCategoryUW { get; set; }
        private DbRepository<Streets> StreetsUW { get; set; }
        private DbRepository<TargetLand> TargetLandUW { get; set; }
        private DbRepository<UrbanPlanningConditions> UrbanPlanningConditionsUW { get; set; }
        private DbRepository<TypeOfOwnership> TypeOfOwnershipUW { get; set; }
        private DbRepository<BuildingType> BuildingTypeUW { get; set; }
        private DbRepository<Microdistrict> MicrodistrictUW { get; set; }
        private DbRepository<PhotographicFixation> PhotographicFixationUW { get; set; }
        private DbRepository<PossibilityOfReconstruction> PossibilityOfReconstructionUW { get; set; }
        private DbRepository<InfoUser> InfoUserUW { get; set; }

        public DbRepository<InfoUser> InfoUserUnitOfWork { get => InfoUserUW ?? (InfoUserUW = new DbRepository<InfoUser>(_dbContextReestr)); set => InfoUserUW = value; }
        public DbRepository<Addressing> AddressingUnitOfWork { get => AddressingUW ?? (AddressingUW = new DbRepository<Addressing>(_dbContextReestr)); set => AddressingUW = value; }
        public DbRepository<AddressType> AddressTypeUnitOfWork { get => AddressTypeUW ?? (AddressTypeUW = new DbRepository<AddressType>(_dbContextReestr)); set => AddressTypeUW = value; }
        public DbRepository<ConstructionPassport> ConstructionPassportUnitOfWork { get => ConstructionPassportUW ?? (ConstructionPassportUW = new DbRepository<ConstructionPassport>(_dbContextReestr)); set => ConstructionPassportUW = value; }
        public DbRepository<Districts> DistrictsUnitOfWork { get => DistrictsUW ?? (DistrictsUW = new DbRepository<Districts>(_dbContextReestr)); set => DistrictsUW = value; }
        public DbRepository<Land> LandUnitOfWork { get => LandUW ?? (LandUW = new DbRepository<Land>(_dbContextReestr)); set => LandUW = value; }
        public DbRepository<PlotAssignment> PlotAssignmentUnitOfWork { get => PlotAssignmentUW ?? (PlotAssignmentUW = new DbRepository<PlotAssignment>(_dbContextReestr)); set => PlotAssignmentUW = value; }
        public DbRepository<Postcode> PostcodeUnitOfWork { get => PostcodeUW ?? (PostcodeUW = new DbRepository<Postcode>(_dbContextReestr)); set => PostcodeUW = value; }
        public DbRepository<ProjectArchive> ProjectArchiveUnitOfWork { get => ProjectArchiveUW ?? (ProjectArchiveUW = new DbRepository<ProjectArchive>(_dbContextReestr)); set => ProjectArchiveUW = value; }
        public DbRepository<RegisterOfEmergencyBuildings> RegisterOfEmergencyBuildingsUnitOfWork { get => RegisterOfEmergencyBuildingsUW ?? (RegisterOfEmergencyBuildingsUW = new DbRepository<RegisterOfEmergencyBuildings>(_dbContextReestr)); set => RegisterOfEmergencyBuildingsUW = value; }
        public DbRepository<Solution> SolutionUnitOfWork { get => SolutionUW ?? new DbRepository<Solution>(_dbContextReestr); set => SolutionUW = value; }
        public DbRepository<StreetCategory> StreetCategoryUnitOfWork { get => StreetCategoryUW ?? (StreetCategoryUW = new DbRepository<StreetCategory>(_dbContextReestr)); set => StreetCategoryUW = value; }
        public DbRepository<Streets> StreetsUnitOfWork { get => StreetsUW ?? (StreetsUW = new DbRepository<Streets>(_dbContextReestr)); set => StreetsUW = value; }
        public DbRepository<TargetLand> TargetLandUnitOfWork { get => TargetLandUW ?? (TargetLandUW = new DbRepository<TargetLand>(_dbContextReestr)); set => TargetLandUW = value; }
        public DbRepository<UrbanPlanningConditions> UrbanPlanningConditionsUnitOfWork { get => UrbanPlanningConditionsUW ?? (UrbanPlanningConditionsUW = new DbRepository<UrbanPlanningConditions>(_dbContextReestr)); set => UrbanPlanningConditionsUW = value; }
        public DbRepository<TypeOfOwnership> TypeOfOwnershipUnitOfWork { get => TypeOfOwnershipUW ?? (TypeOfOwnershipUW = new DbRepository<TypeOfOwnership>(_dbContextReestr)); set => TypeOfOwnershipUW = value; }
        public DbRepository<BuildingType> BuildingTypeUnitOfWork { get => BuildingTypeUW ?? (BuildingTypeUW = new DbRepository<BuildingType>(_dbContextReestr)); set => BuildingTypeUW = value; }
        public DbRepository<Microdistrict> MicrodistrictUnitOfWork { get => MicrodistrictUW ?? (MicrodistrictUW = new DbRepository<Microdistrict>(_dbContextReestr)); set => MicrodistrictUW = value; }
        public DbRepository<PhotographicFixation> PhotographicFixationUnitOfWork { get => PhotographicFixationUW ?? (PhotographicFixationUW = new DbRepository<PhotographicFixation>(_dbContextReestr)); set => PhotographicFixationUW = value; }
        public DbRepository<PossibilityOfReconstruction> PossibilityOfReconstructionUnitOfWork { get => PossibilityOfReconstructionUW ?? (PossibilityOfReconstructionUW = new DbRepository<PossibilityOfReconstruction>(_dbContextReestr)); set => PossibilityOfReconstructionUW = value; }


        #region Dispose
        private bool disposed = false;


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContextReestr.Dispose();
                }

                this.disposed = true;
            }
        }
        #endregion

        public async Task Save()
        {
            await _dbContextReestr.SaveChangesAsync();
        }
    }
}
