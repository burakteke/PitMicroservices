using FreeCourses.Services.Catalog.Services;
using FreeCourses.Shared.ControllerBases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourses.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    internal class CourseController : CustomBaseController
    {
        private readonly ICourseService _courseService;

        internal CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<IActionResult> GetById(string id)
        {
            var response = await _courseService.GetByIdAsync(id);
            return CreateActionResultInstance(response);
        }
    }
}
