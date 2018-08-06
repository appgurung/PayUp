using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CashBox.Models
{
    public class UserProfileUpdate
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Gender { get; set; }
    }
}