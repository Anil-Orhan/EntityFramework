using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using DataAccess.Abstract;
using DataAccess.Concrete.EntitiyFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.Utilities.Interceptors.MethodInterception;

namespace Business.DependencyResolvers.Autofac
{
  public  class AutofacBusinessModule:Module //Autofac Modulününün Injection işlemi
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Autofac ile IOC işleminlerini veriyoruz
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            //IProductService istendiğinde ProductManager instance'ı üret. .SingleInstance ile tüm programda tek bir instance ile çalışması sağlanır.
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }


    }
}
