using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Products.dB;
using Products.dto;
using Products.Mappers;
using Products.Models;

namespace Products.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _dbContext;
        public ProductService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> AddProductAsync(CreateProductDto createProductDto)
        {
            var newProduct = createProductDto.ToProduct();
            await _dbContext.Products.AddAsync(newProduct);
            await _dbContext.SaveChangesAsync();
            return newProduct;
        }

        public async Task<bool> DeleteProductAsync(int Id)
        {
            int rowsaffected = await _dbContext.Products.Where(p => p.Id == Id).ExecuteDeleteAsync();
            return rowsaffected > 0;
        }

        public async Task<IEnumerable<ViewProductDto>> GetAllProductsAsync()
        {
            var products = await _dbContext.Products.ToListAsync();
            var response = products.ToViewProduct();
            return response;
        }

        public async Task<Product?> GetProductAsync(int Id)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == Id);
            return product;
        }

        public async Task<bool> UpdateProductAsync(int Id, CreateProductDto createProductDto)
        {
            var rowsaffected = await _dbContext.Products.Where(p => p.Id == Id).ExecuteUpdateAsync(s => s.SetProperty(p => p.Name, createProductDto.Name).SetProperty(p => p.Description, createProductDto.Description).SetProperty(p => p.Price, createProductDto.Price));
            return rowsaffected > 0;
        }
    }
}