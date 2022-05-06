using Entites.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator : AbstractValidator<ProductImage>
    {
        public CarImageValidator()
        {

                RuleFor(c => c.ProductId).NotNull();

        }
    }
}
