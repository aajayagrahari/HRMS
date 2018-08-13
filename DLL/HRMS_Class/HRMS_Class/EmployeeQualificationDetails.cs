using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HRMS_Class
{
    [Serializable]
    public class EmployeeQualificationDetails
    {
        private int _EmployeeQualificationId;
        private string _EmployeeId;
        private int _ItemNo;
        private string _ClassId;
        private string _ClassName;
        private string _CollegeOrUniversityName;
        private string _Subject;
        private string _PassingYear;
        private string _Percentage;
        private string _CreatedBy;
        private string _ModifiedBy;
        private DateTime _CreatedDate;
        private DateTime _ModifiedDate;
        private int _IsDeleted;

        public int EmployeeQualificationId
        {
            get
            {
                return _EmployeeQualificationId;
            }
            set
            {
                _EmployeeQualificationId = value;
            }
        }
        
        public string EmployeeId
        {
            get
            {
                return _EmployeeId;
            }
            set
            {
                _EmployeeId = value;
            }
        }

        public int ItemNo
        {
            get
            {
                return _ItemNo;
            }
            set
            {
                _ItemNo = value;
            }
        }

        public string ClassId
        {
            get
            {
                return _ClassId;
            }
            set
            {
                _ClassId = value;
            }
        }

        public string ClassName
        {
            get
            {
                return _ClassName;
            }
            set
            {
                _ClassName = value;
            }
        }

        public string CollegeOrUniversityName
        {
            get
            {
                return _CollegeOrUniversityName;
            }
            set
            {
                _CollegeOrUniversityName = value;
            }
        }

        public string PassingYear
        {
            get
            {
                return _PassingYear;
            }
            set
            {
                _PassingYear = value;
            }
        }

        public string Subject
        {
            get
            {
                return _Subject;
            }
            set
            {
                _Subject = value;
            }
        }

        public string Percentage
        {
            get
            {
                return _Percentage;
            }
            set
            {
                _Percentage = value;
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

        public DateTime CreatedDate
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

        public DateTime ModifiedDate
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
        
        public int IsDeleted
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
        
        public void SetObjectInfo(DataRow dr)
        {
            this.EmployeeQualificationId = Convert.ToInt32(dr["EmployeeQualificationId"]);
            this.EmployeeId = Convert.ToString(dr["EmployeeId"]).Trim();
            this.ItemNo = Convert.ToInt32(dr["ItemNo"]);
            this.ClassId = Convert.ToString(dr["ClassId"]).Trim();
            this.ClassName = Convert.ToString(dr["ClassName"]).Trim();
            this.CollegeOrUniversityName = Convert.ToString(dr["CollegeOrUniversityName"]).Trim();
            this.Subject = Convert.ToString(dr["Subject"]).Trim();
            this.PassingYear = Convert.ToString(dr["PassingYear"]).Trim();
            this.Percentage = Convert.ToString(dr["Percentage"]).Trim();

            this.CreatedBy = Convert.ToString(dr["CreatedBy"]).Trim();
            this.ModifiedBy = Convert.ToString(dr["ModifiedBy"]).Trim();
            this.ModifiedDate = Convert.ToDateTime(dr["CreatedDate"]);
            this.ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"]);
            this.IsDeleted = Convert.ToInt32(dr["IsDeleted"]);
        }

    }

}
