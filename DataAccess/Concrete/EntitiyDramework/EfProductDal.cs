using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntitiyDramework
{
   public class EfProductDal:IProductDal
    {
        public void Add(Product entity)
        {
            /*
             * using  ile yapılan işlem bittiği anda oluşturulan nesne bellekten silinir
             * Performans açısından context gibi performans gerektiren objelerde using kullanılması optimizasyon açısından önemlidir.
            */
            //IDisposable Pattern Implementation Of C#
            using (NorthwindContext context=new NorthwindContext())
            {
                var addedEntity = context.Entry(entity); //verilen entity ile veri tabanındaki entityi eşle (Bu durumda bulamayacak)
                addedEntity.State = EntityState.Added; //Bu nesneyi veri tabanına ekle
                context.SaveChanges(); // Değişiklikleri Kaydet
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity); //verilen entity ile veri tabanındaki entityi eşle 
                deletedEntity.State = EntityState.Deleted; //Bu nesneyi veri tabanından sil
                context.SaveChanges(); // Değişiklikleri Kaydet
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity); //verilen entity ile veri tabanındaki entityi eşle 
                updatedEntity.State = EntityState.Modified; //Bu nesneyi veri tabanında güncelle
                context.SaveChanges(); // Değişiklikleri Kaydet
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);

            }
        }

      public  List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null 
                    ? context.Set<Product>().ToList() 
                    : context.Set<Product>().Where(filter).ToList();
            }
        }
       


    }

        
    
}
