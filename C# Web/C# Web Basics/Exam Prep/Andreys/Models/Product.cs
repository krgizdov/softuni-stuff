namespace Andreys.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public decimal Price { get; set; }

        //[Required]
        public Category Category { get; set; }

        //[Required]
        public Gender Gender { get; set; }
    }
}
