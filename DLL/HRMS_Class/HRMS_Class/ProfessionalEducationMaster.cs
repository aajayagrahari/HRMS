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
  public  class ProfessionalEducationMaster
    {
    
          long _EduId;
          string _Qualification;
          string _Univercity;
          string _PassingYear;
          string _Grade;
          long _RRId;
          string _EType;


          public long EduId
          {
              get
              {
                  return _EduId;
              }
              set
              {
                  _EduId = value;
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
          public string Qualification
          {
              get
              {
                  return _Qualification;
              }
              set
              {
                  _Qualification = value;
              }
          }
          public string Univercity
          {
              get
              {
                  return _Univercity;
              }
              set
              {
                  _Univercity = value;
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

          public string Grade
          {
              get
              {
                  return _Grade;
              }
              set
              {
                  _Grade = value;
              }

          }

          public string EType
          {
              get
              {
                  return _EType;
              }
              set
              {
                  _EType = value;
              }

          }
      }
    }

