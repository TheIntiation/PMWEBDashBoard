using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using DAL;
using System.Data;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Services.Controllers
{
    public class DownloadController : Controller
    {
        // GET: Download
        public ActionResult Index(string FullFileName)
        {
            Guid guid;

            string fullFileName = HttpContext.Request.QueryString["FullFileName"];
            string fileGUID = GetFileGUID(fullFileName);
            if (!fileGUID.Equals(string.Empty))
            {
                guid = new Guid(fileGUID);
            }
            else
            {
                guid = new Guid();
            }
            string fileNameWithoutGUIDExtension = GetFileNameWithoutGUIDExtension(fullFileName);
            string fileExtension = GetFileExtension(fullFileName);
            string str = fileNameWithoutGUIDExtension + "." + fileExtension;
            DownloadInfo argDownloadInfo = new DownloadInfo
            {
                FileName = fileNameWithoutGUIDExtension,
                FileGuid = guid,
                Extension = fileExtension,
                ConnectionString = Configurations.ConnectionString,
                HttpContext = System.Web.HttpContext.Current,
            };
            this.DownloadFile(argDownloadInfo);

            return View();
        }

        public class DownloadInfo
        {
            public string FileName { get; set; }
            public Guid FileGuid { get; set; }
            public string Extension { get; set; }
            public string ConnectionString { get; set; }
            public HttpContext HttpContext { get; set; }
        }
        public string GetContentType(string Extension)
        {
            switch (Extension.ToLower())
            {
                case "txt":
                    return "text/plain";

                case "htm":
                case "html":
                    return "text/html";

                case "rtf":
                    return "text/richtext";

                case "jpg":
                case "jpeg":
                    return "image/jpeg";

                case "gif":
                    return "image/gif";

                case "bmp":
                    return "image/bmp";

                case "png":
                    return "image/png";

                case "mpg":
                case "mpeg":
                    return "video/mpeg";

                case "avi":
                    return "video/avi";

                case "pdf":
                    return "application/pdf";

                case "doc":
                case "dot":
                    return "application/msword";

                case "csv":
                case "xls":
                case "xlt":
                case "xlsx":
                    return "application/x-msexcel";

                case "docx":
                    return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
            }
            return "application/octet-stream";
        }

        private void DownloadFile(DownloadInfo argDownloadInfo)
        {
            SqlDataReader reader;
            Stream stream;
            //int scriptTimeout = argDownloadInfo.HttpContext.Server.ScriptTimeout;
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(Configurations.ConnectionString);
            int num7 = 0;
            int detailId = 0;
            HttpResponse objResponse = argDownloadInfo.HttpContext.Response;
            int dblResponseChunkSize = 10000;
            int dblSQLChunkSize = 10000;
            // argDownloadInfo.HttpContext.Server.ScriptTimeout = 0x7fffffff;
            objResponse.ClearContent();
            objResponse.ClearHeaders();
            objResponse.AppendHeader("content-disposition", "attachment; filename=\"" + argDownloadInfo.FileName + "." + argDownloadInfo.Extension + "\"");
            objResponse.ContentType = GetContentType(argDownloadInfo.Extension);
            try
            {
                string str;
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetFileIdFromFileGUID";
                command.Parameters.AddWithValue("@FileGuid", argDownloadInfo.FileGuid);
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlDataReader reader2 = command.ExecuteReader();
                while (reader2.Read())
                {
                    detailId = int.Parse(reader2[0].ToString());
                    str = reader2[1].ToString();
                }
                command.Parameters.Clear();
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
                command.Parameters.Clear();
                //this.PM.AuditTrailController.AddToAuditTrail("Download", str, "", -1, this.PM.UserInfo.UserId, detailId, "", "");
                command.CommandText = "[dbo].[FileManager_GetFileSize]";
                command.Parameters.AddWithValue("@FileGuid", argDownloadInfo.FileGuid);
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                num7 = int.Parse(command.ExecuteScalar().ToString());
                command.Parameters.Clear();
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
                objResponse.AppendHeader("Content-Length", num7.ToString());
                command.CommandText = "[dbo].[FileManager_GetFileContent]";
                command.Parameters.AddWithValue("@FileGuid", argDownloadInfo.FileGuid);
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                reader = command.ExecuteReader(CommandBehavior.SequentialAccess);
                byte[] array = new byte[dblSQLChunkSize + 1];
                if (num7 > dblSQLChunkSize)
                {
                    Array.Resize<byte>(ref array, dblSQLChunkSize);
                }
                else
                {
                    Array.Resize<byte>(ref array, num7);
                }
                double a = 0.0;
                goto Label_02E6;
                Label_0281:
                stream = new MemoryStream(array);
                WriteStream(objResponse, stream, (double)dblResponseChunkSize);
                a += array.Length;
                num7 -= array.Length;
                if (num7 > dblSQLChunkSize)
                {
                    Array.Resize<byte>(ref array, dblSQLChunkSize);
                }
                else
                {
                    Array.Resize<byte>(ref array, num7);
                }
                Label_02C0:
                if ( (reader.GetBytes(0, (long)Math.Round(a), array, 0, array.Length) > 0L))
                {
                    goto Label_0281;
                }
                Label_02E6:
                if (reader.Read())
                {
                    goto Label_02C0;
                }
                reader.Close();
            }
            catch (Exception exception1)
            {
                //ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                //objResponse.Write("Error : " + exception.Message);
               // ProjectData.ClearProjectError();
            }
            finally
            {

                //stream.Close();
                //stream = null;
                //reader.Close();

                //if (!Information.IsNothing(stream))
                //{
                //    stream.Close();
                //    stream = null;
                //}
                //if (reader)
                //{
                //    reader.Close();
                //}
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
            //int downloadedFileId = 0;
            //int downloadedFileFolderId = 0;
            //int downloadFileVersion = 1;
            //this.GetFileInfo(argDownloadInfo, ref downloadedFileId, ref downloadedFileFolderId, ref downloadFileVersion);
            //if ((downloadedFileFolderId > 0) && (downloadedFileId > 0))
            //{
            //    string str2 = argDownloadInfo.FileName + "." + argDownloadInfo.Extension + "(" + downloadFileVersion.ToString() + ")";
            //    //this.PM.FileManager.SubscriptionController.CreateSubscriptionEvent("DocumentsDownloaded", downloadedFileFolderId);
            //}
            objResponse.Flush();
            objResponse.End();
         //   argDownloadInfo.HttpContext.Server.ScriptTimeout = scriptTimeout;
        }

        private void GetFileInfo(DownloadInfo argDownloadInfo, ref int DownloadedFileId, ref int DownloadedFileFolderId, ref int DownloadFileVersion)
        {
            SqlDataReader reader = null;
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(argDownloadInfo.ConnectionString);
            try
            {
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Guid", argDownloadInfo.FileGuid));
                command.CommandText = "[dbo].[FileManager_GetFileByGuid]";
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            DownloadedFileId = Conversions.ToInteger(reader["Id"]);
                            DownloadedFileFolderId = Conversions.ToInteger(reader["FolderId"]);
                            DownloadFileVersion = Conversions.ToInteger(reader["Version"]);
                        }
                    }
                    reader.Close();
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                throw exception;
            }
            finally
            {
                command.Parameters.Clear();
                if (reader != null)
                {
                    reader.Close();
                }
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }
        public string GetFileGUID(object FullFileName)
        {
            string[] strArray = FullFileName.ToString().Split(new char[] { '.' });
            if (string.IsNullOrEmpty(strArray[0]))
            {
                return "";
            }
            return strArray[strArray.Length - 2];
        }

        public string GetFileNameWithoutGUIDExtension(object FullFileName)
        {
            string[] source = FullFileName.ToString().Split(new char[] { '.' });
            if (string.IsNullOrEmpty(source[0]))
            {
                return "";
            }
            source.ToList<string>().RemoveAt(source.Length - 1);
            source.ToList<string>().RemoveAt(source.Length - 1);
            int index = 0;
            List<string> list = new List<string>();
            while (index < (source.Length - 2))
            {
                list.Add(source[index]);
                index++;
            }
            return string.Join(".", list.ToArray());
        }
        public string GetFileExtension(object FullFileName)
        {
            if (string.IsNullOrEmpty(Path.GetExtension(HttpUtility.UrlEncode(FullFileName.ToString()))))
            {
                return "";
            }
            return Path.GetExtension(FullFileName.ToString()).Trim(new char[] { '.' });
        }
        public void ProcessRequest(HttpContext context)
        {
            Guid guid;
           
            string fullFileName = context.Request.QueryString["FullFileName"];
            string fileGUID = GetFileGUID(fullFileName);
            if (!fileGUID.Equals(string.Empty))
            {
                guid = new Guid(fileGUID);
            }
            else
            {
                guid = new Guid();
            }
            string fileNameWithoutGUIDExtension = GetFileNameWithoutGUIDExtension(fullFileName);
            string fileExtension = GetFileExtension(fullFileName);
            string str = fileNameWithoutGUIDExtension + "." + fileExtension;
            DownloadInfo argDownloadInfo = new DownloadInfo
            {
                FileName = fileNameWithoutGUIDExtension,
                FileGuid = guid,
                Extension = fileExtension,
                ConnectionString = Configurations.ConnectionString,
               // HttpContext = context;
            };
            this.DownloadFile(argDownloadInfo);
        }

        private static void WriteStream(HttpResponse objResponse, Stream objStream, double ResponseChunkSize)
        {
            byte[] buffer = new byte[((int)Math.Round(ResponseChunkSize)) + 1];
            try
            {
                long length = objStream.Length;
                while (length > 0L)
                {
                    if (objResponse.IsClientConnected)
                    {
                        int count = objStream.Read(buffer, 0, (int)Math.Round(ResponseChunkSize));
                        objResponse.OutputStream.Write(buffer, 0, count);
                        objResponse.Flush();
                        buffer = new byte[((int)Math.Round(ResponseChunkSize)) + 1];
                        length -= count;
                    }
                    else
                    {
                        length = -1L;
                    }
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                objResponse.Write("Error : " + exception.Message);
                ProjectData.ClearProjectError();
            }
            finally
            {
                if (!Information.IsNothing(objStream))
                {
                    objStream.Close();
                }
            }
        }


    }
}