﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceProject.Order.Domain.Entities
{
    public class OrderAdress
    {
        public string Disctrict { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
