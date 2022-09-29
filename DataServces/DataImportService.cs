using System;
using System.Data.SqlClient;
using System.IO;
using System.Collections.Generic;
using ElectricityAccountAPI.Interfaces;
using Microsoft.Extensions.Logging;
using ElectricityAccountAPI.DataPaths;


namespace ElectricityAccountAPI.DataServces
{
    public class DataImportService : IDataImportService
    {
        private readonly ILogger<DataImportService> _logger;
        private readonly IDataImportTransformation _dataImportTransformation;
        private readonly IFilterData _filterData;
        public DataImportService(ILogger<DataImportService> logger, IDataImportTransformation dataImportTransformation, IFilterData filterData)
        {
            _logger = logger;
            _dataImportTransformation = dataImportTransformation;
            _filterData = filterData;
        }

        public string ImportFileDataToDatabaseFromFilePath()
        {
            List<string> csvDataPaths = new();
            csvDataPaths = DataPath.AddItemsToList();
            int lineNumber = 0;
            try
            {
                _logger.LogInformation($"Adding aggregated data to database");
                using (SqlConnection connection = new(DataPath.sqlConnectionDetails))
                {
                    connection.Open();
                    foreach (var item in csvDataPaths)
                    {
                        using (StreamReader reader = new(item))
                        {
                            while (!reader.EndOfStream)
                            {
                                var line = reader.ReadLine();
                                if (lineNumber != 0)
                                {
                                    line = _dataImportTransformation.InsertMissingData(line);
                                    var values = line.Split(',');
                                    if (_filterData.FilterApartmentData(values[1].ToLower(),"namas") && _filterData.FilterConsumtionData(Convert.ToDouble(values[4])))
                                    {
                                        string sqlQuery = $"INSERT INTO ElectricityAccountDB.dbo.AggregatedDatas VALUES ('{values[0]}', '{values[1]}', '{values[2]}', {Convert.ToInt32(values[3])}, {Convert.ToDouble(values[4])}, '{Convert.ToDateTime(values[5])}', {Convert.ToDouble(values[6])},{Convert.ToDouble(values[4]) - Convert.ToDouble(values[6])})";
                                        var cmd = new SqlCommand();
                                        cmd.CommandText = sqlQuery;
                                        cmd.CommandType = System.Data.CommandType.Text;
                                        cmd.Connection = connection;
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                                lineNumber++;
                            }
                        }
                    }
                    connection.Close();
                }
                return "Data aggregation and import to database succesfully completed.";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ex.Message;
            }
        }
    }
}
