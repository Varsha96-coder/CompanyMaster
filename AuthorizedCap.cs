using System;
using System.IO;
using System.Collections.Generic;
using CsvHelper;
using System.Globalization;
using ConsoleTables;
namespace CompanyMas
{
    class AuthorizedCap
    {
        static void Main(string[] args)
        {

            int c1 = 0,c2 = 0,c3 = 0,c4 = 0,c5 = 0;
            string path = @"C:\Users\Acer\Downloads\Maharashtra.csv";
            var reader = new StreamReader(path);
            var rows = new CsvReader(reader, CultureInfo.InvariantCulture);
            foreach (var row in rows.GetRecords<Maharashtra>())
            {
                double val = Convert.ToDouble(row.AUTHORIZED_CAP);
                if (val <= 100000)
                    c1++;
                else if (val > 100000 && val <= 1000000)
                    c2++;
                else if (val > 1000000 && val <= 10000000)
                    c3++;
                else if (val > 10000000 && val <= 100000000)
                    c4++;
                else if (val > 100000000)
                    c5++; 
            }

            var table = new ConsoleTable("Bin", "Counts");
            table.AddRow("<= 1L", c1).AddRow("1L to 10L", c2).AddRow("10L to 1Cr", c3).AddRow("1Cr to 10Cr", c4).AddRow(">10Cr", c5);
            table.Write();
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
