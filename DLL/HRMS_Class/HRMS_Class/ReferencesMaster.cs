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
  public class ReferencesMaster
    {

     long _ReferencesId;
string _Name;
string _Address;
string _Contact;
long _RRId;

public long ReferencesId
        {
            get
            {
                return _ReferencesId;
            }
            set
            {
                _ReferencesId = value;
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
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }
        public string Address
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
            }
        }
        public string Contact
        {
            get
            {
                return _Contact;
            }
            set
            {
                _Contact = value;
            }
        }
       
    }
}
