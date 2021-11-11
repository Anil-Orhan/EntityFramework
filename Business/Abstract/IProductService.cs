using DataAccess.Concrete.EntitiyFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    
    public interface IProductService:IBusinessService<Product>
    {
        
        List<Product> GetByUnitPrice(decimal min,decimal max);
        List<ProductDetailDto> GetProductDetails();

    }
}
