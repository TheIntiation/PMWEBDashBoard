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
    public class WorkflowKPI
    {
        //tableID DocumentId  RecordId RecordTypeId    RecordType ObjectId   ObjectTypeId EntityId    Entity DocumentDescription StatustID CurrentPendingStepId    StepNumber NumberOfSteps   DueDateOfCurrentPendingStep ActionId
        //  1	374	34	70	Correspondence	308	1	301	Workflow Project		2	2430	1	3	2017-07-11 06:18:04.420	2081

        public static DataTransferModel getActiveWorkflowDocuments(string projectId)
        {
            DataTransferModel returnValue = new DataTransferModel();
            IList<ActiveWorkflowDocumentsByProject> myList = new List<ActiveWorkflowDocumentsByProject>();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Configurations.ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    // Command Settings
                    sqlCommand.CommandText = StoredProceduresNames.GetActiveWorkflowdocuments;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;

                    // Open Connection
                    sqlConnection.Open();

                    sqlCommand.Parameters.AddWithValue("@Project", projectId);

                    //Execute Command
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        myList.Add(new ActiveWorkflowDocumentsByProject()
                        {
                            tableID = (long)reader["tableID"],
                            DocumentId = (long)reader["DocumentId"],
                            RecordId = (long)reader["RecordId"],
                            RecordTypeId = (long)reader["RecordTypeId"],
                            RecordType = reader.GetDataReaderString("RecordType"),
                            ObjectId = (long)reader["ObjectId"],
                            EntityId = (long)reader["EntityId"],
                            Entity = reader.GetDataReaderString("Entity"),
                            DocumentDescription = reader.GetDataReaderString("DocumentDescription"),
                            StatustID = (long)reader["StatustID"],
                            CurrentPendingStepId = (long)reader["CurrentPendingStepId"],
                            StepNumber = (long)reader["StepNumber"],
                            NumberOfSteps = (long)reader["NumberOfSteps"],
                            DueDateOfCurrentPendingStep =  reader.GetDataReaderDateTime("DueDateOfCurrentPendingStep"),
                            ActionId = (long)reader["ActionId"]
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

        public static DataTransferModel getDelayedWorkflowDocuments(string projectId)
        {
            DataTransferModel returnValue = new DataTransferModel();
            IList<DelayedWorkflowDocumentsByProject> myList = new List<DelayedWorkflowDocumentsByProject>();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Configurations.ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    // Command Settings
                    sqlCommand.CommandText = StoredProceduresNames.GetDelayedWorkflowdocuments;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;

                    // Open Connection
                    sqlConnection.Open();

                    sqlCommand.Parameters.AddWithValue("@Project", projectId);

                    //Execute Command
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        myList.Add(new DelayedWorkflowDocumentsByProject()
                        {
                            tableID = (long)reader["tableID"],
                            DocumentId = (long)reader["DocumentId"],
                            RecordId = (long)reader["RecordId"],
                            RecordTypeId = (long)reader["RecordTypeId"],
                            RecordType = reader.GetDataReaderString("RecordType"),
                            ObjectId = (long)reader["ObjectId"],
                            EntityId = (long)reader["EntityId"],
                            Entity = reader.GetDataReaderString("Entity"),
                            DocumentDescription = reader.GetDataReaderString("DocumentDescription"),
                            StatustID = (long)reader["StatustID"],
                            CurrentPendingStepId = (long)reader["CurrentPendingStepId"],
                            StepNumber = (long)reader["StepNumber"],
                            NumberOfSteps = (long)reader["NumberOfSteps"],
                            DueDateOfCurrentPendingStep = reader.GetDataReaderDateTime("DueDateOfCurrentPendingStep"),
                            ActionId = (long)reader["ActionId"]
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

        public static DataTransferModel gettestcharts()
        {
            DataTransferModel returnValue = new DataTransferModel();
            IList<ChartDetail> myList = new List<ChartDetail>();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Configurations.ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    // Command Settings
                    sqlCommand.CommandText = StoredProceduresNames.gettestcharts;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;

                    // Open Connection
                    sqlConnection.Open();

                    

                    //Execute Command
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        myList.Add(new ChartDetail()
                        {
                            RecordName = reader.GetDataReaderString("RecordName"),
                            CountVal = long.Parse( reader["CountVal"].ToString())
                       
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

        public static DataTransferModel getActiveDocumentsChart(string projectId)
        {
            DataTransferModel returnValue = new DataTransferModel();
            IList<ActiveDocumentPerProjectChart> myList = new List<ActiveDocumentPerProjectChart>();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Configurations.ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    // Command Settings
                    sqlCommand.CommandText = StoredProceduresNames.getActiveDocumentsChart;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;

                    // Open Connection
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("@Project", projectId);

                    //Execute Command
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        myList.Add(new ActiveDocumentPerProjectChart()
                        {
                            RecordName = reader.GetDataReaderString("RecordName"),
                            CountVal = long.Parse(reader["CountVal"].ToString())

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

        public static DataTransferModel getDelayedDocumentsChart(string projectId)
        {
            DataTransferModel returnValue = new DataTransferModel();
            IList<DelayedDocumentPerProjectChart> myList = new List<DelayedDocumentPerProjectChart>();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Configurations.ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    // Command Settings
                    sqlCommand.CommandText = StoredProceduresNames.getDelayedDocumentsChart;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;

                    // Open Connection
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("@Project", projectId);

                    //Execute Command
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        myList.Add(new DelayedDocumentPerProjectChart()
                        {
                            RecordName = reader.GetDataReaderString("RecordName"),
                            CountVal = long.Parse(reader["CountVal"].ToString())

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

        public static DataTransferModel getDocManagerRFI(string projectId)
        {
            DataTransferModel returnValue = new DataTransferModel();
            IList<DocManagerRFIs> myList = new List<DocManagerRFIs>();

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
                    sqlCommand.Parameters.AddWithValue("@Project", projectId);

                    //Execute Command
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        myList.Add(new DocManagerRFIs()
                        {
                            StatusName = reader.GetDataReaderString("StatusName"),
                            CountVal = long.Parse(reader["CountVal"].ToString())

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

        public static DataTransferModel getDocManagerCOs(string projectId)
        {
            DataTransferModel returnValue = new DataTransferModel();
            IList<DocManagerCOs> myList = new List<DocManagerCOs>();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Configurations.ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    // Command Settings
                    sqlCommand.CommandText = StoredProceduresNames.getDocManager_COChart;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;

                    // Open Connection
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("@Project", projectId);

                    //Execute Command
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        myList.Add(new DocManagerCOs()
                        {
                            StatusName = reader.GetDataReaderString("StatusName"),
                            CountVal = long.Parse(reader["CountVal"].ToString())

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

        public static DataTransferModel getStageGatesSnap(string projectId)
        {
            DataTransferModel returnValue = new DataTransferModel();
            IList<StageGatesSnap> myList = new List<StageGatesSnap>();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Configurations.ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    // Command Settings
                    sqlCommand.CommandText = StoredProceduresNames.getStageGatesSnap;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;

                    // Open Connection
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("@Project", projectId);

                    //Execute Command
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        myList.Add(new StageGatesSnap()
                        {
                            GateId = long.Parse(reader["GateId"].ToString()),
                            GateDescrption = reader.GetDataReaderString("GateDescrption"),
                            CountActivitiesDone = long.Parse(reader["CountActivitiesDone"].ToString()),
                            TotalActivities = long.Parse(reader["TotalActivities"].ToString()),
                            Percentage = float.Parse(reader["Percentage"].ToString())


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

        public static DataTransferModel getCostSnap(string projectId)
        {
            DataTransferModel returnValue = new DataTransferModel();
            IList<CostSnap> myList = new List<CostSnap>();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Configurations.ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    // Command Settings
                    sqlCommand.CommandText = StoredProceduresNames.getCostSnap;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;

                    // Open Connection
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("@Project", projectId);

                    //Execute Command
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        myList.Add(new CostSnap()
                        {
                            id = long.Parse(reader["id"].ToString()),
                            ProjectName = reader.GetDataReaderString("ProjectName"),
                            ProjectNumber = reader.GetDataReaderString("ProjectNumber"),
                            CommitmentCode = reader.GetDataReaderString("CommitmentCode"),
                            Description = reader.GetDataReaderString("Description"),
                            CurrencyId = long.Parse(reader["CurrencyId"].ToString()),
                            CurrencyCode = reader.GetDataReaderString("CurrencyCode"),
                            OriginalCommitment = float.Parse(reader["OriginalCommitment"].ToString()),
                            Invoiced = float.Parse(reader["Invoiced"].ToString()),
                            ApprovedChanges = float.Parse(reader["ApprovedChanges"].ToString()),
                            RevisedContrcatSum = float.Parse(reader["RevisedContrcatSum"].ToString()),
                            InvoicedPercentage = float.Parse(reader["InvoicedPercentage"].ToString()),
                            CommitmentType = reader.GetDataReaderString("CurrencyCode")
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
