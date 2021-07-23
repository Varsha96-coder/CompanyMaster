using System;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace AdoSql
{
    public class Load
    {
        public void loader()
        {
            string sqlquery;
            int year = 0;        
            SqlCommand sqlcomm;
            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConn"].ConnectionString);
            myConn.Open();
            try
            {
                string csv_file_path = @"C:\Users\Acer\Downloads\Maharashtra.csv";
                var reader = new StreamReader(csv_file_path);
                var rows = new CsvReader(reader, CultureInfo.InvariantCulture);
                sqlquery = "SELECT * FROM master.dbo.sysdatabases where name = 'Maharashtra'";
                sqlcomm = new SqlCommand(sqlquery, myConn);
                var exists = sqlcomm.ExecuteReader();

                if (exists.Read())
                {
                    Console.WriteLine("Database exist");
                    exists.Close();

                    sqlquery = "SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CompanyMaster';";
                    sqlcomm = new SqlCommand(sqlquery, myConn);
                    exists = sqlcomm.ExecuteReader();
                    
                    //Console.WriteLine(exists.Read());
                   
                    if (exists.Read())
                    {
                        Console.WriteLine("Table exist");
                        exists.Close();
                    }
                    else
                    {
                        Console.WriteLine("Table does not exist");
                        exists.Close();

                        sqlquery = "USE Maharashtra "
                        + "CREATE TABLE CompanyMasters("
                        + " CORPORATE_IDENTIFICATION_NUMBER varchar(40) not null, "
                        + " Company_Name varchar(150),"
                        + " YEAR int,"
                        + " AUTHORIZED_CAP float,"
                        + " PRINCIPAL_BUSINESS_ACTIVITY_AS_PER_CIN varchar(150),"
                        + " Primary Key(CORPORATE_IDENTIFICATION_NUMBER))";
                        sqlcomm = new SqlCommand(sqlquery, myConn);
                        sqlcomm.ExecuteNonQuery();

                        Console.WriteLine("Table created");
                    }
                }
                else
                {
                    exists.Close();
                    Console.WriteLine("Database not exist");

                    sqlquery = "CREATE DATABASE Maharashtra";
                    sqlcomm = new SqlCommand(sqlquery, myConn);
                    sqlcomm.ExecuteNonQuery();

                    Console.WriteLine("Database created");

                    sqlquery = "USE Maharashtra "
                        + "CREATE TABLE CompanyMasters("
                        + " CORPORATE_IDENTIFICATION_NUMBER varchar(40) not null, "
                        + " Company_Name varchar(150),"
                        + " YEAR int,"
                        + " AUTHORIZED_CAP float,"
                        + " PRINCIPAL_BUSINESS_ACTIVITY_AS_PER_CIN varchar(150),"
                        + " Primary Key(CORPORATE_IDENTIFICATION_NUMBER))";
                    sqlcomm = new SqlCommand(sqlquery, myConn);
                    sqlcomm.ExecuteNonQuery();

                    Console.WriteLine("Table created");
                }

                foreach (var row in rows.GetRecords<Maharashtra>())
                {
                    string dateString = row.DATE_OF_REGISTRATION;
                    year = row.getyr(dateString);

                    sqlquery = "INSERT INTO Maharashtra.dbo.CompanyMasters (CORPORATE_IDENTIFICATION_NUMBER, Company_Name, YEAR, AUTHORIZED_CAP, PRINCIPAL_BUSINESS_ACTIVITY_AS_PER_CIN) " +
                                    "VALUES (@CORPORATE_IDENTIFICATION_NUMBER, @Company_Name, @YEAR, @AUTHORIZED_CAP, @PRINCIPAL_BUSINESS_ACTIVITY_AS_PER_CIN) ";
                    using (sqlcomm = new SqlCommand(sqlquery, myConn))
                    {
                        sqlcomm.Parameters.Add("@CORPORATE_IDENTIFICATION_NUMBER", SqlDbType.VarChar, 40).Value = row.CORPORATE_IDENTIFICATION_NUMBER;
                        sqlcomm.Parameters.Add("@Company_Name", SqlDbType.VarChar, 150).Value = row.Company_Name;
                        sqlcomm.Parameters.Add("@YEAR", SqlDbType.Int).Value = year;
                        sqlcomm.Parameters.Add("@AUTHORIZED_CAP", SqlDbType.Float).Value = row.AUTHORIZED_CAP;
                        sqlcomm.Parameters.Add("@PRINCIPAL_BUSINESS_ACTIVITY_AS_PER_CIN", SqlDbType.VarChar).Value = row.PRINCIPAL_BUSINESS_ACTIVITY_AS_PER_CIN;
                        sqlcomm.ExecuteNonQuery();
                        Console.WriteLine("values inserted");
                    }
                }
                myConn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    }
}
