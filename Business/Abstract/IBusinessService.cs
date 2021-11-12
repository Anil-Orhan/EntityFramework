using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IBusinessService<T>
    {
        IResult Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        IDataResult<List<T>> GetAll();
        T GetById(int Id);
        
    }
}
