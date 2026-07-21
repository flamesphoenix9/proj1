using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Products.Models;

namespace Products.dto
{
    public record CreateProductDto
    {
        public required string Name { get; init; }
        public string? Description { get; init; }
        public required decimal Price { get; init; }
    }
}