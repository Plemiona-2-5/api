using ApplicationCore.DTOs;
using AutoMapper;
using Infrastructure.Identity;

namespace Infrastructure.Mapping
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}