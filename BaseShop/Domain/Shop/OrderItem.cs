﻿using Domain.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Shop
{
    public class OrderItem : Entity
    {
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }


}

