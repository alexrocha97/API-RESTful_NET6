using API.Entities;
using API.Entities.ViewModels;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideosExternalController : ControllerBase
    {

        private readonly ILogger<NewsController> _logger;
        private readonly NewsService _newsService;

        public VideosExternalController(ILogger<NewsController> logger, NewsService newsService)
        {
            _logger = logger;
            _newsService = newsService;
        }

        [HttpGet]
        public ActionResult<Result<NewsViewModel>> GetAll(int page, int qtd) => _newsService.GetAll(page, qtd);

        [HttpGet("{id:length(24)}", Name = "GetNews")]
        public ActionResult<NewsViewModel> GetId(string id)
        {
            var news = _newsService.Get(id);

            if (news is null)
                return NotFound();

            return news;
        }

        [HttpGet("GetBySlug/{slug}")]
        public ActionResult<NewsViewModel> GetBySlug(string slug)
        {
            return _newsService.GetBySlug(slug);
        }
    }
}
