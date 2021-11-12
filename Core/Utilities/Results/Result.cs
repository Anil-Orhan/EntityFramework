using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
   public class Result:IResult
    {

        public Result(bool success,string message):this(success)
        /*
         Mesaj istemediğimiz durumlar için  sadece işlem sonucu parametresi alan bir ctor yazdık.
         Ancak bu durumda kendimizi tekrar etme durumu olmaması adına success işlemini tek parametreli olan
        ctor'da gerçekleştirdik. Çift parametreli ctor çalıştığında ise otomatikmen tek parametreli ctor'da çalışsın diye
        this() kullandık böylece classın tek parametre alan constructer'ı da çalıştırıldı.
         */
        {
            Message = message;
            
        }
        public Result(bool success)
        {
            Success = success;

        }

        public bool Success { get; }
        public string Message { get; }
    }
}
