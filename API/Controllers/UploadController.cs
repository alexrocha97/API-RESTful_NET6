using API.Application.InterfacesApp;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UploadController : ControllerBase
    {
        private readonly ILogger<UploadController> _logger;
        private readonly IUploadImg _serviceUpload;
        public UploadController(ILogger<UploadController> logger, IUploadImg serviceUpload)
        {
            _logger = logger;
            _serviceUpload = serviceUpload;
        }

        public async Task<ActionResult> Upload(IFormFile file)
        {
            try
            {
                var img = await _serviceUpload.Upload(file);
                return Ok(new {
                    mensagem = "Imagem salva com sucesso!",
                    urlImagem = $"http://localhost:5055/img/{img.FileName}"
                });
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Erro ao fazer upload: " + ex.Message);
            }
        }
    }
}
