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

        [HttpGet("GetBySlug/{slug}")]
        public ActionResult<NewsViewModel> GetBySlug(string slug)
        {
            return _newsService.GetBySlug(slug);
        }
    }
}
