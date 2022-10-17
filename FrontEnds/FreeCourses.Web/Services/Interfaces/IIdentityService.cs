using FreeCourses.Shared.Dtos;
using FreeCourses.Web.Models;
using IdentityModel.Client;

namespace FreeCourses.Web.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<Response<bool>> SignIn(SigninInput signinInput);
        Task<TokenResponse> GetAccessTokenByRefreshToken();
        Task RevokeRefreshToken();
    }
}
