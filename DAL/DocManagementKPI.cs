using DataModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  public  class DocManagementKPI
    {
        public static DataTransferModel getDocManagementRFIs(long projectId)
        {
            DataTransferModel returnValue = new DataTransferModel();
            IList<DocManagementRFIs> myList = new List<DocManagementRFIs>();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Configurations.ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    // Command Settings
                    sqlCommand.CommandText = StoredProceduresNames.getDocManagementRFIs;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;

                    // Open Connection
                    sqlConnection.Open();

                    sqlCommand.Parameters.AddWithValue("@ProjectId", projectId);

                    //Execute Command
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        myList.Add(new DocManagementRFIs()
                        {
                            ProjID = (long)reader["ProjID"],
                            ProjectName = (string)reader["ProjectName"],
                            ProjectNumber = (string)reader["ProjectNumber"],
                            DocNumber = (string)reader["DocNumber"],
                            DocumentDate = reader.GetDataReaderDateTime("DocumentDate"),
                            DocStatusId = long.Parse( reader["DocStatusId"].ToString()),

                            DocStatusName = (string)reader["DocStatusName"],
                            RequiredDate = reader.GetDataReaderDateTime("RequiredDate"),
                            AnsweredDate = reader.GetDataReaderDateTime("AnsweredDate")                         
                        });
                    }
                    returnValue.IsSucess = true;
                    returnValue.Message = "Sucess";
                    returnValue.DataValue = myList;
                }
            }
            catch (SqlException sqlEx)
            {
                returnValue.IsSucess = false;
                returnValue.Message = sqlEx.ToString();
                returnValue.DataValue = null;

            }

            return returnValue;

        }
    }
}
