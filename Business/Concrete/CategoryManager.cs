using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }


        public IResult Add(Category entity)
        {
            _categoryDal.Add(entity);
            return new SuccessResult("Success");
        }

        public void Delete(Category entity)
        {
            _categoryDal.Delete(entity);
        }

        public DataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
                
        }

        public DataResult<Category> GetById(int Id)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(p=>p.CategoryId==Id));
        }

        public void Update(Category entity)
        {
            _categoryDal.Update(entity);
        }
    }
}
