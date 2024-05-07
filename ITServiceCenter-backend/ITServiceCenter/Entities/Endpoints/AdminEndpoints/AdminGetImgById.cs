using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace itservicecenter.Entities.Endpoints.AdminEndpoints
{
    [ApiController]
    public class AdminGetImgById : ControllerBase
    {
        [HttpGet("Admin/GetImgById")]
        public async Task <FileContentResult> GetByID([FromQuery] int id, CancellationToken cancellationToken)
        {
            var folderPath = "slike-admin";
            byte[] slika;

            try
            {
                var fileName = $"{folderPath}/{id}-velika.jpg";
                slika = await System.IO.File.ReadAllBytesAsync(fileName, cancellationToken);
                return File(slika, GetMimeType(fileName));
            }
            catch (Exception ex)
            {
                var fileName = $"wwwroot/profile_images/empty.png";
                slika = await System.IO.File.ReadAllBytesAsync(fileName, cancellationToken);
                return File(slika, GetMimeType(fileName));
            }

        }

        static string GetMimeType(string fileName)
        {
            var provider = new FileExtensionContentTypeProvider();
            if (provider.TryGetContentType(fileName, out var contentType))
            {
                return contentType;
            }
            return "application/octet-stream";
        }
    }
}