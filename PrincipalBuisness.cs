using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using CsvHelper;
using System.Globalization;
using ConsoleTables;

namespace CompanyMas
{
    class PrincipalBuisness
    {
       /* static void Main(string[] args)
        {
            string yr = "";
            int year, c = 0;
            string path = @"C:\Users\Acer\Downloads\Maharashtra.csv";
            var reader = new StreamReader(path);
            var rows = new CsvReader(reader, CultureInfo.InvariantCulture);

            Dictionary<string, int> DOR = new Dictionary<string, int>();
            foreach (var row in rows.GetRecords<Maharashtra>())
            {
                string dateString = row.DATE_OF_REGISTRATION;
                if (dateString != "NA")
                {
                    yr = dateString.Substring(6);
                    c++;
                    if (yr.Length == 2)
                    {
                        int ch = Convert.ToInt32(yr);
                        if (ch == 15)
                            yr = "20" + yr;
                        year = Convert.ToInt32(yr);
                    }
                    else
                    {
                        DateTime dt = Convert.ToDateTime(dateString);
                        year = dt.Year;
                    }
                    //Console.WriteLine(year);
                    if (year == 2015)
                    {
                        string activity = row.PRINCIPAL_BUSINESS_ACTIVITY_AS_PER_CIN;
                        if (DOR.ContainsKey(activity))
                            DOR[activity]++;
                        else
                            DOR.Add(activity, 1);
                    }
                }
            }
            var table = new ConsoleTable("PRINCIPAL BUISNESS ACTIVITY(2015)", "Count");
            foreach(KeyValuePair<String,int> kvp in DOR)
            {
                table.AddRow(kvp.Key, kvp.Value);
            }
            table.Write();
            Console.WriteLine();
        }*/
    }
}
