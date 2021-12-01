using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagmentPortal
{
    public class SessionHelper
    {
        public static int CurrentStudentId
        {
            set
            {
                HttpContext.Current.Session["CurrentStudentId"] = value;
            }
            get
            {
                return Convert.ToInt32(HttpContext.Current.Session["CurrentStudentId"]);
            }
        }

        public static int CurrentStudentInfoId
        {
            set
            {
                HttpContext.Current.Session["CurrentStudentInfoId"] = value;
            }
            get
            {
                return Convert.ToInt32(HttpContext.Current.Session["CurrentStudentInfoId"]);
            }
        }
    }
}