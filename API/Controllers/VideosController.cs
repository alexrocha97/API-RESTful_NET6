using API.Entities;
using API.Entities.ViewModels;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        private readonly ILogger<VideosController> _logger;
        private readonly VideoService _VideosService;

        public VideosController(ILogger<VideosController> logger, VideoService videosService)
        {
            _logger = logger;
            _VideosService = videosService;
        }

        [HttpGet]
        public ActionResult<Result<VideoViewModel>> GetAll(int page, int qtd) => _VideosService.GetAll(page, qtd);

        [HttpGet("{id:length(24)}", Name = "GetVideos")]
        public ActionResult<VideoViewModel> GetId(string id)
        {
            var videos = _VideosService.Get(id);

            if (videos is null)
                return NotFound();

            return videos;
        }
        [HttpPost]
        public ActionResult<VideoViewModel> Create(VideoViewModel news)
        {
            var result = _VideosService.Create(news);

            return CreatedAtRoute("GetVideos", new { id = result.Id.ToString() }, result);
        }


        [HttpPut("{id:length(24)}")]
        public ActionResult<VideoViewModel> Update(string id, VideoViewModel newsIn)
        {
            var news = _VideosService.Get(id);

            if (news is null)
                return NotFound();

            _VideosService.Update(id, newsIn);

            return CreatedAtRoute("GetVideos", new { id = id }, newsIn);

        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var news = _VideosService.Get(id);

            if (news is null)
                return NotFound();

            _VideosService.Remove(news.Id);

            var result = new
            {
                message = "Noticia deletada com sucesso!"
            };

            return Ok(result);
        }
    }
}
