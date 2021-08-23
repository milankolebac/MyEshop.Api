using System.Linq;

namespace MyEshop.Api.Models
{
    public class EshopContextSeedData
    {
        private readonly EshopContext _dbContext;

        public EshopContextSeedData(EshopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SeedProducts()
        {
            if (_dbContext.Products.Any())
                return;

            _dbContext.Products.Add(new Product() { Id = 1, Name = "Product 1", ImgUri = "/images/product1.jpg", Price = 1000, Description = "Description of product 1" });
            _dbContext.Products.Add(new Product() { Id = 2, Name = "Product 2", ImgUri = "/images/product2.jpg", Price = 2000, Description = "Description of product 2" });
            _dbContext.Products.Add(new Product() { Id = 3, Name = "Product 3", ImgUri = "/images/product3.jpg", Price = 3000, Description = "Description of product 3" });
            _dbContext.Products.Add(new Product() { Id = 4, Name = "Product 4", ImgUri = "/images/product4.jpg", Price = 4000, Description = "Description of product 4" });
            _dbContext.Products.Add(new Product() { Id = 5, Name = "Product 5", ImgUri = "/images/product5.jpg", Price = 5000, Description = "Description of product 5" });

            _dbContext.SaveChanges();
        }
    }
}
