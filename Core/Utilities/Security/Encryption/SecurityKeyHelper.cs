using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
    public  class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey) 
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));  
            //şifreyi byte[] haline getiriyor.
            //Simetrik Güvenlik Anahtarına Çeviriyor
            //JWT'nin ihtiyaç duyduğu formata dönüştürüyor.
        
        }


    }
}
