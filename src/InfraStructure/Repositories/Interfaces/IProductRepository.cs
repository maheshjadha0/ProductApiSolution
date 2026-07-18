using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IProductRepository :IGenericRepository<Product>
    {
        Task<Product?> GetProductWithItemAsync(int id);
        Task<bool> ProductExistsAsync(string productName);
    }
}
