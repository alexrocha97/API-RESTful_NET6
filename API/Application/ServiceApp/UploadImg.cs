using API.Application.InterfacesApp;
using API.Entities;
using API.Interfaces.UploadImg;
using API.Services;
using ImageProcessor;
using ImageProcessor.Plugins.WebP.Imaging.Formats;

namespace API.Application.ServiceApp
{
    public class UploadImg : IUploadImg
    {
        private readonly IValidationImg _validationImg;
        private readonly UploadService _uploadService;
        public UploadImg(IValidationImg validationImg, UploadService uploadService)
        {
            _validationImg = validationImg;
            _uploadService = uploadService;
        }

        public async Task<ImagemMsg> Upload(IFormFile file)
        {
            var result = _validationImg.IsNullArquivo(file);
            var imgresult = new ImagemMsg("", "");
            if(result)
            {
                #region Outro método de salvar img
                // using(var stream = new FileStream(Path.Combine("Imagens", file.FileName),FileMode.Create))
                // {
                //     file.CopyTo(stream);
                // }
                #endregion
                var urlFile = _uploadService.UploadFile(file);
                
                var mensagem = "Arquivo salvo com sucesso!";
                var urlImagem = urlFile;
                imgresult.mensagem = mensagem;
                imgresult.urlImagem = urlImagem;
                return imgresult;
            }
            return imgresult;
        }
    }
}
