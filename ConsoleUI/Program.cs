using DataAccess.Concrete.EntitiyDramework;
using System;
using Business.Concrete;


namespace ConsoleUI
{
    class Program
    {

        //SOLID--Open Closed Principle
        
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
           
            var result =productManager.GetByUnitPrice(5,15);
            foreach (var item in result)
            {
                Console.WriteLine(item.ProductName+ "  " + item.UnitPrice);
            }
        }
    }
}
