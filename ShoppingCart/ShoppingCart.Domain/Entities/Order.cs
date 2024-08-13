﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public Guid Guid { get; set; }
        
        public int CustomerId { get; set; }

        public decimal TotalPrice { get; set; }

        public int Status { get; set; }

        public Customer Customer { get; set; }
    }
}
