using AutoMapper;
using Reestr.Database.Model;
using Reestr.Logics.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Logics.Infrastructure.AutoMapper
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<AddressingLogics, Addressing>().ReverseMap();
            CreateMap<AddressTypeLogics, AddressType>().ReverseMap();
            CreateMap<ConstructionPassportLogics, ConstructionPassport>().ReverseMap();
            CreateMap<DistrictsLogics, Districts>().ReverseMap();
            CreateMap<LandLogics, Land>().ReverseMap();
            CreateMap<PlotAssignmentLogics, PlotAssignment>().ReverseMap();
            CreateMap<PostcodeLogics, Postcode>().ReverseMap();
            CreateMap<ProjectArchiveLogics, ProjectArchive>().ReverseMap();
            CreateMap<RegisterOfEmergencyBuildingsLogics, RegisterOfEmergencyBuildings>().ReverseMap();
            CreateMap<SolutionLogics, Solution>().ReverseMap();
            CreateMap<StreetCategoryLogics, StreetCategory>().ReverseMap();
            CreateMap<StreetsLogics, Streets>().ReverseMap();
            CreateMap<TargetLandLogics, TargetLand>().ReverseMap();
            CreateMap<UrbanPlanningConditionsLogics, UrbanPlanningConditions>().ReverseMap();
        }
    }
}
