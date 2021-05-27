using ApplicationCore.Entities;
using ApplicationCore.ViewModels;
using AutoMapper;

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
            CreateMap<VillageMaterial, VillageMaterialVM>()
                .ForMember(dest => dest.Name, opt => opt
                .MapFrom(src => src.Material.Name))
                .ForMember(dest => dest.Quantity, opt => opt
                .MapFrom(src => src.Quantity));
        }
    }
}
