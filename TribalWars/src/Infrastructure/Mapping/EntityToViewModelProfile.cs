using ApplicationCore.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping
{
    public class EntityToViewModelProfile : Profile
    {
        public EntityToViewModelProfile()
        {
            CreateMap<BuildingRequiredBuilding, ApplicationCore.ViewModels.BuildingRequiredBuildingViewModel>()
                .ForMember(dest => dest.Level, opt => opt
                .MapFrom(src => src.RequiredBuilding.Level))
                .ForMember(dest => dest.Name, opt => opt
                .MapFrom(src => src.RequiredBuilding.ReqBuilding.Name)); 
        }
    }
}
