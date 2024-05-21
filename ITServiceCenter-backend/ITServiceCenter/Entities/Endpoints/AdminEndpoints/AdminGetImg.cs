using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace itservicecenter.Entities.Endpoints.AdminEndpoints
{
    [ApiController]
    public class AdminGetImg : ControllerBase
    {
        [HttpGet("Admin/GetImg")]
        // [Authorize(Roles = "Admin")]
        public async Task<FileContentResult> GetImg(
            [FromQuery] string? username,
            CancellationToken cancellationToken
        )
        {
            var folderPath = "wwwroot/slike-admin";
            byte[] slika;

            try
            {
                var fileName = $"{folderPath}/{username?.ToLower()}-velika.jpg";
                slika = await System.IO.File.ReadAllBytesAsync(fileName, cancellationToken);
                return File(slika, GetMimeType(fileName));
            }
            catch (Exception ex)
            {
                var fileName = "wwwroot/profile_images/empty.png";
                slika = await System.IO.File.ReadAllBytesAsync(fileName, cancellationToken);
                return File(slika, GetMimeType(fileName));
            }
        }

        private static string GetMimeType(string fileName)
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