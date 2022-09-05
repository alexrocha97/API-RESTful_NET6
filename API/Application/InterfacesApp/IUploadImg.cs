namespace API.Application.InterfacesApp
{
    public interface IUploadImg
    {
        Task<IFormFile> Upload(IFormFile file);
    }
}
