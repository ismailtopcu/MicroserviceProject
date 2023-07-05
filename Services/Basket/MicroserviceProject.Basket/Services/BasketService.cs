using MicroserviceProject.Basket.Dtos;
using MicroserviceProject.Shared.Dtos;
using System.Text.Json;
using System.Threading.Tasks;

namespace MicroserviceProject.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task<Response<bool>> Delete(string userID)
        {
            var status = await _redisService.GetDb().KeyDeleteAsync(userID);
            return status ? Response<bool>.Success(204) : Response<bool>.Fail("Sepet bulunamadı", 404);
        }

        public async Task<Response<BasketDto>> GetBasket(string userID)
        {
            var existBasket = await _redisService.GetDb().StringGetAsync(userID);
            if (string.IsNullOrEmpty(existBasket))
            {
                return Response<BasketDto>.Fail("Sepet Bulunamadı",404);
            }
            else
            {
                return Response<BasketDto>.Success(200,JsonSerializer.Deserialize<BasketDto>(existBasket));
            }
        }

        public async Task<Response<bool>> SaveOrUpdate(BasketDto basketDto)
        {
            var status = await _redisService.GetDb().StringSetAsync(basketDto.UserID,JsonSerializer.Serialize<BasketDto>(basketDto));
            return status ? Response<bool>.Success(204) : Response<bool>.Fail("Bir Hata oluştu", 404);
        }
    }
}
