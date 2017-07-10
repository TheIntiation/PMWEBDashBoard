using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class DatabaseHelper
    {
       

        public static byte[] ReadAllBytes(string fileName)
        {
            byte[] buffer = null;
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                buffer = new byte[fs.Length];
                fs.Read(buffer, 0, (int)fs.Length);
            }
            return buffer;
        } 

        public static string Getextension(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) return string.Empty;
            string ext = string.Empty;
            Boolean hita = false;
            int i = fileName.Length - 1;
            char[] arr = fileName.ToCharArray();
            while (i > 0 & !hita)
            {
                if (arr[i] == '.') hita = true;
                else ext = arr[i] + ext;
                i = i - 1;
            }
            return ext;
        }

        public static string GeneralDeleteString = "DELETE FROM {0} WHERE ID = {1}";
        public static void DeleteLookupRecord(string tableName, int ID)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Configurations.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                // Command Settings
                sqlCommand.CommandText = string.Format(GeneralDeleteString, tableName, ID);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlCommand.Connection = sqlConnection;

                // Open Connection
                sqlConnection.Open();

                //Execute Command
                int noOfAffectedRows = sqlCommand.ExecuteNonQuery();
            }
        }


        public static object GetStringOrDBNull(this string obj)
        {
            return string.IsNullOrWhiteSpace(obj) ? DBNull.Value : (object)obj;
        }

        public static object GetObjectOrDBNull(this string obj)
        {
            return string.IsNullOrWhiteSpace(obj) ? DBNull.Value : (object)obj;
        }

        public static object GetObjectOrDBNull(this int? myObject)
        {
            return myObject.HasValue ? (object)myObject.Value : (object)DBNull.Value;
        }

        public static object GetObjectOrDBNull(this DateTime? myObject)
        {
            return myObject.HasValue ? (object)myObject.Value : (object)DBNull.Value;
        }

        public static object GetObjectOrDBNull(this decimal? myObject)
        {
            return myObject.HasValue ? (object)myObject.Value : (object)DBNull.Value;
        }
        public static string GetDataReaderString(this SqlDataReader reader , string ColumnName )
        {
            return reader[ColumnName] == DBNull.Value ? null : (string)reader[ColumnName]; 
        }

        public static int? GetDataReaderNullableInt(this SqlDataReader reader, string ColumnName)
        {
            return reader[ColumnName] == DBNull.Value ? (int?)null : (int?)reader[ColumnName];
        }

        public static decimal? GetDataReaderNullableDecimal(this SqlDataReader reader, string ColumnName)
        {
            return reader[ColumnName] == DBNull.Value ? (decimal?)null : (decimal?)reader[ColumnName];
        }

        public static DateTime? GetDataReaderDateTime(this SqlDataReader reader, string ColumnName)
        {
            return reader[ColumnName] == DBNull.Value ? (DateTime?)null : DateTime.Parse(reader[ColumnName].ToString());
        }

        public static string Join<T>(string separator, IEnumerable<T> values) {
            return string.Join(separator, values);
        }
      
    }


    public class SqlHelpers
    {
        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }


    }
}
