﻿using System;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;


namespace AdoSql
{
    public class Analyze
    {
        public void analyzer()
        {
            try
            {
                string sqlquery;              
                SqlCommand sqlcomm;
                SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConn"].ConnectionString);
                myConn.Open();
                SqlDataReader rdr;
                int ch;
                bool f = true;

                while(f)
                {
                    Console.WriteLine("Choose the cases:\nCase 1 \nCase 2 \nCase 3 \nCase 4 \ndefault->exit");
                    ch = Convert.ToInt32(Console.ReadLine());
                    switch (ch)
                    {
                        case 1:
                            //testcase 1
                            Console.WriteLine("****************************************************First TestCase****************************************************");
                            string C1 = "", C2 = "", C3 = "", C4 = "", C5 = "";

                            sqlquery = " SELECT COUNT(CASE WHEN AUTHORIZED_CAP <= 100000 THEN 1 END) AS COUNT_1,"
                                    + " COUNT(CASE WHEN AUTHORIZED_CAP > 100000 AND AUTHORIZED_CAP <= 1000000 THEN 1 END) AS COUNT_2,"
                                    + " COUNT(CASE WHEN AUTHORIZED_CAP > 1000000 AND AUTHORIZED_CAP <= 10000000 THEN 1 END) AS COUNT_3,"
                                    + " COUNT(CASE WHEN AUTHORIZED_CAP > 10000000 AND AUTHORIZED_CAP <= 100000000 THEN 1 END) AS COUNT_4,"
                                    + " COUNT(CASE WHEN AUTHORIZED_CAP > 100000000 THEN 1 END) AS COUNT_5"
                                    + " FROM Maharashtra.dbo.CompanyMasters; ";
                            sqlcomm = new SqlCommand(sqlquery, myConn);
                            rdr = sqlcomm.ExecuteReader();

                            while (rdr.Read())
                            {
                                C1 = rdr["COUNT_1"].ToString();
                                C2 = rdr["COUNT_2"].ToString();
                                C3 = rdr["COUNT_3"].ToString();
                                C4 = rdr["COUNT_4"].ToString();
                                C5 = rdr["COUNT_5"].ToString();
                            }                                           
                            
                            var table = new ConsoleTable("Bin", "Counts");
                            table.AddRow("<= 1L", C1)
                                .AddRow("1L to 10L", C2)
                                .AddRow("10L to 1Cr", C3)
                                .AddRow("1Cr to 10Cr", C4)
                                .AddRow(">10Cr", C5);
                            table.Write();

                            Console.WriteLine();
                            rdr.Close();
                            f = true;
                            break;

                        case 2:
                            //testcase 2
                            Console.WriteLine("****************************************************Second TestCase****************************************************");

                            var table2 = new ConsoleTable("year", "No of Registrations");

                            sqlquery = "SELECT YEAR, COUNT(YEAR) 'COUNT' FROM Maharashtra.dbo.CompanyMasters"
                                + " WHERE YEAR >= 2000 AND YEAR <= 2019 GROUP BY YEAR ORDER BY YEAR;";
                            sqlcomm = new SqlCommand(sqlquery, myConn);
                            rdr = sqlcomm.ExecuteReader();
                           
                            while (rdr.Read())
                            {
                                string YEAR = rdr["YEAR"].ToString();
                                string COUNT = rdr["COUNT"].ToString();
                                table2.AddRow(YEAR, COUNT);
                            }
                            table2.Write();

                            Console.WriteLine();                     
                            rdr.Close();
                            f = true;
                            break;

                        case 3:
                            //testcase 3
                            Console.WriteLine("****************************************************Third TestCase****************************************************");

                            var table3 = new ConsoleTable("PRINCIPAL_BUSINESS_ACTIVITY_AS_PER_CIN(2015)", "counts");

                            sqlquery = "SELECT PRINCIPAL_BUSINESS_ACTIVITY_AS_PER_CIN,"
                                + " COUNT(PRINCIPAL_BUSINESS_ACTIVITY_AS_PER_CIN) 'COUNT' FROM Maharashtra.dbo.CompanyMasters"
                                + " WHERE YEAR = 2015 GROUP BY PRINCIPAL_BUSINESS_ACTIVITY_AS_PER_CIN;";
                            sqlcomm = new SqlCommand(sqlquery, myConn);
                            rdr = sqlcomm.ExecuteReader();

                            while (rdr.Read())
                            {
                                string business = rdr["PRINCIPAL_BUSINESS_ACTIVITY_AS_PER_CIN"].ToString();
                                string count = rdr["COUNT"].ToString();
                                table3.AddRow(business, count);
                            }
                            table3.Write();

                            Console.WriteLine();                           
                            rdr.Close();
                            f = true;
                            break;

                        case 4:
                            //testcase 4
                            Console.WriteLine("****************************************************Fourth TestCase****************************************************");
                            sqlquery = "SELECT YEAR, PRINCIPAL_BUSINESS_ACTIVITY_AS_PER_CIN, "
                                   + "COUNT(PRINCIPAL_BUSINESS_ACTIVITY_AS_PER_CIN) 'COUNT' "
                                   + "FROM Maharashtra.dbo.CompanyMasters WHERE YEAR >= 2000 AND YEAR <= 2019  "
                                   + "GROUP BY PRINCIPAL_BUSINESS_ACTIVITY_AS_PER_CIN , YEAR ORDER BY YEAR;";
                            sqlcomm = new SqlCommand(sqlquery, myConn);
                            rdr = sqlcomm.ExecuteReader();

                            var DOR = new Dictionary<string, Dictionary<string, string>>();
                            for (int i = 2000; i <= 2019; i++)
                            {
                                DOR.Add(i.ToString(), new Dictionary<string, string>());
                            }

                            while (rdr.Read())
                            {
                                string YEAR = rdr["YEAR"].ToString();
                                int y = Convert.ToInt32(YEAR);
                                if (y >= 2000 && y <= 2019)
                                {
                                    if (DOR.ContainsKey(YEAR))
                                    {
                                        string business = rdr["PRINCIPAL_BUSINESS_ACTIVITY_AS_PER_CIN"].ToString();
                                        string count = rdr["COUNT"].ToString();
                                        if (DOR[y.ToString()].ContainsKey(business))
                                            DOR[y.ToString()][business] = count;
                                        else
                                            DOR[y.ToString()].Add(business, count);
                                    }
                                }
                            }

                            var table4 = new ConsoleTable("PRINCIPAL BUISNESS ACTIVITY", "Count");
                            foreach (var key1 in DOR.Keys)
                            {
                                var value1 = DOR[key1];
                                table4.AddRow(key1, "");
                                foreach (var key2 in value1.Keys)
                                {
                                    table4.AddRow(key2, value1[key2]);
                                }
                            }
                            table4.Write();

                            Console.WriteLine();                           
                            rdr.Close();
                            f = true;
                            break;

                        default:
                            f = false;
                            break;
                    }
                }
                Console.WriteLine("you exited");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    }
}
