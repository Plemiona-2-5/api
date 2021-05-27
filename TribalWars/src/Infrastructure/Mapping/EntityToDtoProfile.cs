using ApplicationCore.Dtos;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using AutoMapper;
using Infrastructure.Identity;

namespace Infrastructure.Mapping
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Player, PlayerDto>();
            CreateMap<Village, VillageDto>()
                .ForMember(dto => dto.Nickname,
                    opt => opt.MapFrom(sourceMember => sourceMember.Player.Nickname));
        }
    }
}