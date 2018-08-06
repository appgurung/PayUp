using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Utilities
{
    public static class BankSortCode
    {
        public static string GetSortCode(string BankName)
        {
            if(BankName.Equals("Access Bank"))
            {
                return "000014";
            }
            else if(BankName.Equals("Keystone Bank"))
            {
                return "000002";
            }
            else if(BankName.Equals("Diamond Bank"))
            {
                return "000005";
            }
            else if(BankName.Equals("Ecobank Bank"))
            {
                return "000010";
            }
            else if(BankName.Equals("Fidelity Bank"))
            {
                return "000007";
            }
            else if(BankName.Equals("First Bank of Nigeria"))
            {
                return "000016";
            }
            else if(BankName.Equals("First City Monument Bank"))
            {
                return "000003 ";
            }
            else if(BankName.Equals("GTBank Plc"))
            {
                return "000013 ";
            }
            else if(BankName.Equals("StanbicIBTC Bank"))
            {
                return "000012";
            }
            else if(BankName.Equals("Citi Bank"))
            {
                return "000009";
            }
            else if(BankName.Equals("Skye Bank"))
            {
                return "000008";
            }
            else if(BankName.Equals("Enterprise Bank"))
            {
                return "000019 ";
            }
            else if(BankName.Equals("StandardChartered"))
            {
                return "000021";
            }
            else if(BankName.Equals("Sterling Bank"))
            {
                return "000001";
            }
            else if(BankName.Equals("Union Bank"))
            {
                return "000018";
            }
            else if(BankName.Equals("United Bank for Africa"))
            {
                return "000004";
            }
            else if(BankName.Equals("Unity Bank"))
            {
                return "000011";
            }
            else if(BankName.Equals("Wema Bank"))
            {
                return "000017";
            }
            else if(BankName.Equals("Zenith Bank"))
            {
                return "000015";
            }
            else if(BankName.Equals("Heritage Bank"))
            {
                return "000020";
            }
            else if(BankName.Equals("JAIZ Bank"))
            {
                return "000006";
            }

            return null;
        }
    }
}