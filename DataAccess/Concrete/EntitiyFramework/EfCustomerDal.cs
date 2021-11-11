using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Concrete.EntitiyFramework;
using Entities.Concrete;

namespace DataAccess.Concrete.EntitiyFramework
{
    class EfCustomerDal:EfEntityRepositoryBase<Customer, NorthwindContext>, ICustomerDal
    {
        //DATA CRUD

    }
}
