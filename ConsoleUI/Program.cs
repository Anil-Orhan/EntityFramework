using DataAccess.Concrete.EntitiyFramework;
using System;
using System.Linq;
using Business.Concrete;
using DataAccess.Concrete.EntitiyFramework;


namespace ConsoleUI
{
    class Program
    {

        //SOLID--Open Closed Principle
        
        static void Main(string[] args)
        {
            OrderManager orderManager = new OrderManager(new EfOrderDal());
            ProductManager productManager = new ProductManager(new EfProductDal());

            var result = productManager.GetAll();
            foreach (var item in result.Data)
            {
                Console.WriteLine(item.ProductID+"--"+item.ProductName+"--"+item.UnitsInStock+"--"+item.UnitPrice);
            }


        }
    }
}
