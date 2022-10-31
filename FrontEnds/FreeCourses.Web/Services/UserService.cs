using FreeCourses.Web.Models;
using FreeCourses.Web.Services.Interfaces;

namespace FreeCourses.Web.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _client;
        public UserService(HttpClient client)
        {
            _client = client;
        }

        public async Task<UserViewModel> GetUser()
        {
            return await _client.GetFromJsonAsync<UserViewModel>("/api/user/getuser");
        }
    }
}
