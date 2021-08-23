using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyEshop.Api.DTO;
using MyEshop.Api.Services;

namespace MyEshop.Api.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;


        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Retrieves a specific product by Id
        /// </summary>
        /// <param name="id">Product item Id</param>
        /// <returns>Product</returns>
        /// <response code="200">Returns the product item</response>
        /// <response code="404">If product not found</response>
        [ApiVersion("1.0")]
        [HttpGet("{id:int}")]
        [ProducesResponseType (StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ProductDTO> Get(int id)
        {
            var product = _productService.GetById(id);
            if (product is null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        /// <summary>
        /// Retrieves all product items
        /// </summary>
        /// <returns>All product</returns>
        /// /// <response code="200">Returns the product items list</response>
        [ApiVersion("1.0")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<ProductDTO>> Get()
        {
            var products = _productService.GetAll();
            return Ok(products);
        }

        /// <summary>
        /// Update description of specific product
        /// </summary>
        /// <param name="id">Product item Id</param>
        /// <param name="product">Requested model</param>
        /// <returns></returns>
        /// <response code="204">If product description was updated successfully</response>
        /// <response code="404">If product with specified Id not found</response>
        /// <response code="400">For bad request</response>
        [ApiVersion("1.0")]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Update(int id, ProductDTO product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            try
            {
                _productService.Update(product);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
            
            return NoContent();
        }
    }
}
