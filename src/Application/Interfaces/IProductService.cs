using Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductService
    {
      public  Task<IEnumerable<ProductResponseDto>> GetAllAsync();
        public Task<ProductResponseDto?>GetByIdAsync(int id);
        public Task<ProductResponseDto> CreateAsync(ProductRequestDto dto);
        public Task<bool> UpdateAsync(int  id, UpdateProductDto dto);
        public Task<bool> DeleteAsync(int id);
    }
}
