using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using Newtonsoft.Json;
using ElectricityAccountAPI.Interfaces;
using ElectricityAccountAPI.DataPaths;
using Microsoft.Extensions.Logging;

namespace ElectricityAccountAPI.DataServces
{
    public class RetrieveDbData : IRetrieveDbData
    {
        private readonly ILogger<RetrieveDbData> _logger;

        public RetrieveDbData(ILogger<RetrieveDbData> logger)
        {
            _logger = logger;
        }
        public StringBuilder GetAllDataFromDatabase()
        {
            _logger.LogInformation("Retrieving all data from database... This might take for a while...");
            using (SqlConnection connection = new SqlConnection(DataPath.sqlConnectionDetails))
            {
                using (SqlCommand command = new SqlCommand(DataPath.sqlString, connection))
                {
                    connection.Open();
                    var responseJson = new StringBuilder();
                    var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            responseJson.Append(reader.GetValue(0).ToString());
                        }
/*                    _logger.LogInformation("Starting data deserialization...");
                    dynamic json = JsonConvert.DeserializeObject(responseJson.ToString());
                    _logger.LogInformation("Deserialization complete.");*/
                    connection.Close();
                    return responseJson;
                    //return json;
                }
            }
        }
    }
}
