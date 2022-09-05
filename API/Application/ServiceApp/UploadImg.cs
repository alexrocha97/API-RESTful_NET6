using API.Application.InterfacesApp;
using API.Entities;
using API.Interfaces.UploadImg;

namespace API.Application.ServiceApp
{
    public class UploadImg : IUploadImg
    {
        private readonly IValidationImg _validationImg;
        public UploadImg(IValidationImg validationImg)
        {
            _validationImg = validationImg;
        }

        public async Task<ImagemMsg> Upload(IFormFile file)
        {
            var result = _validationImg.IsNullArquivo(file);
            var imgresult = new ImagemMsg("", "");
            if(result)
            {
                using(var stream = new FileStream(Path.Combine("Imagens", file.FileName),FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                var mensagem = "Imagem salva com sucesso!";
                var urlImagem = $"http://localhost:5055/img/{file.FileName}";
                imgresult.mensagem = mensagem;
                imgresult.urlImagem = urlImagem;
                return imgresult;
            }
            return imgresult;
        }
    }
}
