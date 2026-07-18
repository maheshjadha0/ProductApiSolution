using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Implementations
{
    public class ProductRepository :GenericRepository<Product>,IProductRepository
    {
      

        public ProductRepository(ApplicationDbContext context):base(context) 
        {
        }

        public async Task<Product?> GetProductWithItemAsync(int id)
        {
            return await _context.Products
                            .Include(p=>p.Items)
                            .FirstOrDefaultAsync(p=>p.Id==id);
        }
        public async Task<bool> ProductExistsAsync(string productName)
        {
            return await _context.Products.AnyAsync(p=>p.ProductName==productName);
        }

    }
}
