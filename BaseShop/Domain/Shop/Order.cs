using Domain.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Shop.Auth;

namespace Domain.Shop
{
    public class Order : Entity
    {
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }


}

