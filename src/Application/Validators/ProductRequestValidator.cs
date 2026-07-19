using Application.DTOs.Product;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class ProductRequestValidator : AbstractValidator<ProductRequestDto>
    {
        public ProductRequestValidator() 
        { 
            RuleFor(x=>x.ProductName).NotEmpty().WithMessage("Product name is required")
                .MaximumLength(255).WithMessage("Product name Cannot exceed 255 characters");
        }
    }
}
