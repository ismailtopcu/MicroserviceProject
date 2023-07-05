using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceProject.Order.Domain.Entities
{
    public class Order
    {
        public string CustomerId { get; set; }
        public DateTime CreatedDate { get; set; }
        public OrderAdress OrderAdress { get; set; }

        private readonly List<OrderItem> orderItems;
    }

    
}
