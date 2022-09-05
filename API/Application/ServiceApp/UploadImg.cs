using API.Application.InterfacesApp;
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

        public async Task<IFormFile> Upload(IFormFile file)
        {
            var result = _validationImg.IsNullArquivo(file);
            if(result)
            {
                using(var stream = new FileStream(Path.Combine("Imagens", file.FileName),FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            return file;
        }
    }
}
