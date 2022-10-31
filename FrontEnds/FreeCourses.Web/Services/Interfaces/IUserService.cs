using FreeCourses.Web.Models;

namespace FreeCourses.Web.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserViewModel> GetUser();
    }
}
