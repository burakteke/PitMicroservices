using FreeCourses.Services.PhotoStock.Dtos;
using FreeCourses.Shared.ControllerBases;
using FreeCourses.Shared.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FreeCourses.Services.PhotoStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : CustomBaseController
    {
        [HttpPost]
        public async Task<IActionResult> PhotoSave(IFormFile photo, CancellationToken cancellationToken)
        {
            if(photo != null && photo.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos", photo.FileName);
                using var stream = new FileStream(path, FileMode.Create);
                await photo.CopyToAsync(stream, cancellationToken);

                var returnPath = photo.FileName; //
                PhotoDto photoDto = new() { Url = returnPath };
                return CreateActionResultInstance(Response<PhotoDto>.Success(photoDto, (int)HttpStatusCode.OK));
            }

            return CreateActionResultInstance(Response<PhotoDto>.Fail("Photo is empty", (int)HttpStatusCode.BadRequest));
        }

        [HttpGet]
        //Method içinde hiç async bir method kullanılmadığı için imzadaki async ve Task ifadeleri kaldırıldı.
        public IActionResult PhotoDelete(string photoUrl)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos", photoUrl);
            if (!System.IO.File.Exists(path))
            {
                return CreateActionResultInstance(Response<NoContent>.Fail("Photo not found", (int)HttpStatusCode.NotFound));
            }

            System.IO.File.Delete(path);
            return CreateActionResultInstance(Response<NoContent>.Success((int)HttpStatusCode.NoContent));
        }
    }
}
