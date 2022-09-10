using API.Entities;
using API.Entities.ViewModels;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsExternalController : ControllerBase
    {

        private readonly ILogger<NewsExternalController> _logger;
        private readonly VideoService _videoService;

        public NewsExternalController(ILogger<NewsExternalController> logger, VideoService videoService)
        {
            _logger = logger;
            _videoService = videoService;
        }

        [HttpGet]
        public ActionResult<Result<VideoViewModel>> GetAll(int page, int qtd) => _videoService.GetAll(page, qtd);

        [HttpGet("{id:length(24)}", Name = "GetNews")]
        public ActionResult<VideoViewModel> GetId(string id)
        {
            var news = _videoService.Get(id);

            if (news is null)
                return NotFound();

            return news;
        }

        [HttpGet("GetBySlug/{slug}")]
        public ActionResult<VideoViewModel> GetBySlug(string slug)
        {
            return _videoService.GetBySlug(slug);
        }
    }
}
