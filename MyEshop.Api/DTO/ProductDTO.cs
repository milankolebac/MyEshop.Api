using System.ComponentModel.DataAnnotations;

namespace MyEshop.Api.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string ImgUri { get; set; }

        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
