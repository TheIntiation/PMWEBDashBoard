using DataModel;
using GoogleMaps.LocationServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL
{
    public class WorkFlow
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
        public static DataTransferModel getScheduleSnap(string projectId)
        {
            DataTransferModel returnValue = new DataTransferModel();
            IList<ScheduleSnap> myList = new List<ScheduleSnap>();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Configurations.ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    // Command Settings
                    sqlCommand.CommandText = StoredProceduresNames.getScheduleSnap;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;

                    // Open Connection
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("@Project", projectId);

                    //Execute Command
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        myList.Add(new ScheduleSnap()
                        {

                            Start = (DateTime)reader.GetDataReaderDateTime("Start"),
                            Finish = (DateTime)reader.GetDataReaderDateTime("Finish"),
                            StatusDate = (DateTime)reader.GetDataReaderDateTime("StatusDate"),
                            DurationPast = long.Parse(reader["DurationPast"].ToString()),
                            PastPercentage = float.Parse(reader["PastPercentage"].ToString()),
                            DurationRemaining = long.Parse(reader["DurationRemaining"].ToString()),
                            RemainingPercentage = float.Parse(reader["RemainingPercentage"].ToString()),

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
        public static DataTransferModel GetExeDashBoardPic(string projectId)
        {
            DataTransferModel returnValue = new DataTransferModel();
            IList<exective_dashboard_cost_pic> myList = new List<exective_dashboard_cost_pic>();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Configurations.ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    // Command Settings
                    sqlCommand.CommandText = StoredProceduresNames.uspmc_exective_dashboard_cost_pic;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;

                    // Open Connection
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("@Project", projectId);

                    //Execute Command
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        myList.Add(new exective_dashboard_cost_pic()
                        {
                            FileContent = (byte[])reader["FileContent"],
                            FileContentBase64 = Convert.ToBase64String((byte[])reader["FileContent"])
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

        public static DataTransferModel GetExeDashBoard(string projectId)
        {
            DataTransferModel returnValue = new DataTransferModel();
            IList<exective_dashboard_cost> myList = new List<exective_dashboard_cost>();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Configurations.ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    // Command Settings
                    sqlCommand.CommandText = StoredProceduresNames.uspmc_exective_dashboard_cost;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;

                    // Open Connection
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("@Project", projectId);

                    //Execute Command
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        myList.Add(new exective_dashboard_cost()
                        {
                            ActualCost = double.Parse(reader["ActualCost"].ToString()),
                            AnticipatedBudget = double.Parse(reader["AnticipatedBudget"].ToString()),
                            AnticipatedCost = double.Parse(reader["AnticipatedCost"].ToString()),
                            Forecast = double.Parse(reader["Forecast"].ToString()),
                            Variance = double.Parse(reader["Variance"].ToString()),
                            ForeCastVariance = double.Parse(reader["ForeCastVariance"].ToString()),
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


        public static DataTransferModel GetPunchListChart(long projectid)
        {
            DataTransferModel returnValue = new DataTransferModel();
            IList<PunchListChart> myList1 = new List<PunchListChart>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Configurations.ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    // Command Settings
                    sqlCommand.CommandText = StoredProceduresNames.uspmc_document_management_dashboard_punchlist_OVER;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;

                    // Open Connection
                    sqlConnection.Open();

                    sqlCommand.Parameters.AddWithValue("@projectid ", projectid);

                    //Execute Command
                    SqlDataReader reader = sqlCommand.ExecuteReader();


                    while (reader.Read())
                    {
                        myList1.Add(new PunchListChart()
                        {

                            ToCoName = reader.GetDataReaderString("ToCoName"),
                            Draft = reader.GetDataReaderNullablelonfg("Draft"),
                            Submitted = reader.GetDataReaderNullablelonfg("Submitted"),
                            Returned = reader.GetDataReaderNullablelonfg("Returned"),
                            Resubmitted = reader.GetDataReaderNullablelonfg("Resubmitted"),
                            Approved = reader.GetDataReaderNullablelonfg("Approved"),
                            Rejected = reader.GetDataReaderNullablelonfg("Rejected"),
                            Withdrawn = reader.GetDataReaderNullablelonfg("Withdrawn"),
                            TotalOutStanding = reader.GetDataReaderNullablelonfg("TotalOutStanding"),
                            TotalOverDue = reader.GetDataReaderNullablelonfg("TotalOverDue")

                        });
                    }
                    returnValue.IsSucess = true;
                    returnValue.Message = "Sucess";
                    returnValue.DataValue = myList1;


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
                                ProjectName = reader.GetDataReaderString("ProjectName"),
                                ProjectNumber = reader.GetDataReaderString("ProjectNumber"),
                                GoogleAddress = reader.GetDataReaderString("GoogleAddress"),
                                latitude = reader.GetDataReaderString("latitude"),
                                longitude = reader.GetDataReaderString("longitude"),
                                ForecastsVariance = (decimal)reader["ForecastsVariance"],
                                FinishDate = reader.GetDataReaderDateTime("FinishDate"),
                                BaselineFinishDate = reader.GetDataReaderDateTime("BaselineFinishDate"),
                                OUTSTANDING_DOCUMENT = reader.GetDataReaderNullablelonfg("OUTSTANDING_DOCUMENT"),
                                OVERDUE_DOCUMENT = reader.GetDataReaderNullablelonfg("OVERDUE_DOCUMENT"),

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
        public static IList<PortifolioSummryOne> GetProjectListForProgram(long programid)
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
                                OUTSTANDING_DOCUMENT = reader.GetDataReaderNullablelonfg("OUTSTANDING_DOCUMENT"),
                                OVERDUE_DOCUMENT = reader.GetDataReaderNullablelonfg("OVERDUE_DOCUMENT"),
                            });
                        }
                        returnValue.IsSucess = true;
                        returnValue.Message = "Sucess";
                        returnValue.DataValue = myList1;
                     

                }
            }
            catch (SqlException sqlEx)
            {
                returnValue.IsSucess = false;
                returnValue.Message = sqlEx.ToString();
                returnValue.DataValue = null;

            }

            return myList1;

        }

        private static double Getlatitude(string v)
        {
            try
            {
                return Getlat(v);
            }
            catch (Exception ex)
            {
                int milliseconds = 2000;
                Thread.Sleep(milliseconds);
                return Getlat(v);
            }
        }

        private static double Getlongitude(string v)
        {
            try
            {
                return Getlong(v);
            }
            catch (Exception ex)
            {
                int milliseconds = 2000;
                Thread.Sleep(milliseconds);
                return Getlong(v);
            }
        }

        private static double Getlat(string v)
        {
            var locationService = new GoogleLocationService();
            double latitude = 0;
            var point = locationService.GetLatLongFromAddress(v);
            latitude = point.Latitude;
                     
            return latitude;
        }

        private static double Getlong(string v)
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
                            ProjectList= GetProjectListForProgram((long)reader["Id"]),


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
        public static DataTransferModel GetPendingWorkFlowByUserID(string UserID, long RecordTypeIdWeb)
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
                    sqlCommand.Parameters.AddWithValue("@RecordTypeIdWeb", RecordTypeIdWeb);

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
                            projectId = (long)reader["projectId"],
                            VisualWorkFlow = GetDocumentStepsRoles(reader["DocumentId"].ToString(), reader["CurrentStepNumber"].ToString()),
                            WorkFlowAttachments = GetWorkflowAttachments(reader["RecordTypeId"].ToString(),reader["RecordId"].ToString(), UserId.ToString()),
                            TotalAttachments= GetTotalAttachement(reader["RecordTypeId"].ToString(), reader["RecordId"].ToString(), UserId.ToString()),
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
        public static long GetTotalAttachement(string RecordTypeId, string RecordId, string UserName)
        {
            DataTransferModel returnValue = new DataTransferModel();
            IList<WorkflowAttachments> myList = new List<WorkflowAttachments>();
            long TotalAttachemnt = 0;

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Configurations.ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    // Command Settings
                    sqlCommand.CommandText = StoredProceduresNames.USPM_GetDocumentAttachments;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;

                    // Open Connection
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("@RecordTypeId", RecordTypeId);
                    sqlCommand.Parameters.AddWithValue("@RecordId", RecordId);
                    sqlCommand.Parameters.AddWithValue("@UserName", @UserName);

                    //Execute Command
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        TotalAttachemnt = TotalAttachemnt + 1;
                      
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

            return TotalAttachemnt;
        }
        public static IList<WorkflowAttachments> GetWorkflowAttachments(string RecordTypeId, string RecordId, string UserName)
        {
            DataTransferModel returnValue = new DataTransferModel();
            IList<WorkflowAttachments> myList = new List<WorkflowAttachments>();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Configurations.ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    // Command Settings
                    sqlCommand.CommandText = StoredProceduresNames.USPM_GetDocumentAttachments;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;

                    // Open Connection
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("@RecordTypeId", RecordTypeId);
                    sqlCommand.Parameters.AddWithValue("@RecordId", RecordId);
                    sqlCommand.Parameters.AddWithValue("@UserName", @UserName);

                    //Execute Command
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    int counter = 0;
                    while (reader.Read())
                    {
                        myList.Add(new WorkflowAttachments()
                        {
                            Id = long.Parse(reader["Id"].ToString()),
                            FileId = long.Parse(reader["FileId"].ToString()),
                            URL = reader["URL"].ToString(),
                            FileOption = reader["FileOption"].ToString(),
                            FullFileName = "http://localhost:6607/Download?FullFileName=" + reader["FullFileName"].ToString(),
                            FileGUID = reader["FileGUID"].ToString(),
                            Description = reader["Description"].ToString(),
                            Extention = reader["Extention"].ToString(),
                            RecordTypeId = RecordTypeId.ToString(),
                            RecordId = RecordId.ToString(),
                            UserName = UserName.ToString(),
                            //FileContent = (byte[])reader["FileContent"],
                            //FileContentBase64 = Convert.ToBase64String((byte[])reader["FileContent"])
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

            return myList;

        }

        public static string GetWorkflowAttachmentById(string RecordTypeId, string RecordId, string UserName, string Id)
        {
            DataTransferModel returnValue = new DataTransferModel();
            IList<WorkflowAttachments> myList = new List<WorkflowAttachments>();
            byte[] Attachment = null;
            string FileContentBase64 = null;

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Configurations.ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    // Command Settings
                    sqlCommand.CommandText = StoredProceduresNames.USPM_GetDocumentAttachmentsByID;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;

                    // Open Connection
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("@RecordTypeId", RecordTypeId);
                    sqlCommand.Parameters.AddWithValue("@RecordId", RecordId);
                    sqlCommand.Parameters.AddWithValue("@UserName", @UserName);
                    sqlCommand.Parameters.AddWithValue("@Id", @Id);

                    //Execute Command
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        Attachment = (byte[])reader["FileContent"];
                        FileContentBase64 = Convert.ToBase64String((byte[])reader["FileContent"]);
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

            return FileContentBase64;

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




        public static DataTransferModel GetDocumentActionLogs(string DocumentId)
        {
            DataTransferModel returnValue = new DataTransferModel();
            IList<DocumentActionLogs> myList = new List<DocumentActionLogs>();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Configurations.ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    // Command Settings
                    sqlCommand.CommandText = StoredProceduresNames.Workflow_GetDocumentActionLogs;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;

                    // Open Connection
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("@DocumentId", DocumentId);

                    //Execute Command
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        myList.Add(new DocumentActionLogs()
                        {

                            ActionId = long.Parse(reader["ActionId"].ToString()),
                            StepId = long.Parse(reader["StepId"].ToString()),
                            ParentId = long.Parse(reader["ParentId"].ToString()),
                            StepNumber = long.Parse(reader["StepNumber"].ToString()),
                            StepSort = long.Parse(reader["StepSort"].ToString()),
                            StepRoleId = long.Parse(reader["StepRoleId"].ToString()),
                            RoleId = long.Parse(reader["RoleId"].ToString()),
                            SpecialRoleId = long.Parse(reader["SpecialRoleId"].ToString()),
                            RoleName = reader["SpecialRoleId"].ToString(),
                            ActionTypeId = long.Parse(reader["ActionTypeId"].ToString()),
                            ActionBy = long.Parse(reader["ActionBy"].ToString()),
                            FullName = reader["FullName"].ToString(),
                            ActionDate = reader.GetDataReaderDateTime("ActionDate"),
                            ActionDueDate = reader.GetDataReaderDateTime("ActionDueDate"),
                            Comments = reader["Comments"].ToString(),
                            DocValue = reader["DocValue"].ToString(),
                            IsBranch = reader["IsBranch"].ToString(),
                            BranchActionTypeId = long.Parse(reader["BranchActionTypeId"].ToString()),
                            BranchName = reader["BranchName"].ToString(),
                            SignatureFileName = reader["SignatureFileName"].ToString(),
                            SignatureExtension = reader["SignatureExtension"].ToString(),
                            SignatureFileGuid = Guid.Parse(reader["SignatureFileGuid"].ToString()),
                            thumbnailGuid = Guid.Parse(reader["thumbnailGuid"].ToString()),
                            FullFileName = reader["FullFileName"].ToString(),
                            ActionType = reader["ActionType"].ToString(),
                            DelegateName = reader["DelegateName"].ToString(),
                            TeamInputNames = reader["TeamInputNames"].ToString(),
                            DeliveredToStepId = long.Parse(reader["DeliveredToStepId"].ToString()),
                            HasEmail = reader["HasEmail"].ToString(),
                            Generated = reader["Generated"].ToString(),
                            Instructions = reader["Instructions"].ToString(),

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

        public static IList<DocumentStepsRoles> GetDocumentStepsRoles(string DocumentId,string CurrentStepNumber)
        {
            DataTransferModel returnValue = new DataTransferModel();
            IList<DocumentStepsRoles> myList = new List<DocumentStepsRoles>();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Configurations.ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    // Command Settings
                    sqlCommand.CommandText = StoredProceduresNames.uspmc_Workflow_GetDocumentStepsRoles;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;

                    // Open Connection
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("@DocumentId", DocumentId);

                    //Execute Command
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    int counter = 0;
                    while (reader.Read())
                    {
                        myList.Add(new DocumentStepsRoles()
                        {

                            Id = double.Parse(reader["Id"].ToString()),
                            DocumentStepId = long.Parse(reader["DocumentStepId"].ToString()),
                            RoleId = long.Parse(reader["RoleId"].ToString()),
                            SavedUserId = long.Parse(reader["SavedUserId"].ToString()),
                            RoleName = reader["RoleName"].ToString(),
                            SpecialRoleId = long.Parse(reader["SpecialRoleId"].ToString()),
                            FullName = reader["FullName"].ToString(),
                            Delegates = reader["Delegates"].ToString(),
                            TeamInput = reader["TeamInput"].ToString(),
                            SpecialRoleUserId = long.Parse(reader["SpecialRoleUserId"].ToString()),
                            SpecialRoleUserName = reader["SpecialRoleUserName"].ToString(),
                            CurrentStepNumber = long.Parse(CurrentStepNumber),
                            IsCurrentStep= GetIsCurrentStep(myList.Count, long.Parse(CurrentStepNumber)),
                            TotalItems= 4,
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

            return myList;

        }

        public static bool GetIsCurrentStep(long index,long currentset)
        {
            if (index == currentset)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public static DataTransferModel GetCurrentStep(string DocumentId)
        {
            DataTransferModel returnValue = new DataTransferModel();
            IList<CurrentStep> myList = new List<CurrentStep>();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Configurations.ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    // Command Settings
                    sqlCommand.CommandText = StoredProceduresNames.Workflow_CalculateCurrentPendingStepId;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;

                    // Open Connection
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("@DocumentId", DocumentId);

                    //Execute Command
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        myList.Add(new CurrentStep()
                        {

                            StepId = double.Parse(reader["StepId"].ToString()),
                           
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

        public static DataTransferModel InsertHelpDesk(HelpDTO HelpDTO)
        {
            DataTransferModel returnValue = new DataTransferModel();
            IList<CurrentStep> myList = new List<CurrentStep>();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Configurations.ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    // Command Settings
                    sqlCommand.CommandText = StoredProceduresNames.uspmc_Insert_HelpDesk;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;

                    // Open Connection
                    sqlConnection.Open();

                    sqlCommand.Parameters.AddWithValue("@UserID", HelpDTO.UserID);
                    sqlCommand.Parameters.AddWithValue("@Module", HelpDTO.Module);
                    sqlCommand.Parameters.AddWithValue("@TypeOfIssue", HelpDTO.TypeOfIssue);
                    sqlCommand.Parameters.AddWithValue("@Subject", HelpDTO.Subject);
                    sqlCommand.Parameters.AddWithValue("@Description", HelpDTO.Description);

                    //Execute Command
                    int result = sqlCommand.ExecuteNonQuery();

                    if (result >= 0 || result==-1)
                    {
                        returnValue.IsSucess = true;
                        returnValue.Message = "Sucess";
                        returnValue.DataValue = null;
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



        public static DataTransferModel approveForWorkflow(

    Int64 User, Int64 DocId, Int64 EntId, Int64 RecId, Int64 RecTypeId, Int64 ObjTypeId,
    Int64 ProjectId, string Comment)
        {
            DataTransferModel returnValue = new DataTransferModel();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Configurations.ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    // Command Settings
                    sqlCommand.CommandText = StoredProceduresNames.approveForWorkflow;
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
                    if (returnVal > 0)
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


        public static DataTransferModel returnForWorkflow(

   Int64 User, Int64 DocId, Int64 EntId, Int64 RecId, Int64 RecTypeId, Int64 ObjTypeId,
   Int64 ProjectId, string Comment)
        {
            DataTransferModel returnValue = new DataTransferModel();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Configurations.ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    // Command Settings
                    sqlCommand.CommandText = StoredProceduresNames.returnForWorkflow;
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
                    if (returnVal > 0)
                    {
                        returnValue.IsSucess = true;
                        returnValue.Message = "Record was successfully returned";
                        returnValue.DataValue = null;

                    }
                    else
                    {
                        returnValue.IsSucess = false;
                        returnValue.Message = "An error happened while returning the document";
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


  public static DataTransferModel rejectForWorkflow(

   Int64 User, Int64 DocId, Int64 EntId, Int64 RecId, Int64 RecTypeId, Int64 ObjTypeId,
   Int64 ProjectId, string Comment)
        {
            DataTransferModel returnValue = new DataTransferModel();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Configurations.ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    // Command Settings
                    sqlCommand.CommandText = StoredProceduresNames.rejectForWorkflow;
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
                    if (returnVal > 0)
                    {
                        returnValue.IsSucess = true;
                        returnValue.Message = "Record was successfully rejected";
                        returnValue.DataValue = null;

                    }
                    else
                    {
                        returnValue.IsSucess = false;
                        returnValue.Message = "An error happened while rejecting the document";
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
