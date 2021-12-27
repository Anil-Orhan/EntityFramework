using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntitiyFramework
{ 
    //Context (İçerik)  : Db tabloları ile proje classlarını iliştirmek
   public class NorthwindContext:DbContext
    {
        //Db'nin tanıtılması için kullandığımız hazır virtual metot
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Server bağlantısı
            optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectsV13; Database=Northwind; Trusted_Connection=true");
        }

        //Db tabloları ile kendi oluşturduğumuz nesneleri ilişkilendirme
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
