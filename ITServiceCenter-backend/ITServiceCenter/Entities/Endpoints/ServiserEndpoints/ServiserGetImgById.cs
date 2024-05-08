using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace itservicecenter.Entities.Endpoints.ServiserEndpoints
{
    [ApiController]
    public class ServiserGetImgById : ControllerBase
    {
        [HttpGet("Serviser/GetImg")]
        public async Task<FileContentResult> GetByID(
            [FromQuery] string username,
            CancellationToken cancellationToken
        )
        {
            var folderPath = "slike-serviser";
            byte[] slika;

            try
            {
                var fileName = $"{folderPath}-{username.ToLower()}-velika.jpg";
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
