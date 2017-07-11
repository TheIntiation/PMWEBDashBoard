using DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class WorkFlow
    {
      
      public static DataTransferModel GetPendingWorkFlowByUserID(string UserID)
      {
          DataTransferModel returnValue = new DataTransferModel();
          IList<Workflow_GetInboxByUser> myList = new List<Workflow_GetInboxByUser>();

          try
          {
              using (SqlConnection sqlConnection = new SqlConnection(Configurations.ConnectionString))
              {
                  SqlCommand sqlCommand = new SqlCommand();
                  // Command Settings
                  sqlCommand.CommandText = StoredProceduresNames.Pending_WorkFlow_ByUserID;
                  sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                  sqlCommand.Connection = sqlConnection;

                  // Open Connection
                  sqlConnection.Open();

                  sqlCommand.Parameters.AddWithValue("@User", UserID);

                  //Execute Command
                  SqlDataReader reader = sqlCommand.ExecuteReader();
                  while (reader.Read())
                    {
                        myList.Add(new Workflow_GetInboxByUser()
                        {
                            DocumentId = (long)reader["DocumentId"],
                            ObjectTypeId = (long)reader["ObjectTypeId"],
                            RecordId = (long)reader["RecordId"],
                            RecordTypeId = (long)reader["RecordTypeId"],
                            RecordType = reader.GetDataReaderString("RecordType"),
                            EntityId = (long)reader["EntityId"],
                            Project = reader.GetDataReaderString("Project"),
                            PropertyName = reader.GetDataReaderString("PropertyName"),
                            Entity = reader.GetDataReaderString("Entity"),
                            Description = reader.GetDataReaderString("Description"),
                            StatusId = (long)reader["StatusId"],
                            StepNumber = (long)reader["StepNumber"],
                            NumberOfSteps = (long)reader["NumberOfSteps"],
                            MainPage = reader.GetDataReaderString("MainPage"),
                            ModuleId = (long)reader["ModuleId"],
                            PageId = (long)reader["PageId"],
                            CurrentStepNumber = (long)reader["CurrentStepNumber"],
                            DueDate = reader["DueDate"] == DBNull.Value ? (DateTime?)null : (DateTime?)reader["DueDate"],
                            correspondencedetails = reader.GetDataReaderString("correspondencedetails"),
                            ProjectNumber = reader.GetDataReaderString("ProjectNumber"),
                            RecordNumber = reader.GetDataReaderString("RecordNumber"),
                            DocumentDate = reader["DocumentDate"] == DBNull.Value ? (DateTime?)null : (DateTime?)reader["DocumentDate"],
                            FromContact = reader.GetDataReaderString("FromContact"),
                            ToContact = reader.GetDataReaderString("ToContact"),
                            FromCompany = reader.GetDataReaderString("FromCompany"),
                            ToCompany = reader.GetDataReaderString("ToCompany"),
                           
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

      public static DataTransferModel GetDocumentsInDelay(string Project)
      {
          DataTransferModel returnValue = new DataTransferModel();
          IList<GetDocumentsInDelay> myList = new List<GetDocumentsInDelay>();

          try
          {
              using (SqlConnection sqlConnection = new SqlConnection(Configurations.ConnectionString))
              {
                  SqlCommand sqlCommand = new SqlCommand();
                  // Command Settings
                  sqlCommand.CommandText = StoredProceduresNames.GetDocumentsInDelay;
                  sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                  sqlCommand.Connection = sqlConnection;

                  // Open Connection
                  sqlConnection.Open();

                  sqlCommand.Parameters.AddWithValue("@Project", Project);

                  //Execute Command
                  SqlDataReader reader = sqlCommand.ExecuteReader();
                  while (reader.Read())
                  {
                      myList.Add(new GetDocumentsInDelay()
                      {
                          totaldelay = (int)reader["totaldelay"],
                          RecordType = reader.GetDataReaderString("RecordType"),
                          Entity = reader.GetDataReaderString("Entity"),
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

      public static DataTransferModel GetPendingDocuments(string Project)
      {
          DataTransferModel returnValue = new DataTransferModel();
          IList<GetDocumentsInDelay> myList = new List<GetDocumentsInDelay>();

          try
          {
              using (SqlConnection sqlConnection = new SqlConnection(Configurations.ConnectionString))
              {
                  SqlCommand sqlCommand = new SqlCommand();
                  // Command Settings
                  sqlCommand.CommandText = StoredProceduresNames.GetPendingDocuments;
                  sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                  sqlCommand.Connection = sqlConnection;

                  // Open Connection
                  sqlConnection.Open();

                  sqlCommand.Parameters.AddWithValue("@Project", Project);

                  //Execute Command
                  SqlDataReader reader = sqlCommand.ExecuteReader();
                  while (reader.Read())
                  {
                      myList.Add(new GetDocumentsInDelay()
                      {
                          totaldelay = (int)reader["totaldelay"],
                          RecordType = reader.GetDataReaderString("RecordType"),
                          Entity = reader.GetDataReaderString("Entity"),
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
      public static DataTransferModel GetWorkflowMenu(string UserId)
        {
            DataTransferModel returnValue = new DataTransferModel();
            IList<WorkflowMenu> myList = new List<WorkflowMenu>();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Configurations.ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    // Command Settings
                    sqlCommand.CommandText = StoredProceduresNames.GetWorkflowMenu;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;

                    // Open Connection
                    sqlConnection.Open();

                    sqlCommand.Parameters.AddWithValue("@User", UserId);

                    //Execute Command
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        myList.Add(new WorkflowMenu()
                        {
                            RecordTypeId = (Int64)reader["RecordTypeId"],
                           RecordType = reader.GetDataReaderString("RecordType"),
                            TotalPendingItems = (int)reader["TotalPendingItems"],
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
      //  @User AS NVARCHAR(50),@RecTypeID bigint
      public static DataTransferModel getWorkflowDetailByModule(string UserId,int RecTypeId)
      {
            DataTransferModel returnValue = new DataTransferModel();
            IList<WorkflowDetailsByModule> myList = new List<WorkflowDetailsByModule>();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Configurations.ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    // Command Settings
                    sqlCommand.CommandText = StoredProceduresNames.GetWorkflowDetailByModule;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;

                    // Open Connection
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("@User", UserId);
                    sqlCommand.Parameters.AddWithValue("@RecTypeID", RecTypeId);

                    //Execute Command
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        myList.Add(new WorkflowDetailsByModule()
                        {
                            RowID = (long)reader["RowID"],
                            DocumentId = (long)reader["DocumentId"],
                            ObjectTypeId = (long)reader["ObjectTypeId"],
                            RecordId = (long)reader["RecordId"],
                            RecordTypeId = (long)reader["RecordTypeId"],
                            RecordType = reader.GetDataReaderString("RecordType"),
                            EntityId = (long)reader["EntityId"],
                            Project = reader.GetDataReaderString("Project"),
                            PropertyName = reader.GetDataReaderString("PropertyName"),
                            Entity = reader.GetDataReaderString("Entity"),
                            Description = reader.GetDataReaderString("Description"),
                            StatusId = (long)reader["StatusId"],

                            StepNumber = (long)reader["StepNumber"],
                            NumberOfSteps = (long)reader["NumberOfSteps"],
                            MainPage = reader.GetDataReaderString("MainPage"),
                            CurrentStepNumber = (long)reader["CurrentStepNumber"],
                            DueDate=reader.GetDataReaderDateTime("DueDate"),
                            RecordNumber = reader.GetDataReaderString("RecordNumber"),
                            projectId = (long)reader["projectId"]
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
        public static DataTransferModel finalApproveForWorkflow(
 
            Int64 User, Int64 DocId,Int64 EntId, Int64 RecId, Int64 RecTypeId,Int64 ObjTypeId,
            Int64 ProjectId,string Comment)
        {
            DataTransferModel returnValue = new DataTransferModel();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Configurations.ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    // Command Settings
                    sqlCommand.CommandText = StoredProceduresNames.finalApproveForWorkflow;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;

                    // Open Connection
                    sqlConnection.Open();

                    // Command Parameters
                    sqlCommand.Parameters.AddWithValue("@User", User);
                    sqlCommand.Parameters.AddWithValue("@DocId", DocId);
                    sqlCommand.Parameters.AddWithValue("@EntId", EntId);
                    sqlCommand.Parameters.AddWithValue("@RecId", RecId);
                    sqlCommand.Parameters.AddWithValue("@RecTypeId", RecTypeId);
                    sqlCommand.Parameters.AddWithValue("@ObjTypeId", ObjTypeId);
                    sqlCommand.Parameters.AddWithValue("@ProjectId", ProjectId);
                    sqlCommand.Parameters.AddWithValue("@Comment", Comment);
                    //Execute Command
                    int returnVal = sqlCommand.ExecuteNonQuery();
                    if (returnVal>0)
                    {
                        returnValue.IsSucess = true;
                        returnValue.Message = "Record was successfully approved";
                        returnValue.DataValue = null;

                    }
                    else
                    {
                        returnValue.IsSucess = false;
                        returnValue.Message = "An error happened while approving the document";
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
