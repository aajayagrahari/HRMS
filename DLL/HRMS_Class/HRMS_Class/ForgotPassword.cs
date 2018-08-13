using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace FHEL_Class
{
    public class ForgotPassword
    {
        private string _EmailId;
        private string _LoginId;
        private string _Password;

        public string EmailId
        {
            get
            {
                return _EmailId;
            }
            set
            {
                _EmailId = value;
            }
        }

        public string LoginId
        {
            get
            {
                return _LoginId;
            }
            set
            {
                _LoginId = value;
            }
        }

        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }

        public void SetObjectInfo(DataRow dr)
        {
            this.EmailId = Convert.ToString(dr["EmailId"]);
            this.LoginId = Convert.ToString(dr["LoginId"]);
            this.Password = Convert.ToString(dr["Password"]);
        }
    }
}
