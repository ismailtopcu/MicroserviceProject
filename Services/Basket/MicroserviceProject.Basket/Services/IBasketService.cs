using MicroserviceProject.Basket.Dtos;
using MicroserviceProject.Shared.Dtos;
using System.Threading.Tasks;

namespace MicroserviceProject.Basket.Services
{
    public interface IBasketService
    {
        Task<Response<BasketDto>> GetBasket(string UserID);
        Task<Response<bool>> SaveOrUpdate(BasketDto basketDto);
        Task<Response<bool>> Delete(string UserID);
    }
}
