﻿using Domain.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Shop
{
    public class CartItem : Entity
    {
        [ForeignKey("Cart")]
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }


}
