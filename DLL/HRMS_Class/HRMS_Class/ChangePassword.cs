using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HRMS_Class
{
    public class ChangePassword
    {
        private string _LoginId;
        private string _OldPassword;
        private string _NewPassword;

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

        public string OldPassword
        {
            get
            {
                return _OldPassword;
            }
            set
            {
                _OldPassword = value;
            }
        }

        public string NewPassword
        {
            get
            {
                return _NewPassword;
            }
            set
            {
                _NewPassword = value;
            }
        }

        public void SetObjectInfo(DataRow dr)
        {
            this.LoginId = Convert.ToString(dr["LoginId"]);
            this.NewPassword = Convert.ToString(dr["Password"]);
            this.OldPassword = Convert.ToString(dr["Password"]);
        }
    }
}
