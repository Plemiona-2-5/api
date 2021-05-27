using ApplicationCore.Contract.Requests;
using ApplicationCore.DTOs;
using AutoMapper;

namespace ApplicationCore.Mapping
{
    public class RequestToDtoProfile : Profile
    {
        public RequestToDtoProfile()
        {
            CreateMap<CreateUserRequest, UserDto>();
        }
    }
}