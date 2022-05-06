using Entites.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Product>
    {
        public CarValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).MinimumLength(2);
            RuleFor(c => c.UnitPrice).NotEmpty();
            RuleFor(c => c.UnitPrice).GreaterThan(0);
            RuleFor(c => c.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.Id == 1);
        }
    }
}
