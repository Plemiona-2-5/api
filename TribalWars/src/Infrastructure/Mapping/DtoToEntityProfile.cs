using ApplicationCore.DTOs;
using AutoMapper;
using Infrastructure.Identity;

namespace Infrastructure.Mapping
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            CreateMap<UserDto, User>();
        }
    }
}