using Domain.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Shop.Auth;

namespace Domain.Shop
{
    public class Cart : Entity
    {
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        public decimal TotalAmount { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}

