using System.Security.Cryptography;
using Image_Upload_Service.Services.Interfaces;

namespace Image_Upload_Service.Services
{
    public class UploadAsBase65Format : IUploadAsBase65Format
    {
        //Method 1 => Convert file to base 64 string using Memory Stream
        public string Method1(IFormFile file)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                file.OpenReadStream().CopyTo(memoryStream);
                byte[] imageBytes = memoryStream.ToArray();
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        //Method 3 => Convert file to base 64 string using File Stream
        public string Method2(IFormFile file)
        {
            using (FileStream fileStream = new FileStream(file.FileName, FileMode.Open))
            {
                byte[] imageBytes = new byte[fileStream.Length];
                fileStream.Read(imageBytes, 0, (int)fileStream.Length);
                return Convert.ToBase64String(imageBytes);
            }
        }
    }
}
