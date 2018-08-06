using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Utilities
{
    public class GlobalData
    {
        private static string UsersRole
        {
            set
            {
                HttpContext.Current.Session["Role"] = value;
            }

            get
            {
                if (HttpContext.Current.Session["Role"] == null)
                { return string.Empty; }
                else
                {
                    return HttpContext.Current.Session["Role"].ToString();
                }
            }
        }

        private static string UserName
        {
            set
            {
                HttpContext.Current.Session["Email"] = value;
            }

            get
            {
                if (HttpContext.Current.Session["Email"] == null)
                { return string.Empty; }
                else
                {
                    return HttpContext.Current.Session["Email"].ToString();
                }
            }
        }

        private static string FullName
        {
            set
            {
                HttpContext.Current.Session["FullName"] = value;
            }

            get
            {
                if (HttpContext.Current.Session["FullName"] == null)
                { return string.Empty; }
                else
                {
                    return HttpContext.Current.Session["FullName"].ToString();
                }
            }
        }

        private static string UserID
        {
            set
            {
                HttpContext.Current.Session["UserID"] = value;
            }

            get
            {
                if (HttpContext.Current.Session["UserID"] == null)
                { return string.Empty; }
                else
                {
                    return HttpContext.Current.Session["UserID"].ToString();
                }
            }
        }

        private static string PhoneNo
        {
            set
            {
                HttpContext.Current.Session["PhoneNo"] = value;
            }

            get
            {
                if (HttpContext.Current.Session["PhoneNo"] == null)
                { return string.Empty; }
                else
                {
                    return HttpContext.Current.Session["PhoneNo"].ToString();
                }
            }
        }

        private static string CurrentBalance
        {
            set
            {
                HttpContext.Current.Session["CurrentBalance"] = value;
            }

            get
            {
                if (HttpContext.Current.Session["CurrentBalance"] == null)
                { return string.Empty; }
                else
                {
                    return HttpContext.Current.Session["CurrentBalance"].ToString();
                }
            }
        }

        public static string getUserRoleFromApplication
        {


            get
            {
                if (UsersRole == null)
                { return string.Empty; }
                else
                {
                    HttpContext.Current.Session["getUserRoleFromApplication"] = UsersRole;
                    return HttpContext.Current.Session["getUserRoleFromApplication"].ToString();
                }
            }
        }

        public static string getUerNameFromApplication
        {


            get
            {
                if (UserName == null)
                { return string.Empty; }
                else
                {
                    HttpContext.Current.Session["getUserNameFromApplication"] = UserName;
                    return HttpContext.Current.Session["getUserNameFromApplication"].ToString();
                }
            }
        }

        public static string getFullNameFromApplication
        {


            get
            {
                if (FullName == null)
                { return string.Empty; }
                else
                {
                    HttpContext.Current.Session["getUserNameFromApplication"] = FullName;
                    return HttpContext.Current.Session["getUserNameFromApplication"].ToString();
                }
            }
        }

        public static string getUserIDFromApplication
        {


            get
            {
                if (UserID == null)
                { return string.Empty; }
                else
                {
                    HttpContext.Current.Session["getUserIDFromApplication"] = UserID;
                    return HttpContext.Current.Session["getUserIDFromApplication"].ToString();
                }
            }
        }

        public static string getPhoneNoFromApplication
        {


            get
            {
                if (PhoneNo == null)
                { return string.Empty; }
                else
                {
                    HttpContext.Current.Session["getPhoneNoFromApplication"] = PhoneNo;
                    return HttpContext.Current.Session["getPhoneNoFromApplication"].ToString();
                }
            }
        }

        public static string getCurrentBalanceFromApplication
        {


            get
            {
                if (CurrentBalance == null)
                { return string.Empty; }
                else
                {
                    HttpContext.Current.Session["getCurrentBalanceFromApplication"] = CurrentBalance;
                    return HttpContext.Current.Session["getCurrentBalanceFromApplication"].ToString();
                }
            }
        }

        public void setUserRoleFromApplication(string UserByType)
        {
            UsersRole = "";
            if (UserByType == "Administrator")
            {
                UsersRole = "Administrator";
            }
            else if (UserByType == "Developer")
            {
                UsersRole = "Developer";
            }
            else if (UserByType == "SupportAnalyst")
            {
                UsersRole = "SupportAnalyst";
            }
            else if (UserByType == "Analyst")
            {
                UsersRole = "Analyst";
            }
            else if (UserByType == "ViewOnly")
            {
                UsersRole = "ViewOnly";
            }
        }


        public void setUserNameFromApplication(string User)
        {
            UserName = "";

            UserName = User;
      
        }

        public void setFullNameFromApplication(string Name)
        {
            FullName = Name;

        }

        public void setUserIDFromApplication(string ID)
        {
            UserID = ID;

        }

        public void setPhoneNoFromApplication(string No)
        {
            PhoneNo = No;

        }

        public void setCurrentBalanceFromApplication(string Balance)
        {
            CurrentBalance = Balance;

        }
    }
}