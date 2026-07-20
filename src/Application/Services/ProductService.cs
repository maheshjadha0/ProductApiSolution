using Application.DTOs.Product;
using Application.Interfaces;
using AutoMapper;
using Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entities;
using Domain.Exceptions;
namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork  _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductResponseDto>> GetAllAsync()
        {
            var product = await _unitOfWork.Products.GetAllAsync();
          
            return _mapper.Map<IEnumerable<ProductResponseDto>>(product);
        }
        public async Task<ProductResponseDto?>GetByIdAsync(int id)
        {
            var product = await _unitOfWork.Products.GetProductWithItemAsync(id);

            return _mapper.Map<ProductResponseDto?>(product);
        }
        public async Task<ProductResponseDto>CreateAsync(ProductRequestDto dto)
        {
            if (await _unitOfWork.Products.ProductExistsAsync(dto.ProductName))
                throw new DuplicateProductException("Product already exists");

            var product = _mapper.Map<Product>(dto);


            product.CreatedBy = "Admin";
            product.CreatedOn = DateTime.Now;
            await _unitOfWork.Products.AddAsync(product);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ProductResponseDto>(product);
        }

        public async Task<bool> UpdateAsync(int id, UpdateProductDto dto)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);

            if(product == null)
            {
                return false;
            }

            _mapper.Map(dto , product);

            product.ModifiedBy = "Admin";
            product.ModifiedOn = DateTime.Now;
            _unitOfWork.Products.Update(product);
            await _unitOfWork.SaveChangesAsync();
            return true;
            
        }

        public async Task<bool>DeleteAsync(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);

            if(product == null)
            {
                return false;
            }
            _unitOfWork.Products.Delete(product);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

    }
}
