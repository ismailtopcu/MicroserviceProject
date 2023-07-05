using System.Collections.Generic;
using System.Linq;

namespace MicroserviceProject.Basket.Dtos
{
    public class BasketDto
    {
        public string UserID { get; set; }
        public int? DiscountCode { get; set; }
        public int? DiscountRate { get; set; }
        public List<BasketItemDto> BasketItems { get; set; }
        public decimal TotalPrice { get=>BasketItems.Sum(x=>x.ProductPrice*x.Quantity); }
    }
}
