namespace Image_Upload_Service.Services.Interfaces
{
    public interface IUploadToProjectFolder
    {
        Task<string> UploadToRootFolder(IFormFile file);
    }
}