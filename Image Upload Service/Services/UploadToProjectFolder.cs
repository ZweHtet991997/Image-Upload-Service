using Image_Upload_Service.Services.Interfaces;

namespace Image_Upload_Service.Services
{
    public class UploadToProjectFolder : IUploadToProjectFolder
    {
        private IWebHostEnvironment _webHostEnvironment;

        public UploadToProjectFolder(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> UploadToRootFolder(IFormFile file)
        {
            try
            {
                if (file.Length > 0)
                {
                    string fileName = string.Empty;
                    if (!Directory.Exists((_webHostEnvironment.ContentRootPath + "\\wwwroot\\" + "img\\")))
                    {
                        Directory.CreateDirectory(_webHostEnvironment.ContentRootPath + "\\wwwroot\\" + "img\\");
                    }
                    using (FileStream fileStream = File.Create(_webHostEnvironment.ContentRootPath + "\\wwwroot\\" + "img\\" + file.FileName))
                    {
                        await file.CopyToAsync(fileStream);
                        fileStream.Flush();
                        fileName = file.FileName;
                    }
                    return fileName;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
