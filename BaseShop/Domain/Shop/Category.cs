using Domain.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace Domain.Shop
{
    public class Category : Entity
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }
    }


}

