using AutoMapper;
using MyEstate.Application.User.Models;
using MyEstate.Domain.Entities;

namespace Application.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>();
            CreateMap<User, UserForDetailsDto>();
        }
    }
}