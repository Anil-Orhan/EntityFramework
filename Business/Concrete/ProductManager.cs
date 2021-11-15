﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;

namespace Business.Concrete
{
   public class ProductManager:IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }


        public IResult Add(Product product)
        {

            if (product.ProductName.Length<2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productDal.Add(product);
            return new Result(true,Messages.ProductAdded);
        }

        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }

        public DataResult<List<Product>> GetAll()
        {
           
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductListed);
        } 


        public DataResult<Product> GetById(int Id)
        {
           return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductID == Id),"This Product");
        }


        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice>=min&&p.UnitPrice<=max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }

       
    }
}
