using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Utilities
{
    public class SHA256Manager
    {

        public string Hash(string value)
        {
            
            return EasyEncryption.SHA.ComputeSHA256Hash(value);
        }


    }
}