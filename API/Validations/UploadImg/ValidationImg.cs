using API.Interfaces.UploadImg;

namespace API.Validations.UploadImg
{
    public class ValidationImg : IValidationImg
    {
        public bool IsNullArquivo(IFormFile img)
        {
            if(img == null)
                return false;
            return true;
        }
    }
}
