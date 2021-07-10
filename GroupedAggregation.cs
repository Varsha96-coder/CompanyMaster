using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using CsvHelper;
using System.Globalization;
using ConsoleTables;
using System.Linq;

namespace CompanyMas
{
    class GroupedAggregation
    {
        static void Main(string[] args)
        {
            string yr = "";
            int year, c = 0;
            string path = @"C:\Users\Acer\Downloads\Maharashtra.csv";
            var reader = new StreamReader(path);
            var rows = new CsvReader(reader, CultureInfo.InvariantCulture);
          
            var DOR = new Dictionary<string, Dictionary<string, int>>();
            for(int i = 2000; i <= 2019; i++)
            {
                DOR.Add(i.ToString(), new Dictionary<string, int>());
            }   
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
                            if (ch >= 00 && ch <= 19)
                                yr = "20" + yr;
                            year = Convert.ToInt32(yr);
                        }
                        else
                        {
                            DateTime dt = Convert.ToDateTime(dateString);
                            year = dt.Year;
                        }
                    //Console.WriteLine(year);
                        if (year >= 2000 && year <= 2019)
                        {
                            if (DOR.ContainsKey(year.ToString()))
                            { 
                                string activity = row.PRINCIPAL_BUSINESS_ACTIVITY_AS_PER_CIN;
                                if (DOR[year.ToString()].ContainsKey(activity))
                                    DOR[year.ToString()][activity]++;
                                else
                                    DOR[year.ToString()].Add(activity,1);
                            }                         
                        }
                    }
                }
            
            var table = new ConsoleTable("PRINCIPAL BUISNESS ACTIVITY(2015)", "Count");
                foreach (var key1 in DOR.Keys)
                {
                    var value1 = DOR[key1];
                    table.AddRow(key1, "");
                    foreach (var key2 in value1.Keys)
                    {
                        table.AddRow(key2, value1[key2]);
                    }
                }     
            table.Write();
            Console.WriteLine();
        }
    }
}
