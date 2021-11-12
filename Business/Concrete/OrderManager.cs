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
   public class OrderManager:IOrderService
    {
        private IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;

        }

        public IResult Add(Order entity)
        {
            _orderDal.Add(entity);
            return new Result(true, Messages.ProductAdded);
        }

        public void Delete(Order entity)
        {
            _orderDal.Delete(entity);
        }

        public void Update(Order entity)
        {
            _orderDal.Update(entity);
        }

        public IDataResult<List<Order>> GetAll()
        {
            return new DataResult<List<Order>>(_orderDal.GetAll(), true, "Products Listed!");
        }

        public Order GetById(int Id)
        {
            return _orderDal.Get(o => o.OrderID == Id);
        }
    }
}
