using System.Linq;
using AutoMapper;
using MyEstate.Application.Photo.Model;
using MyEstate.Application.User.Models;
using MyEstate.Application.EstateAgent.Models;
using MyEstate.Domain.Entities;
using MyEstate.Application.Estate.Models;
using MyEstate.Application.Message.Models;

namespace Persistence.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
         
            CreateMap<User, UserForListDto>()
            .ForMember(dest => dest.Age, opt => {
                opt.ResolveUsing(d => d.DateOfBirth.CalculateAge());
            });
            CreateMap<User, UserForDetailedDto>()
              .ForMember(dest => dest.Age, opt => {
                opt.ResolveUsing(d => d.DateOfBirth.CalculateAge());
            });

            CreateMap<EstatePhoto, PhotosForDetailedDto>();
            CreateMap<EstatePhoto, PhotoForReturnDto>();
            CreateMap<PhotoForCreationDto, EstatePhoto>();
            CreateMap<UserForRegisterDto, User>();
          
            CreateMap<MessageForCreationDto, Message>().ReverseMap();
        }
    }
}