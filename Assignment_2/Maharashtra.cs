using System;
using System.IO;
using System.Globalization;
using CsvHelper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoSql
{
    public class Maharashtra
    {
        int year;
        string yr = "";
        public string CORPORATE_IDENTIFICATION_NUMBER { get; set;  }
        public string Company_Name { get; set; }
        public string DATE_OF_REGISTRATION { get; set; }
        public float AUTHORIZED_CAP { get; set; }
        public string PRINCIPAL_BUSINESS_ACTIVITY_AS_PER_CIN { get; set; }

        
        public int getyr(string dateString)
        {           
            if (dateString == "NA")
                yr = "null";
            else
            {
                yr = dateString.Substring(6);
                if (yr.Length == 2)
                {
                    int ch = Convert.ToInt32(yr);
                    if (ch >= 00 && ch <= 21)
                        yr = "20" + yr;
                    else
                        yr = "19" + yr;
                    year = Convert.ToInt32(yr);
                }
                else
                {
                    DateTime dt = Convert.ToDateTime(dateString);
                    year = dt.Year;
                }
            }                          
            return year;
        }
    }
}
