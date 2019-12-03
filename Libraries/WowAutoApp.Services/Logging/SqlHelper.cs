using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WowAutoApp.Services.Logging
{
    public class SqlHelper
    {
        private readonly string _connectionString;

        public SqlHelper(string connectionStr)
        {
            _connectionString = connectionStr;
        }

        private void ExecuteNonQuery(string commandStr, List<SqlParameter> paramList)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();

                    using (var command = new SqlCommand(commandStr, connection))
                    {
                        command.Parameters.AddRange(paramList.ToArray());
                        command.ExecuteNonQuery();
                    }
                }
                catch
                {
                    // TODO: Consider removing catch blok, because log crash is ignored and application performance drops.
                    // Maybe application should stop working if logs are unavailable.
                }
            }
        }

        public void InsertLog(SystemLog log)
        {
            string command = $@"INSERT INTO [dbo].[SystemLog] ([EventID],[LogLevel],[Message],[CreatedTime],[ErrorDetails]) VALUES (@EventID, @LogLevel, @Message, @CreatedTime, @ErrorDetails)";

            var paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("EventID", log.EventId));
            paramList.Add(new SqlParameter("LogLevel", log.LogLevel));
            paramList.Add(new SqlParameter("Message", log.Message));
            paramList.Add(new SqlParameter("CreatedTime", log.CreatedTime));
            paramList.Add(new SqlParameter("ErrorDetails", log.ErrorDetails));

            ExecuteNonQuery(command, paramList);
        }
    }
}
