using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HRMS_Class
{
    public class TrainingMaster
    {
        private Int32 _TrainingId;
        private string _Traning_Subject;
        private DateTime _StarDate;
        private DateTime _EndDate;
        private Int32 _Traning_Hour;
        private Int32 _Traning_Minute;
        private string _Traning_Description;
        private DateTime _CreatedDate;
        private string _CreatedBy;
        private DateTime _ModifiedDate;
        private string _ModifiedBy;

        public Int32 TrainingId
        {
            get
            {
                return _TrainingId;
            }
            set
            {
                _TrainingId = value;
            }
        }
        public Int32 Traning_Hour
        {
            get
            {
                return _Traning_Hour;
            }
            set
            {
                _Traning_Hour = value;
            }
        }
        public Int32 Traning_Minute
        {
            get
            {
                return _Traning_Minute;
            }
            set
            {
                _Traning_Minute = value;
            }
        }
        public DateTime StarDate
        {
            get
            {
                return _StarDate;
            }
            set
            {
                _StarDate = value;
            }
        }
        public DateTime EndDate
        {
            get
            {
                return _EndDate;
            }
            set
            {
                _EndDate = value;
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
        public string Traning_Subject
        {
            get
            {
                return _Traning_Subject;
            }
            set
            {
                _Traning_Subject = value;
            }
        }
        public string Traning_Description
        {
            get
            {
                return _Traning_Description;
            }
            set
            {
                _Traning_Description = value;
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


        public void SetObjectInfo(DataRow dr)
        {
            this.TrainingId = Convert.ToInt32(dr["TrainingId"]);
            this.Traning_Hour = Convert.ToInt32(dr["Traning_Hour"]);
            this.Traning_Minute = Convert.ToInt32(dr["Traning_Minute"]);
            this.StarDate = Convert.ToDateTime(dr["StarDate"]);
            this.EndDate = Convert.ToDateTime(dr["EndDate"]);
            //this.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
           // this.ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"]);
            this.Traning_Subject = Convert.ToString(dr["Traning_Subject"]);
            this.Traning_Description = Convert.ToString(dr["Traning_Description"]);
            this.CreatedBy = Convert.ToString(dr["CreatedBy"]);
            this.ModifiedBy = Convert.ToString(dr["ModifiedBy"]);

        }
    }
}
