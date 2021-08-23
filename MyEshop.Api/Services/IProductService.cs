using System.Collections.Generic;
using MyEshop.Api.DTO;

namespace MyEshop.Api.Services
{
    public interface IProductService
    {
        ProductDTO GetById(int id);
        List<ProductDTO> GetAll();
        void Update(ProductDTO product);
    }
}