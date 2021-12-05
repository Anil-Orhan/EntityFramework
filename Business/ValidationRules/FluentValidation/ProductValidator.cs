﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
   public class ProductValidator:AbstractValidator<Product>//ProductValidator <Product> için bir Validator'dır!
    {
        public ProductValidator()
        {
            RuleFor(p=>p.ProductName).MinimumLength(2);
            //p ilgili nesne olan Product'tır
            //RuleFor: Kuralİçin --> Kural (Product) için
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitPrice).GreaterThan(10).When(p => p.CategoryID == 1);
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalıdır!");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
