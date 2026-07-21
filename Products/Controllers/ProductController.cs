using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Products.dto;
using Products.Mappers;
using Products.Models;
using Products.Services;


namespace Products.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService productService)
        {
            _service = productService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _service.GetAllProductsAsync();
            return Ok(products);
        }
        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetProductById(int Id)
        {
            var response = await _service.GetProductAsync(Id);
            if (response is null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpPatch]
        [Route("{Id}")]
        public async Task<IActionResult> UpdateProduct(int Id, CreateProductDto createProductDto)
        {
            try
            {
                await _service.UpdateProductAsync(Id, createProductDto);
                return NoContent();
            }
            catch (System.Exception)
            {
                return NotFound("Product with id {Id} does not exist");
            }
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> DeleteProduct(int Id)
        {
            try
            {
                await _service.DeleteProductAsync(Id);
                return NoContent();
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductDto createProductDto)
        {
            var product = await _service.AddProductAsync(createProductDto);
            return Ok(product);
        }    
    }
}