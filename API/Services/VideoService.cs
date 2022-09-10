using API.Entities.ViewModels;
using API.Entities;
using API.Infra;
using AutoMapper;

namespace API.Services
{
    public class VideoService
    {
        private readonly IMapper _mapper;

        private readonly IMongoRepository<Video> _videos;

        public VideoService(IMongoRepository<Video> videos, IMapper mapper)
        {
            _mapper = mapper;
            _videos = videos;
        }
        public Result<VideoViewModel> GetAll(int page, int qtd)
        {
            return _mapper.Map<Result<VideoViewModel>>(_videos.GetAll(page, qtd));
        }


        public VideoViewModel Get(string id)
        {
            return _mapper.Map<VideoViewModel>(_videos.GetById(id));
        }


        public VideoViewModel GetBySlug(string slug)
        {
            return _mapper.Map<VideoViewModel>(_videos.GetBySlug(slug));
        }

        public VideoViewModel Create(VideoViewModel videos)
        {
            var entity = new Video(videos.Hat, videos.Title, videos.Author, videos.Thumbnail, videos.Status, videos.Url);
            _videos.Create(entity);

            return Get(entity.Id);
        }

        public void Update(string id, VideoViewModel newsIn)
        {
            _videos.Update(id, _mapper.Map<Video>(newsIn));
        }

        public void Remove(string id) => _videos.Remove(id);
    }
}
