using AutoMapper;
using GameSphereAPI.Models.Site_Models.Game_Related;
using GameSphereAPI.Models.User;
using GameSphereAPI.Models.Viewmodels.Game___Related;
using GameSphereAPI.Models.Viewmodels.Registration;

namespace GameSphereAPI.Utilities.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Identity
            CreateMap<AppRegisterRequest, AppUser>();

            //Game
            CreateMap<CreateGameDTO, Game>();
            CreateMap<UpdateGameDTO, Game>();

            //Publisher
            CreateMap<CreatePublisherDTO, Publisher>();
            CreateMap<UpdatePublisherDTO, Publisher>();

            //Language
            CreateMap<CreateLanguageDTO, Language>();
            CreateMap<UpdateLanguageDTO, Language>();
        }
    }
}