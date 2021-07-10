using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using CsvHelper;
using System.Globalization;
using ConsoleTables;

namespace CompanyMas
{
    class RegistrationYear
    {
       /* static void Main(string[] args)
        {
            string yr = "";
            int year, c = 0;
            string path = @"C:\Users\Acer\Downloads\Maharashtra.csv";
            var reader = new StreamReader(path);
            var rows = new CsvReader(reader, CultureInfo.InvariantCulture);

            Dictionary<string, int> DOR = new Dictionary<string, int>();
            for(int i = 1870; i <= 2021; i++)
            {
                DOR[i.ToString()] = 0;
            }
            foreach (var row in rows.GetRecords<Maharashtra>())
            {
                string dateString = row.DATE_OF_REGISTRATION;
                if (dateString != "NA")
                {
                    yr = dateString.Substring(6);
                    c++;
                    if(yr.Length == 2)
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
                    //Console.WriteLine(year);
                    if (year >= 1870 && year <= 2021)
                    {
                        DOR[year.ToString()]++;
                    }
                }
            }
            var table = new ConsoleTable("Year", "No of Registrations");
            for(int i = 1870; i <= 2021; i++)
            {
                table.AddRow(i, DOR[i.ToString()]);
            }
            table.Write();
            Console.WriteLine();
        }*/
    }
}
