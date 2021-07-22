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
using ConsoleTables;


namespace AdoSql
{
    class Program
    {
        static void Main(string[] args)
        {                     
            try
            {
                string arg = args[0];              
                if (arg.Equals("load"))
                {
                    Load ob = new Load();
                    ob.loader();                  
                }
                else if (arg.Equals("analyze"))
                {
                    Analyze ob = new Analyze();
                    ob.analyzer();                  
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid Argument.");
                Console.ReadLine(); 
            }
        }
    }
}
