//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CashBox
{
    using System;
    using System.Collections.Generic;
    
    public partial class ApiKey
    {
        public int KeyID { get; set; }
        public string MerchantID { get; set; }
        public string TestPrivateKey { get; set; }
        public string TestPublicKey { get; set; }
        public string LivePrivateKey { get; set; }
        public string LivePublicKey { get; set; }
        public Nullable<bool> isLiveMode { get; set; }
    }
}
