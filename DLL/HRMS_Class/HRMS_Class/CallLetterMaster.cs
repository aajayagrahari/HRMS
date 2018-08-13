using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HRMS_Class
{
    public class CallLetterMaster
    {
        private Int32 _CallLetterMasterId;
        private string _Name;
        private string _EmailId;
        private string _Designation;
        private string _Venue;
        private string _InterviewDate;
        private bool _IsDeleted;
        private string _CreatedDate;
        private string _CreatedBy;
        private string _ModifiedDate;
        private string _ModifiedBy;

        private string _CFileName;
        private string _ProjectSiteName;



        public Int32 CallLetterMasterId
        {
            get
            {
                return _CallLetterMasterId;
            }
            set
            {
                _CallLetterMasterId = value;
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
        public string Designation
        {
            get
            {
                return _Designation;
            }
            set
            {
                _Designation = value;
            }
        }
        public string Venue
        {
            get
            {
                return _Venue;
            }
            set
            {
                _Venue = value;
            }
        }
        public string CreatedBy
        {
            get
            {
                return _CreatedBy;
            }
            set
            {
                _CreatedBy = value;
            }
        }
        public string ModifiedBy
        {
            get
            {
                return _ModifiedBy;
            }
            set
            {
                _ModifiedBy = value;
            }
        }
        public bool IsDeleted
        {
            get
            {
                return _IsDeleted;
            }
            set
            {
                _IsDeleted = value;
            }
        }
        public string CreatedDate
        {
            get
            {
                return _CreatedDate;
            }
            set
            {
                _CreatedDate = value;
            }
        }
        public string ModifiedDate
        {
            get
            {
                return _ModifiedDate;
            }
            set
            {
                _ModifiedDate = value;
            }
        }
        public string InterviewDate
        {
            get
            {
                return _InterviewDate;
            }
            set
            {
                _InterviewDate = value;
            }
        }
        public string CFileName
        {
            get
            {
                return _CFileName;
            }
            set
            {
                _CFileName = value;
            }

        }
        public string ProjectSiteName
        {
            get
            {
                return _ProjectSiteName;
            }
            set
            {
                _ProjectSiteName = value;
            }
        }

        public void SetObjectInfo(DataRow dr)
        {
            this.CallLetterMasterId = Convert.ToInt32(dr["CallLetterMasterId"]);
            this.Name = Convert.ToString(dr["Name"]);
            this.EmailId = Convert.ToString(dr["EmailId"]);
            this.Designation = Convert.ToString(dr["Designation"]);
            this.Venue = Convert.ToString(dr["Venue"]);
            this.CreatedBy = Convert.ToString(dr["CreatedBy"]);
            this.ModifiedBy = Convert.ToString(dr["ModifiedBy"]);

            this.IsDeleted = Convert.ToBoolean(dr["ModifiedBy"]);
            this.CreatedDate = Convert.ToString(dr["CreatedDate"]);
            this.ModifiedDate = Convert.ToString(dr["ModifiedDate"]);
            this.CFileName = Convert.ToString(dr["CFileName"]);
            this.ProjectSiteName = Convert.ToString(dr["ProjectSiteName"]);

        }
    }
}
