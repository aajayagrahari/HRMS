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
    public class RequitmentRegistrationMaster
    {
        int _AdvertisementId;
        long _RRId = 0;
        string _Post;
        string _FName;
        string _MName;
        string _LName;
        string _FatherFname;
        string _FatherMName;
        string _FatherLName;
        string _Dob;
        string _Category;
        string _CAddress;
        string _CCity;
        string _CState;
        string _CPincode;
        string _PAddress;
        string _PCity;
        string _PState;
        string _PPincode;
        string _Email;
        string _Mobile;
        string _TotalEperience;
        string _NameOfOrg;
        string _NameOfPost;
        string _DateOfApplied;
        string _OutCome;
        string _AboutCompany;
        string _Resume;



        string _PhoneNo;
        string _CardNo;
        string _DateOfIssue;
        string _IssueingAuthority;
        string _Photo;
        string _Signature;
        string _Certificate;
        public string PhoneNo
        {
            get
            {
                return _PhoneNo;
            }
            set
            {
                _PhoneNo = value;
            }
        }
        public string CardNo
        {
            get
            {
                return _CardNo;
            }
            set
            {
                _CardNo = value;
            }
        }
        public string DateOfIssue
        {
            get
            {
                return _DateOfIssue;
            }
            set
            {
                _DateOfIssue = value;
            }
        }
        public string IssueingAuthority
        {
            get
            {
                return _IssueingAuthority;
            }
            set
            {
                _IssueingAuthority = value;
            }
        }
        public string Photo
        {
            get
            {
                return _Photo;
            }
            set
            {
                _Photo = value;
            }

        }
        public string Signature
        {
            get
            {
                return _Signature;
            }
            set
            {
                _Signature = value;
            }

        }
        public string Certificate
        {
            get
            {
                return _Certificate;
            }
            set
            {
                _Certificate = value;
            }

        }
        public int AdvertisementId
        {
            get
            {
                return _AdvertisementId;
            }
            set
            {
                _AdvertisementId = value;
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
        public string Post
        {
            get
            {
                return _Post;
            }
            set
            {
                _Post = value;
            }
        }
        public string FName
        {
            get
            {
                return _FName;
            }
            set
            {
                _FName = value;
            }
        }
        public string MName
        {
            get
            {
                return _MName;
            }
            set
            {
                _MName = value;
            }
        }
        public string LName
        {
            get
            {
                return _LName;
            }
            set
            {
                _LName = value;
            }
        }
        public string FatherFname
        {
            get
            {
                return _FatherFname;
            }
            set
            {
                _FatherFname = value;
            }
        }
        public string FatherMName
        {
            get
            {
                return _FatherMName;
            }
            set
            {
                _FatherMName = value;
            }
        }
        public string FatherLName
        {
            get
            {
                return _FatherLName;
            }
            set
            {
                _FatherLName = value;
            }
        }
        public string Dob
        {
            get
            {
                return _Dob;
            }
            set
            {
                _Dob = value;
            }
        }
        public string Category
        {
            get
            {
                return _Category;
            }
            set
            {
                _Category = value;
            }
        }
        public string CAddress
        {
            get
            {
                return _CAddress;
            }
            set
            {
                _CAddress = value;
            }
        }
        public string CCity
        {
            get
            {
                return _CCity;
            }
            set
            {
                _CCity = value;
            }
        }
        public string CState
        {
            get
            {
                return _CState;
            }
            set
            {
                _CState = value;
            }
        }
        public string CPincode
        {
            get
            {
                return _CPincode;
            }
            set
            {
                _CPincode = value;
            }

        }
        public string PAddress
        {
            get
            {
                return _PAddress;
            }
            set
            {
                _PAddress = value;
            }

        }
        public string PCity
        {
            get
            {
                return _PCity;
            }
            set
            {
                _PCity = value;
            }

        }
        public string PState
        {
            get
            {
                return _PState;
            }
            set
            {
                _PState = value;
            }

        }
        public string PPincode
        {
            get
            {
                return _PPincode;
            }
            set
            {
                _PPincode = value;
            }

        }

        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            }
        }
        public string Mobile
        {
            get
            {
                return _Mobile;
            }
            set
            {
                _Mobile = value;
            }
        }
        public string TotalEperience
        {
            get
            {
                return _TotalEperience;
            }
            set
            {
                _TotalEperience = value;
            }
        }
        public string NameOfOrg
        {
            get
            {
                return _NameOfOrg;
            }
            set
            {
                _NameOfOrg = value;
            }
        }
        public string NameOfPost
        {
            get
            {
                return _NameOfPost;
            }
            set
            {
                _NameOfPost = value;
            }
        }
        public string DateOfApplied
        {
            get
            {
                return _DateOfApplied;
            }
            set
            {
                _DateOfApplied = value;
            }
        }
        public string OutCome
        {
            get
            {
                return _OutCome;
            }
            set
            {
                _OutCome = value;
            }
        }
        public string AboutCompany
        {
            get
            {
                return _AboutCompany;
            }
            set
            {
                _AboutCompany = value;
            }

        }
        public string Resume
        {
            get
            {
                return _Resume;
            }
            set
            {
                _Resume = value;
            }

        }



    }
}
