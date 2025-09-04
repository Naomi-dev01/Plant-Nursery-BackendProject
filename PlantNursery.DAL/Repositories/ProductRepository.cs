using Microsoft.EntityFrameworkCore;
using PlantNursery.DAL.Context;
using PlantNursery.DAL.Entities;
using PlantNursery.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantNursery.DAL.Repositories
{
    public class ProductRepository: IProductRepository

    {
        public readonly PlantNurseryDbContext _context;

        public ProductRepository(PlantNurseryDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProductsByCategory(int categoryId)
        {
            return await _context.Products
        .Where(p => p.CategoryId == categoryId)
        .ToListAsync();
        }
        public async Task<Product?> GetProductById(Guid Id)
        {
            return await _context.Products.FindAsync(Id);
        }
    }
}
