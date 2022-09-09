using API.Application.InterfacesApp;
using API.Entities;
using API.Interfaces.UploadImg;
using ImageProcessor;
using ImageProcessor.Plugins.WebP.Imaging.Formats;

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
                #region Outro método de salvar img
                using(var stream = new FileStream(Path.Combine("Imagens", file.FileName),FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                #endregion

                // Setando um nome de uma imagem com Guid, para que não tenha um nome de imagem duplicado
                var webpNameImagem = Guid.NewGuid() + ".webP";
                using(var webPFileStream = new FileStream(Path.Combine("Imagens", webpNameImagem),FileMode.Create))
                {
                    using(ImageFactory imgFactory = new ImageFactory(preserveExifData: false))
                    {
                        imgFactory.Load(file.OpenReadStream()) // Carregando os dados da imagem
                                .Format(new WebPFormat()) // Formato da imagem
                                .Quality(100) // Parametro para não perder a qualidade no momento da compressão
                                .Save(webPFileStream); // salvando a imagem
                    }
                }
                var mensagem = "Imagem salva com sucesso!";
                var urlImagem = $"http://localhost:5005/img/{webpNameImagem}";
                imgresult.mensagem = mensagem;
                imgresult.urlImagem = urlImagem;
                return imgresult;
            }
            return imgresult;
        }
    }
}
