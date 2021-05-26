using ApplicationCore.Entities;
using ApplicationCore.ViewModels;
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
            CreateMap<BuildingRequiredBuilding, BuildingRequiredBuildingViewModel>()
                .ForMember(dest => dest.Level, opt => opt
                .MapFrom(src => src.RequiredBuilding.Level))
                .ForMember(dest => dest.Name, opt => opt
                .MapFrom(src => src.RequiredBuilding.Building.Name));
            CreateMap<TribePlayer, TribeMemberVM>()
                .ForMember(dest => dest.Nickname, opt => opt
                .MapFrom(src => src.Player.Nickname));
            CreateMap<VillageUnit, VillageUnitVM>()
                .ForMember(dest => dest.Quantity, opt => opt
                .MapFrom(src => src.Quantity))
                .ForMember(dest => dest.Name, opt => opt
                .MapFrom(src => src.ArmyUnitType.Name));
        }
    }
}
