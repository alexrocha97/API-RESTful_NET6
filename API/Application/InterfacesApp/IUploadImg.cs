using API.Entities;

namespace API.Application.InterfacesApp
{
    public interface IUploadImg
    {
        Task<ImagemMsg> Upload(IFormFile file);
    }
}
