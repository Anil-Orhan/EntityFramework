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
        DataResult<List<T>> GetAll();
        DataResult<T> GetById(int Id);
        
    }
}
