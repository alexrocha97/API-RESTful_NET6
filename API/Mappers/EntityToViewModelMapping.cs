using API.Entities;
using API.Entities.ViewModels;
using AutoMapper;

namespace API.Mappers
{
    public class EntityToViewModelMapping : Profile
    {
        public EntityToViewModelMapping()
        {
            #region [Entidades]
            CreateMap<News, NewsViewModel>();
            CreateMap<Video, VideoViewModel>().ReverseMap();
            CreateMap<User, UserViewModel>().ReverseMap();
            #endregion

            #region [Result<T>]
            CreateMap<Result<Video>, Result<VideoViewModel>>().ReverseMap();
            CreateMap<Result<News>, Result<NewsViewModel>>().ReverseMap();
            #endregion

        }
    }
}
