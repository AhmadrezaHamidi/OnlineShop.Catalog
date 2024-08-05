using System;
using Domain.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Shop
{

    public static class ProductError
    {
        public static readonly Error invalidPhoneNumber = new(
            "product.InvalidPhoneNumber",
            "PhoneNumber is not valid.");
    
        public static readonly Error ProductNotFound = new(
            "Product.ProductNotFound",
            "ProductNotFound does not exist");
    
        public static readonly Error invalidNumber = new(
            "product.InvalidNumber",
            "Input is not valid.");
    
        public static readonly Error expiredCode = new(
            "product.ExpiredCode",
            "Number is expired.");
    }
 
    
    public class Product : Entity
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string ImageUrl { get; set; }
    }


}

