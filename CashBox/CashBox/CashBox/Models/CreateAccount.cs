using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CashBox.Models
{
    public class CreateAccount
    {
        public string FullName { get; set; }

        public string PhoneNo { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}