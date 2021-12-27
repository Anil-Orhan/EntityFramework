using System;
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
using FluentValidation;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Business.BusinessAspects.Autofac;

namespace Business.Concrete
{
   public class ProductManager:IProductService
    {
        private IProductDal _productDal;
        private ICategoryService _categoryService;
       
        //İş kuralı gereği categoriler tablosuna ulaşmamız gerektiğinden CategoryService Injection yaptık. Ancak DİKKAT ICategoryDal Inject etmedik. 
        //Bir manager'ın içerisine başka bir nesnenin Dal'ı Inject edilmez!!!!!
        public ProductManager(IProductDal productDal,ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }
        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
           IResult result= BusinessRules.Run(ChectIfProductCountOfCategoryCorrect(product.CategoryID), 
                CheckProductNameDuplication(product.ProductName), CheckCategoryLimitTEST());

            if (result!=null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
            
            
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


        #region BusinessRules
        private IResult ChectIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryID == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.CategoryLimitError);

            }
            return new SuccessResult();
        }

        private IResult CheckProductNameDuplication(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameDuplicationError);

            }
            return new SuccessResult();
        }
        private IResult CheckCategoryLimitTEST()
        {
            var result = _categoryService.GetAll().Data.Count; 
            if (result>=15)
            {
                return new ErrorResult("Category Limit Exceded!");

            }
            return new SuccessResult();
        }

        #endregion
    }
}
