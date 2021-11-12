using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
   public class CustomerManager:ICustomerService
   {
       private ICustomerDal _customerDal;

       public CustomerManager(ICustomerDal customerDal)
       {
           _customerDal = customerDal;

       }
        public IResult Add(Customer entity)
        {
            _customerDal.Add(entity);
            return new Result(true, Messages.ProductAdded);

        }

        public void Delete(Customer entity)
        {
            _customerDal.Delete(entity);
        }

        public void Update(Customer entity)
        {
            _customerDal.Update(entity);
        }

        public IDataResult<List<Customer>> GetAll()
        {
           return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(),Messages.ProductListed);
        }

        public Customer GetById(int Id)
        {
          return  _customerDal.Get(p => p.CustomerId == Id.ToString()); 
          //Northwind veritabanında  CustomerID string değerlidir. O yüzden .ToString kullandık. Kod hata vermeyecektir
          //Ancak çalışmayacaktır! Düzeltilecek

        }
    }
}
