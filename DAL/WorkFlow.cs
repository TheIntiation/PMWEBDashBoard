using DataModel;
using GoogleMaps.LocationServices;
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

        public static DataTransferModel GetPortifolioSummryDashbaord(int programid)
        {
            DataTransferModel returnValue = new DataTransferModel();
            IList<PortifolioSummryOne> myList1 = new List<PortifolioSummryOne>();
            IList<PortifolioSummryTwo> myList2 = new List<PortifolioSummryTwo>();
            IList<GoogleMapAddress> myList3 = new List<GoogleMapAddress>();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Configurations.ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    // Command Settings
                    sqlCommand.CommandText = StoredProceduresNames.uspmc_portifolio_summry_dashbaord_level_two;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;

                    // Open Connection
                    sqlConnection.Open();

                    sqlCommand.Parameters.AddWithValue("@programid ", programid);

                    //Execute Command
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (programid == 0)
                    {
                        while (reader.Read())
                        {
                            myList2.Add(new PortifolioSummryTwo()
                            {

                                WorkUnderContract = (decimal)reader["WorkUnderContract"],
                                WorkinProgress = (decimal)reader["WorkinProgress"],
                                UnstartedContracts = (decimal)reader["UnstartedContracts"],
                                ContractChanges = (decimal)reader["ContractChanges"],
                                ProjectedCost = (decimal)reader["ProjectedCost"],
                               
                            });
                        }
                        returnValue.IsSucess = true;
                        returnValue.Message = "Sucess";
                        returnValue.DataValue = myList2;
                    }
                    else if (programid == -1)
                    {
                        var locationService = new GoogleLocationService();
                        

                        while (reader.Read())
                        {
                            myList3.Add(new GoogleMapAddress()
                            {

                                projectid = (long)reader["projectid"],
                                GoogleAddress = reader.GetDataReaderString("GoogleAddress"),
                                latitude = Getlatitude(reader.GetDataReaderString("GoogleAddress")),
                                longitude = Getlongitude(reader.GetDataReaderString("GoogleAddress")),
                                
                            });
                        }
                        returnValue.IsSucess = true;
                        returnValue.Message = "Sucess";
                        returnValue.DataValue = myList3;
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            myList1.Add(new PortifolioSummryOne()
                            {
                                
                                ProjectId = (long)reader["ProjectId"],
                                ProjCurrency = (long)reader["ProjCurrency"],
                                GoogleAddress = reader.GetDataReaderString("GoogleAddress"),
                                ProjectName = reader.GetDataReaderString("ProjectName"),
                                ProjectNumber = reader.GetDataReaderString("ProjectNumber"),
                                ProjectManager = reader.GetDataReaderString("ProjectManager"),
                                ProjectExecutive = reader.GetDataReaderString("ProjectExecutive"),
                                Superintendent = reader.GetDataReaderString("Superintendent"),
                                ProjectType = reader.GetDataReaderString("ProjectType"),
                                Program = reader.GetDataReaderString("Program"),
                                ProgramName = reader.GetDataReaderString("ProgramName"),
                                Property = reader.GetDataReaderString("Property"),
                                Country = reader.GetDataReaderString("Country"),
                                City = reader.GetDataReaderString("City"),
                                StateKey = reader.GetDataReaderString("StateKey"),
                                StatusKey = reader.GetDataReaderString("StatusKey"),
                                Status = reader.GetDataReaderString("Status"),
                                OriginalBudget = (decimal)reader["OriginalBudget"],
                                BudgetChanges = (decimal)reader["BudgetChanges"],
                                AnticipatedBudget = (decimal)reader["AnticipatedBudget"],
                                OriginalCommitments = (decimal)reader["OriginalCommitments"],
                                CommitmentsRevisions = (decimal)reader["CommitmentsRevisions"],
                                AnticipatedCost = (decimal)reader["AnticipatedCost"],
                                Forecasts = (decimal)reader["Forecasts"],
                                ForecastsVariance = (decimal)reader["ForecastsVariance"],
                                ActualCosts = (decimal)reader["ActualCosts"],
                                CostPctComplete = (decimal)reader["CostPctComplete"],
                                PhysicalPctComplete = (decimal)reader["PhysicalPctComplete"],
                                StartDate = reader.GetDataReaderDateTime("StartDate"),
                                FinishDate = reader.GetDataReaderDateTime("FinishDate"),
                                Duration = reader.GetDataReaderNullablelonfg("Duration"),
                                BaselineStartDate = reader.GetDataReaderDateTime("BaselineStartDate"),
                                BaselineFinishDate = reader.GetDataReaderDateTime("BaselineFinishDate"),
                                Days = reader.GetDataReaderNullablelonfg("Days"),
                            });
                        }
                        returnValue.IsSucess = true;
                        returnValue.Message = "Sucess";
                        returnValue.DataValue = myList1;
                    }
                    
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

        private static double Getlatitude(string v)
        {
            var locationService = new GoogleLocationService();
            var point = locationService.GetLatLongFromAddress(v);

            double latitude = point.Latitude;
            return latitude;
        }

        private static double Getlongitude(string v)
        {
            var locationService = new GoogleLocationService();
            var point = locationService.GetLatLongFromAddress(v);

            double longitude = point.Longitude;
            return longitude;
        }

        public static DataTransferModel GetProgramsList(int UserId)
        {
            DataTransferModel returnValue = new DataTransferModel();
            IList<ProgramsList> myList = new List<ProgramsList>();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Configurations.ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    // Command Settings
                    sqlCommand.CommandText = StoredProceduresNames.GetProgramsList;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;

                    // Open Connection
                    sqlConnection.Open();

                    sqlCommand.Parameters.AddWithValue("@UserId ", UserId);

                    //Execute Command
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        myList.Add(new ProgramsList()
                        {
                            Id = (long)reader["Id"],
                            Name = reader.GetDataReaderString("Name"),
                            
                           
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

        public static DataTransferModel GetDocumentPunchList(int projectid)
        {
            DataTransferModel returnValue = new DataTransferModel();
            IList<DocumentPunchList> myList = new List<DocumentPunchList>();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Configurations.ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    // Command Settings
                    sqlCommand.CommandText = StoredProceduresNames.uspmc_rpt_GetPunchLists;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;

                    // Open Connection
                    sqlConnection.Open();

                    sqlCommand.Parameters.AddWithValue("@projectid", projectid);

                    //Execute Command
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        myList.Add(new DocumentPunchList()
                        {
                            Company = reader.GetDataReaderString("Company"),
                            DocStatus = reader.GetDataReaderString("DocStatus"),
                            Total = (long)reader["Total"],

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


        public static DataTransferModel GetALLUserProjects(long UserId)
        {
            DataTransferModel returnValue = new DataTransferModel();
            IList<ProjectList> myList = new List<ProjectList>();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Configurations.ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    // Command Settings
                    sqlCommand.CommandText = StoredProceduresNames.GetALLUserProjects;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;

                    // Open Connection
                    sqlConnection.Open();

                    sqlCommand.Parameters.AddWithValue("@UserId", UserId);

                    //Execute Command
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        myList.Add(new ProjectList()
                        {
                            Id = (long)reader["Id"],
                            ProjectName = reader.GetDataReaderString("ProjectName"),
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
