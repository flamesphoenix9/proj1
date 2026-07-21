using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Products.dto;
using Products.Models;

namespace Products.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ViewProductDto>> GetAllProductsAsync();
        Task<Product?> GetProductAsync(int Id);
        Task<Product> AddProductAsync(CreateProductDto createProductDto);
        Task<bool> DeleteProductAsync(int Id);
        Task<bool> UpdateProductAsync(int Id,CreateProductDto createProduct);
    }
}