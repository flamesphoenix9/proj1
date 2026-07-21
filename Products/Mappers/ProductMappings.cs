using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Products.dto;
using Products.Models;

namespace Products.Mappers
{
    public static class ProductMappings
    {
        public static Product ToProduct(this CreateProductDto createProductDto)

        {
            return new Product()
            {
                Name = createProductDto.Name,
                Description = createProductDto.Description,
                Price = createProductDto.Price
            };
        }
        public static List<ViewProductDto> ToViewProduct(this List<Product> products)
        {
            return products.Select(p => new ViewProductDto()
            {
                Name = p.Name,
                Description = p.Description,
                Price = p.Price
            }).ToList();
        }
    };

}