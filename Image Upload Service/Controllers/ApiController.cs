using Image_Upload_Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Image_Upload_Service.Controllers
{
    public class ApiController : Controller
    {
        private IUploadToProjectFolder _service1;
        private IUploadAsBase65Format _service2;

        public ApiController(IUploadToProjectFolder service1, IUploadAsBase65Format service2)
        {
            _service1 = service1;
            _service2 = service2;
        }

        [HttpPost]
        [Route("api/upload")]
        public async Task<IActionResult> UploadToRootFolder([FromForm]IFormFile file)
        {
            var dataResult = await _service1.UploadToRootFolder(file);
            return Ok();
        }

        [HttpPost]
        [Route("api/method1")]
        public IActionResult Method1([FromForm] IFormFile file)
        {
            var dataResult = _service2.Method1(file);
            return Ok(dataResult);
        }

        [HttpPost]
        [Route("api/method2")]
        public IActionResult Method2([FromForm] IFormFile file)
        {
            var dataResult = _service2.Method2(file);
            return Ok(dataResult);
        }
    }
}
