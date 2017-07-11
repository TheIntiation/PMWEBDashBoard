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
    }
}
