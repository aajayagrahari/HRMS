using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ErrorHandler;
using HRMS_Class;
using System.Data;
using HRMS_Connection;
#region Developnet Detatil
//Developer Name: Harendra Kumar Maurya
//Date:           19-10-2013
#endregion Developnet Detatil
namespace HRMS_Class
{
   public class LanguageMaster
    {
     long  _LanguageId;
     string _Language;
string _Reads;
string _Speak;
string _Write;
long _RRId;

public long LanguageId
        {
            get
            {
                return _LanguageId;
            }
            set
            {
                _LanguageId = value;
            }
        }
        public long RRId
        {
            get
            {
                return _RRId;
            }
            set
            {
                _RRId = value;
            }
        }
        public string Language
        {
            get
            {
                return _Language;
            }
            set
            {
                _Language = value;
            }
        }
        public string Reads
        {
            get
            {
                return _Reads;
            }
            set
            {
                _Reads = value;
            }
        }
        public string Speak
        {
            get
            {
                return _Speak;
            }
            set
            {
                _Speak = value;
            }
        }
        public string Write
        {
            get
            {
                return _Write;
            }
            set
            {
                _Write = value;
            }
        }
    }
}
