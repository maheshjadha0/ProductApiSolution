using Application.DTOs.Product;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<ProductRequestDto, Product>();
            CreateMap<UpdateProductDto, Product>();
            CreateMap<Item, ItemDto>();
            CreateMap<Product, ProductResponseDto>();
        }
    }
}
