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

            var result = productManager.GetProductDetails();
            foreach (var item in result)
            {
                Console.WriteLine(item.ProductID+"--"+item.ProductName+"--"+item.UnitsInStock+"--"+item.CategoryName);
            }


        }
    }
}
