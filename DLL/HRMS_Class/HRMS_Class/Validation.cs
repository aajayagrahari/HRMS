using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Drawing;
using System.Web.UI.WebControls;




/// <summary>
/// Summary description for Validation
/// </summary>
public class Validation
{
	public Validation()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static bool IsValidData(TextBox _objControl, string _DataType, string _Size, bool _IsMandatory)
    {
        _objControl.BackColor = Color.White;

        if ((_DataType == "NU") && (NumericCheck(_objControl.Text, _Size, _IsMandatory))) return true;
       // else if ((_DataType == "AN") && (StringCheck(_objControl.Text, "AN", _Size, _IsMandatory))) return true;
        else if ((_DataType == "DT") && (DateCheck(_objControl.Text, '-', _Size, _IsMandatory))) return true;
       // else if ((_DataType == "PH") && (PhoneCheck(_objControl.Text, _Size, _IsMandatory))) return true;
       // else if ((_DataType == "EM") && (EmailCheck(_objControl.Text, _Size, _IsMandatory))) return true;
        else if ((_DataType == "DC") && (DecimalCheck(_objControl.Text, _Size, _IsMandatory))) return true;
        else if ((_DataType == "AD") && (StringCheck(_objControl.Text, "AD", _Size, _IsMandatory))) return true;
        else { _objControl.BackColor = Color.Yellow; return false; }
    }
    public static bool IsValidData(TextBox _objControl, string _Size, bool _IsMandatory)
    {
        if (_objControl.Text.Length == 0 && _IsMandatory == true) { _objControl.BackColor = Color.Yellow; return false; }
        else if (_objControl.Text.Length > int.Parse(_Size)) { _objControl.BackColor = Color.Yellow; return false; }
        else { _objControl.BackColor = Color.White; return true; }
    }

    public static bool StringCheck(string _str, string _Type, string _Size, bool _isBlank)
    {
        bool _flag = true;
        try
        {
            if (_str.Length == 0 && _isBlank == true) _flag = false;
            if (_str.Length > int.Parse(_Size)) _flag = false;
        }
        catch { _flag = false; }
        return _flag;
    }

    public static bool StringCheck(string _str, bool _isBlank, string _SplChr)
    {
        bool _flag = true;
        try
        {
            if (_str.Length == 0) _flag = _isBlank;
        }
        catch { _flag = false; }
        return _flag;
    }

    public static bool NumericCheck(string _str, string _Size, bool _isBlank)
    {
        bool _flag = true;
        try
        {
            if (_str.Length == 0 && _isBlank == true) _flag = false;
            if (_str.Length > int.Parse(_Size)) _flag = false;
            if (_str.Length > 0) { Int64 i = Int64.Parse(_str); }
        }
        catch { _flag = false; }
        return _flag;

    }

    public static bool DecimalCheck(string _str, string _Size, bool _isBlank)
    {
        bool _flag = true;
        try
        {
            if (_str.Length == 0 && _isBlank == true) _flag = false;
            if (_str.Length > Decimal.Parse(_Size)) _flag = false;
            if (_str.Length > 0) { Decimal i = Decimal.Parse(_str); }
        }
        catch { _flag = false; }
        return _flag;
    }

    public static bool DateCheck(string _strDate, char _separator, string _Size, bool _isBlank)
    {
        // this function should supports in future three types of fomat. 'U' is used for "dd-mm-yyyy", 
        // 'M' is used for "mm/dd/yyyy" and 'D' is used for 'yyyy-mm-dd';
        // No provision for entering just two digit of year.
        bool _flag = true;
        try
        {
            if (_strDate.Length == 0 && _isBlank == true) _flag = false;
            if (_strDate.Length > int.Parse(_Size)) _flag = false;
            if (_strDate.Length > 0)
            {
                Int16 dd, mm;
                Int32 yyyy;

                String[] _arrDate = _strDate.Split(_separator);

                if (_arrDate.Length != 3) _flag = false;

                dd = Convert.ToInt16(_arrDate[0]);
                mm = Convert.ToInt16(_arrDate[1]);
                yyyy = Convert.ToInt32(_arrDate[2]);

                if (yyyy < 1900 || yyyy > 2099) _flag = false;
                if (mm < 1 || mm > 12) _flag = false;
                if (dd < 1 || dd > Validation.MaxDayOfMonth(mm, yyyy)) _flag = false;

            }
        }
        catch { _flag = false; }
        return _flag;

    }

    public static bool DateCheck(string _strDate, char _separator, bool _isBlank)
    {
        // this function should supports in future three types of fomat. 'U' is used for "dd-mm-yyyy", 
        // 'M' is used for "mm/dd/yyyy" and 'D' is used for 'yyyy-mm-dd';
        // No provision for entering just two digit of year.
        bool _flag = true;
        try
        {
            if (_strDate.Length == 0 && _isBlank == true) _flag = false;
            if (_strDate.Length > 0)
            {
                Int16 dd, mm;
                Int32 yyyy;

                String[] _arrDate = _strDate.Split(_separator);

                if (_arrDate.Length != 3) _flag = false;

                dd = Convert.ToInt16(_arrDate[0]);
                mm = Convert.ToInt16(_arrDate[1]);
                yyyy = Convert.ToInt32(_arrDate[2]);

                if (yyyy < 1900 || yyyy > 2099) _flag = false;
                if (mm < 1 || mm > 12) _flag = false;
                if (dd < 1 || dd > Validation.MaxDayOfMonth(mm, yyyy)) _flag = false;

            }
        }
        catch { _flag = false; }
        return _flag;

    }

    public static bool PhoneCheck(string _str, string _Size, bool _isBlank)
    {
        bool _flag = true;
        try
        {
            if (_str.Length == 0 && _isBlank == true) _flag = false;
            if (_str.Length > int.Parse(_Size)) _flag = false;
            if (_str.Length > 0)
            {
                String[] _arrValue = _str.Split(';');
                for (int i = 0; i < _arrValue.Length; i++)
                    if (NumericCheck(_arrValue[i].Replace('-', '0'), _Size, _isBlank) == false) _flag = false;
            }
        }
        catch { _flag = false; }
        return _flag;
    }
    public static Int16 MaxDayOfMonth(Int16 _month, Int32 _year)
    {
        if (_month == 1 || _month == 3 || _month == 5 || _month == 7 || _month == 8 || _month == 10 || _month == 12) return 31;

        else if (_month == 2)
        {
            if ((_year % 100 == 0 && _year % 8 == 0) || (_year % 100 != 0 && _year % 4 == 0)) return 29;
            else return 28;
        }

        else return 30;
    }
}