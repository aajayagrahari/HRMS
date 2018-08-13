using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HRMS_Class
{
    public class LoginMaster
    {
        private string _LoginId;
        private string _Password;
        private string _idUserLogin;
        private string _IP;
        private string _UserAgent;
        private string _Host;
        private string _LoginDate;
        private string _LastRefreshedDate;
        private int _IsSucessfull;

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

        public string idUserLogin
        {
            get
            {
                return _idUserLogin;
            }
            set
            {
                _idUserLogin = value;
            }
        }

        public string IP
        {
            get
            {
                return _IP;
            }
            set
            {
                _IP = value;
            }
        }

        public string UserAgent
        {
            get
            {
                return _UserAgent;
            }
            set
            {
                _UserAgent = value;
            }
        }

        public string Host
        {
            get
            {
                return _Host;
            }
            set
            {
                _Host = value;
            }
        }

        public string LoginDate
        {
            get
            {
                return _LoginDate;
            }
            set
            {
                _LoginDate = value;
            }
        }

        public string LastRefreshedDate
        {
            get
            {
                return _LastRefreshedDate;
            }
            set
            {
                _LastRefreshedDate = value;
            }
        }

        public int IsSucessfull
        {
            get
            {
                return _IsSucessfull;
            }
            set
            {
                _IsSucessfull = value;
            }
        }

        public void SetObjectInfo(DataRow dr)
        {
            this.LoginId = Convert.ToString(dr["LoginId"]);
            this.Password = Convert.ToString(dr["Password"]);
            this.idUserLogin = Convert.ToString(dr["idUserLogin"]);
            this.IP = Convert.ToString(dr["IP"]);
            this.UserAgent = Convert.ToString(dr["UserAgent"]);
            this.Host = Convert.ToString(dr["Host"]);
            this.LoginDate = Convert.ToString(dr["LoginDate"]);
            this.LastRefreshedDate = Convert.ToString(dr["LastRefreshedDate"]);
        }

    }
}
