using System;
using System.Collections.Generic;
using System.Linq;
using MyEshop.Api.DTO;
using MyEshop.Api.Models;

namespace MyEshop.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly EshopContext _dbContext;

        public ProductService(EshopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ProductDTO GetById(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.Id == id);
            if (product is null)
            {
                return null;
            }

            return new ProductDTO()
            {
                Id = product.Id,
                Name = product.Name,
                ImgUri = product.ImgUri,
                Description = product.Description
            };
        }

        public List<ProductDTO> GetAll()
        {
            var products = _dbContext.Products.ToList();
            var result = new List<ProductDTO>();

            foreach (var product in products)
            {
                result.Add(new ProductDTO()
                {
                    Id = product.Id, 
                    Name = product.Name, 
                    ImgUri = product.ImgUri, 
                    Description = product.Description
                });
            }

            return result;
        }

        public void Update(ProductDTO productDto)
        {
            var product = _dbContext.Products.Find(productDto.Id);
            if (product is null)
            {
                throw new ArgumentException(null, nameof(productDto));
            }

            product.Description = productDto.Description;
            _dbContext.SaveChanges();
        }
    }
}
