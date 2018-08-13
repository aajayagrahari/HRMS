using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HRMS_Class
{
    public class PostDetailMaster
    {
        private string _PostIdDetailId;
        private string _PostId;
        //private string _CategoryId;
        //private string _FeeAmount;
        //private Int32 _Vacancy;
        private bool _IsDeleted;
        private string _CreatedDate;
        private string _CreatedBy;
        private string _ModifiedDate;
        private string _ModifiedBy;

        private bool _IsGenral ;
        private bool _IsST;
        private bool _IsSC ;
        private bool _IsOBC;
        private bool _IsPH;
        private Int32 _GenralSeat ;
        private Int32 _STSeat;
        private Int32 _SCSeat ;
        private Int32 _OBCSeat ;
        private Int32 _PHSeat ;
        private string _GenralAmt;
        private string _STAmt;
        private string _SCAmt ;
        private string _OBCAmt;
        private string _PHAmt;




        public string PostIdDetailId
        {
            get
            {
                return _PostIdDetailId;
            }
            set
            {
                _PostIdDetailId = value;
            }
        }
        public string PostId
        {
            get
            {
                return _PostId;
            }
            set
            {
                _PostId = value;
            }
        }
        //public string CategoryId
        //{
        //    get
        //    {
        //        return _CategoryId;
        //    }
        //    set
        //    {
        //        _CategoryId = value;
        //    }
        //}
        //public string FeeAmount
        //{
        //    get
        //    {
        //        return _FeeAmount;
        //    }
        //    set
        //    {
        //        _FeeAmount = value;
        //    }
        //}
        //public Int32 Vacancy
        //{
        //    get
        //    {
        //        return _Vacancy;
        //    }
        //    set
        //    {
        //        _Vacancy = value;
        //    }
        //}
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

        public bool IsGenral
        {
            get
            {
                return _IsGenral;
            }
            set
            {
                _IsGenral = value;
            }
        }
        public bool IsST
        {
            get
            {
                return _IsST;
            }
            set
            {
                _IsST = value;
            }
        }
        public bool IsSC
        {
            get
            {
                return _IsSC;
            }
            set
            {
                _IsSC = value;
            }
        }
        public bool IsOBC
        {
            get
            {
                return _IsOBC;
            }
            set
            {
                _IsOBC = value;
            }
        }
        public bool IsPH
        {
            get
            {
                return _IsPH;
            }
            set
            {
                _IsPH = value;
            }
        }

        public Int32 GenralSeat
        {
            get
            {
                return _GenralSeat;
            }
            set
            {
                _GenralSeat = value;
            }
        }
        public Int32 STSeat
        {
            get
            {
                return _STSeat;
            }
            set
            {
                _STSeat = value;
            }
        }
        public Int32 SCSeat
        {
            get
            {
                return _SCSeat;
            }
            set
            {
                _SCSeat = value;
            }
        }
        public Int32 OBCSeat
        {
            get
            {
                return _OBCSeat;
            }
            set
            {
                _OBCSeat = value;
            }
        }
        public Int32 PHSeat
        {
            get
            {
                return _PHSeat;
            }
            set
            {
                _PHSeat = value;
            }
        }

        public string GenralAmt
        {
            get
            {
                return _GenralAmt;
            }
            set
            {
                _GenralAmt = value;
            }
        }
        public string STAmt
        {
            get
            {
                return _STAmt;
            }
            set
            {
                _STAmt = value;
            }
        }
        public string SCAmt
        {
            get
            {
                return _SCAmt;
            }
            set
            {
                _SCAmt = value;
            }
        }
        public string OBCAmt
        {
            get
            {
                return _OBCAmt;
            }
            set
            {
                _OBCAmt = value;
            }
        }
        public string PHAmt
        {
            get
            {
                return _PHAmt;
            }
            set
            {
                _PHAmt = value;
            }
        }





        public void SetObjectInfo(DataRow dr)
        {

            this.PostIdDetailId = Convert.ToString(dr["PostIdDetailId"]);
            this.PostId = Convert.ToString(dr["PostId"]);
            //this.CategoryId = Convert.ToString(dr["CategoryId"]);
            //this.FeeAmount = Convert.ToString(dr["FeeAmount"]);
           // this.Vacancy = Convert.ToInt32(dr["Vacancy"]);

            this.IsDeleted = Convert.ToBoolean(dr["IsDeleted"]);
            this.CreatedDate = Convert.ToString(dr["CreatedDate"]);
            this.CreatedBy = Convert.ToString(dr["CreatedBy"]);
            this.ModifiedDate = Convert.ToString(dr["ModifiedDate"]);
            this.ModifiedBy = Convert.ToString(dr["ModifiedBy"]);

            this.IsGenral = Convert.ToBoolean(dr["IsGenral"]);
            this.IsOBC = Convert.ToBoolean(dr["IsOBC"]);
            this.IsSC = Convert.ToBoolean(dr["IsSC"]);
            this.IsST = Convert.ToBoolean(dr["IsST"]);
            this.IsPH = Convert.ToBoolean(dr["IsPH"]);

            this.GenralSeat = Convert.ToInt32(dr["GenralSeat"]);
            this.SCSeat = Convert.ToInt32(dr["SCSeat"]);
            this.STSeat = Convert.ToInt32(dr["STSeat"]);
            this.OBCSeat = Convert.ToInt32(dr["OBCSeat"]);
            this.PHSeat = Convert.ToInt32(dr["PHSeat"]);

            this.GenralAmt = Convert.ToString(dr["GenralAmt"]);
            this.SCAmt = Convert.ToString(dr["SCAmt"]);
            this.STAmt = Convert.ToString(dr["STAmt"]);
            this.OBCAmt = Convert.ToString(dr["OBCAmt"]);
            this.PHAmt = Convert.ToString(dr["PHAmt"]);
           
        }
    }
}
