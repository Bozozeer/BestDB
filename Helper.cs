using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestDB
{

    public class Helper
    {
        public static string getConnectionString()
        {
          
            string connectionString= null;
            string line;
            StreamReader sr = new StreamReader("C:\\Users\\User\\Desktop\\Юсупов\\BestDB\\connectionString.txt");
            // C:\\Users\\User\\Desktop\\Юсупов\\BestDB\\connectionString.txt
            // "C:\\Users\\yusup\\Desktop\\BestDB\\connectionString.txt"
            //DataWayChanger
            // Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\yusup\\Desktop\\BestDB\\test.accdb
            line = sr.ReadLine();
            while (line != null)
            {
                connectionString = line;
                line = sr.ReadLine();
            }
            sr.Close();
            return connectionString;
        }
        public static DbConnection GetConnection()
        {
            return new OleDbConnection(getConnectionString());
        }

        public static void printMain()
        {
            using (DbConnection conn = GetConnection())
            {
                conn.Open();

                DbCommand command = conn.CreateCommand();
                // (1) we're not interested in any data
                command.CommandText = "select * from account where 1 = 0";
                command.CommandType = CommandType.Text;

                DbDataReader reader = command.ExecuteReader();
                // (2) get the schema of the result set
                DataTable schemaTable = reader.GetSchemaTable();

                conn.Close();
                PrintSchemaPlain(schemaTable);

                Console.WriteLine(new string('-', 80));


                Console.Read();
            }


        }

        
        public static string getRole()
        {

            string Role = null;
            string line;
            StreamReader sr = new StreamReader("С:\\Users\\User\\Desktop\\Юсупов\\BestDB\\connectionRoleString.txt");
            line = sr.ReadLine();
            while (line != null)
            {
                Role = line;
                line = sr.ReadLine();
            }
            sr.Close();
            return Role;
        }

        
            private static void PrintSchemaPlain(DataTable schemaTable)
        {
            Console.WriteLine(schemaTable.Columns);
            foreach (DataRow row in schemaTable.Rows)
            {
                Console.WriteLine("{0}, {1}, {2}",
                    row.Field<string>("ColumnName"),
                    row.Field<Type>("DataType"),
                    row.Field<int>("ColumnSize"));
            }
        }

    }
}
