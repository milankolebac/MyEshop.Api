using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyEshop.Api.Controllers;
using MyEshop.Api.DTO;
using MyEshop.Api.Models;
using MyEshop.Api.Services;
using Xunit;

namespace MyEshop.ApiTests.Controllers
{
    
    public class ProductControllerTests
    {
        private readonly ProductController _productcontroller;

        public ProductControllerTests()
        {
            var dbContext = CreateTestDbContext();
            _productcontroller = new ProductController(new ProductService(dbContext));
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            var okResult = _productcontroller.Get();

           Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            var result = _productcontroller.Get().Result;

            var items = Assert.IsType<List<ProductDTO>>(((OkObjectResult)result).Value);
            Assert.Equal(5, items.Count);
        }

        [Fact]
        public void GetById_InknownIdPassed_ReturnNotFoundResult()
        {
            var notFoundResult = _productcontroller.Get(10);

            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnOkResult()
        {
            var okResult = _productcontroller.Get(1);

            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void UpdateTest_ExistingIdAndCorrectObjectPassed_ReturnNoContent()
        {
            var productToUpdate = new ProductDTO(){Id=5, Name = "Product 5", Price = 5, Description = "Test update"};

            var notContentResult = _productcontroller.Update(5, productToUpdate);

            Assert.IsType<NoContentResult>(notContentResult);

            var product = Assert.IsType<ProductDTO>(((OkObjectResult)_productcontroller.Get(5).Result).Value);
            Assert.Equal(product.Description, productToUpdate.Description);
        }

        [Fact]
        public void UpdateTest_ExistingIdAndCorrectObjectPassed_CheckUpdatetContent()
        {
            var productToUpdate = new ProductDTO(){Id=5, Name = "Product 5", Price = 5, Description = "Test update"};

            var notContentResult = _productcontroller.Update(5, productToUpdate);

            Assert.IsType<NoContentResult>(notContentResult);
        }

        [Fact]
        public void UpdateTest_DifferentIdAndObjectPassed_ReturnBadRequest()
        {
            var productToUpdate = new ProductDTO(){Id=5, Name = "Product 5", Price = 5, Description = "Test update"};

            var badRequestResult = _productcontroller.Update(4, productToUpdate);

            Assert.IsType<BadRequestResult>(badRequestResult);
        }

        [Fact]
        public void UpdateTest_NotExistingIdPassed_ReturnNotFound()
        {
            var productToUpdate = new ProductDTO(){Id=6, Name = "Product 5", Price = 5, Description = "Test update"};

            var notFoundResult = _productcontroller.Update(6, productToUpdate);

            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        private EshopContext CreateTestDbContext()
        {
            var builder = new DbContextOptionsBuilder<EshopContext>();
            builder.UseInMemoryDatabase(databaseName: "EshopTest");

            var dbContextOptions = builder.Options;
            var dbContext = new EshopContext(dbContextOptions);

            var eshopContextSeedData = new EshopContextSeedData(dbContext);
            eshopContextSeedData.SeedProducts();

            return dbContext;
        }
    }
}