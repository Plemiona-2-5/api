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

            CreateMap<BuildingQueue, BuildingQueueVM>()
                .ForMember(dest => dest.Name, opt => opt
                .MapFrom(src => src.Building.Name))
                .ForMember(dest => dest.StartDate, opt => opt
                .MapFrom(src => src.StartDate))
                .ForMember(dest => dest.Duration, opt => opt
                .MapFrom(src => src.Duration));
            CreateMap<VillageUnit, VillageUnitVM>()

                .ForMember(dest => dest.Quantity, opt => opt
                .MapFrom(src => src.Quantity))
                .ForMember(dest => dest.Name, opt => opt
                .MapFrom(src => src.ArmyUnitType.Name));

            CreateMap<Village, CoordinatesVM>()
                .ForMember(dest => dest.CoordinateX, opt => opt
                .MapFrom(src => src.CoordinateX))
                .ForMember(dest => dest.CoordinateY, opt => opt
                .MapFrom(src => src.CoordinateY));
            CreateMap<RecruitmentQueue, RecruitmentQueueVM>()
                .ForMember(dest => dest.Name, opt => opt
                .MapFrom(src => src.ArmyUnitType.Name))
                .ForMember(dest => dest.Duration, opt => opt
                .MapFrom(src => src.Duration))
                .ForMember(dest => dest.Quantity, opt => opt
                .MapFrom(src => src.Quantity));
            CreateMap<VillageBuilding, VillageBuildingVM>()
                .ForMember(dest => dest.Level, opt => opt
                .MapFrom(src => src.CurrentLevel))
                .ForMember(dest => dest.Name, opt => opt
                .MapFrom(src => src.Building.Name));
        }
    }
}
