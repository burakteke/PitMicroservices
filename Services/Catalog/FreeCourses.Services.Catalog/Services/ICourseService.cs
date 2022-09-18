using FreeCourses.Services.Catalog.Dtos;
using FreeCourses.Shared.Dtos;

namespace FreeCourses.Services.Catalog.Services
{
    internal interface ICourseService
    {
        Task<Response<CourseDto>> CreateAsync(CourseCreateDto courseCreateDto);
        Task<Response<NoContent>> DeleteAsync(string id);
        Task<Response<List<CourseDto>>> GetAllAsync();
        Task<Response<List<CourseDto>>> GetAllByUserId(string userId);
        Task<Response<CourseDto>> GetByIdAsync(string id);
        Task<Response<NoContent>> UpdateAsync(CourseUpdateDto courseUpdateDto);
    }
}
