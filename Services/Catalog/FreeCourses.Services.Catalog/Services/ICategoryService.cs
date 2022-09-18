using FreeCourses.Services.Catalog.Dtos;
using FreeCourses.Services.Catalog.Models;
using FreeCourses.Shared.Dtos;

namespace FreeCourses.Services.Catalog.Services
{
    internal interface ICategoryService
    {
        Task<Response<CategoryDto>> CreateAsync(Category category);
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> GetByIdAsync(string id);
    }
}
