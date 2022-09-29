using FreeCourses.Services.Basket.Dtos;
using FreeCourses.Shared.Dtos;
using System.Net;
using System.Text.Json;

namespace FreeCourses.Services.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task<Response<bool>> Delete(string userId)
        {
            var status = await _redisService.GetDb().KeyDeleteAsync(userId);
            return status ? Response<bool>.Success((int)HttpStatusCode.NoContent) : Response<bool>.Fail("Basket not found", (int)HttpStatusCode.NotFound);
        }

        public async Task<Response<BasketDto>> GetBasket(string userId)
        {
            var existBasket = await _redisService.GetDb().StringGetAsync(userId);
            if (string.IsNullOrEmpty(existBasket))
            {
                return Response<BasketDto>.Fail("Basket not found", (int)HttpStatusCode.NotFound);
            }
            return Response<BasketDto>.Success(JsonSerializer.Deserialize<BasketDto>(existBasket), (int)HttpStatusCode.OK);
        }

        public async Task<Response<bool>> SaveOrUpdate(BasketDto basketDto)
        {
            var status = await _redisService.GetDb().StringSetAsync(basketDto.UserId, JsonSerializer.Serialize(basketDto));
            return status ? Response<bool>.Success((int)HttpStatusCode.NoContent) : Response<bool>.Fail("Basket could not update or save", (int)HttpStatusCode.InternalServerError);
        }
    }
}
