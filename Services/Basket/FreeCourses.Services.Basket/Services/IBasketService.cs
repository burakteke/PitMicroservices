using FreeCourses.Services.Basket.Dtos;
using FreeCourses.Shared.Dtos;

namespace FreeCourses.Services.Basket.Services
{
    public interface IBasketService
    {
        Task<Response<BasketDto>> GetBasket(string userId);
        Task<Response<bool>> SaveOrUpdate(BasketDto basketDto);
        Task<Response<bool>> Delete(string userId);
    }
}
