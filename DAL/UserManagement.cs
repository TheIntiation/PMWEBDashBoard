using DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class UserManagement
    {
        public static string GetHashValue(string Value)
        {
            string str;
            try
            {
                byte[] bytes = new UnicodeEncoding().GetBytes(Value);
                SHA1CryptoServiceProvider provider = new SHA1CryptoServiceProvider();
                str = Convert.ToBase64String(provider.ComputeHash(bytes));
            }
            catch (Exception exception1)
            {

                Exception exception = exception1;
                throw exception;
            }
            return str;
        }

        public static DataTransferModel LoginUserValidation(string UserName, string Password)
        {
            DataTransferModel returnValue = new DataTransferModel();
            UserAccount myObject = null;
            string encryptedPassword = GetHashValue(Password);
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Configurations.ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    // Command Settings
                    sqlCommand.CommandText = StoredProceduresNames.UserManagement_LoginUserValidation;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;

                    // Open Connection
                    sqlConnection.Open();

                    // Command Parameters
                    sqlCommand.Parameters.AddWithValue("@UserName", UserName);
                    sqlCommand.Parameters.AddWithValue("@Password", encryptedPassword);

                    //Execute Command
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        myObject = new UserAccount();
                        myObject.UserID = (long)reader["Id"];
                        myObject.UserName = reader["Username"] as string;
                        myObject.UserFullName = reader["FirstName"] as string;

                        returnValue.IsSucess = true;
                        returnValue.Message = "Sucess";
                        returnValue.DataValue = myObject;

                    }
                    else
                    {
                        returnValue.IsSucess = false;
                        returnValue.Message = "UserName Or Password Is Wrong";
                        returnValue.DataValue = null;
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                returnValue.IsSucess = false;
                returnValue.Message = sqlEx.Message.ToString();
                returnValue.DataValue = null;
            }

            return returnValue;
        }

    }
}
