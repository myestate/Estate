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
          
            CreateMap<MessageForCreationDto, Message>().ReverseMap();
            CreateMap<Message, MessageToReturnDto>();
            /*
            .ForMember(m => m.SenderPhotoUrl, )//, opt => opt.MapFrom(u => u.Sender.Photos.FirstOrDefault(p => p.IsMain).Url))
            .ForMember(m => m.RecipientPhotoUrl, );//, opt => opt.MapFrom(u => u.Recipient.Photos.FirstOrDefault(p => p.IsMain).Url));
        */
        }
    }
}