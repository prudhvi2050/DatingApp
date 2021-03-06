using AutoMapper;
using DatingApp.API.Models;
using DatingApp.API.Dtos;
using System.Linq;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForDetailsDto>()
                .ForMember(dest => dest.PhotoUrl, opt => {
                    opt.MapFrom(src=>src.Photos.FirstOrDefault(i=>i.IsMain).Url);
                })
                .ForMember(dest => dest.Age, opt => {
                    opt.ResolveUsing(d=>d.DateOfBirth.CalculateAge());
                });
            CreateMap<User, UserForListDto>()
                .ForMember(dest => dest.PhotoUrl, opt => {
                    opt.MapFrom(src=>src.Photos.FirstOrDefault(i=>i.IsMain).Url);
                })
                .ForMember(dest => dest.Age, opt => {
                    opt.ResolveUsing(d=>d.DateOfBirth.CalculateAge());
                });
            CreateMap<Photo, PhotosForDetails>();
            CreateMap<UserForUpdateDto, User>();
            CreateMap<Photo,PhotoForReturnDto>();
            CreateMap<PhotoForCreationDto,Photo>();
            CreateMap<UserForRegisterDto,User>();
            CreateMap<MessageForCreationDto,Message>().ReverseMap();
            CreateMap<Message,MessageToReturnDto>()
                .ForMember(m => m.SenderPhotoUrl, opt => {
                    opt.MapFrom(src => src.Sender.Photos.FirstOrDefault(u => u.IsMain).Url);
                })
                .ForMember(m => m.RecipientPhotoUrl, opt => {
                    opt.MapFrom(src => src.Recipient.Photos.FirstOrDefault(u => u.IsMain).Url);
                });
        }
    }
}