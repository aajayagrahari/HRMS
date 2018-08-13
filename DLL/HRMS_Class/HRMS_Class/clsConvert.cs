using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRMS_Class
{
    public class clsConvert
    {
        public static DateTime? ToDateTime(string value)
        {
            string subString = "-";
            if (value == null || value.Trim().Length == 0)
            {
                return null;
            }
            else
            {
                value.Trim();
                int strfirst = value.IndexOf(subString);
                int strSecond = value.LastIndexOf(subString);
                DateTime d = Convert.ToDateTime(value.Substring(strfirst + 1, strSecond - strfirst - 1).Trim() + "-" + value.Substring(0, strfirst).Trim() + "-" + value.Substring(strSecond + 1).Trim());
                return d;
                //return Convert.ToDateTime(value.Substring(strfirst + 1, strSecond - strfirst - 1).Trim() + "/" + value.Substring(0, strfirst).Trim() + "/" + value.Substring(strSecond + 1).Trim());
                //return Convert.ToDateTime(value.Substring(0, strfirst).Trim() + "-" + value.Substring(strfirst + 1, strSecond - strfirst - 1).Trim() + "-" + value.Substring(strSecond + 1).Trim());
            }
        }
        public static DateTime? ToDateTime1(string value)
        {
            string subString = "/";
            if (value == null || value.Trim().Length == 0)
            {
                return null;
            }
            else
            {
                value.Trim();
                int strfirst = value.IndexOf(subString);
                int strSecond = value.LastIndexOf(subString);
                DateTime d = Convert.ToDateTime(value.Substring(strfirst + 1, strSecond - strfirst - 1).Trim() + "/" + value.Substring(0, strfirst).Trim() + "/" + value.Substring(strSecond + 1).Trim());
                return d;
                //return Convert.ToDateTime(value.Substring(strfirst + 1, strSecond - strfirst - 1).Trim() + "/" + value.Substring(0, strfirst).Trim() + "/" + value.Substring(strSecond + 1).Trim());
                //return Convert.ToDateTime(value.Substring(0, strfirst).Trim() + "-" + value.Substring(strfirst + 1, strSecond - strfirst - 1).Trim() + "-" + value.Substring(strSecond + 1).Trim());
            }
        }
    }
}
