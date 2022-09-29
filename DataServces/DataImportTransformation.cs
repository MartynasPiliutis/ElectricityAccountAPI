using ElectricityAccountAPI.Interfaces;
using Microsoft.Extensions.Logging;


namespace ElectricityAccountAPI.DataServces
{
    public class DataImportTransformation : IDataImportTransformation
    {
        private readonly ILogger<DataImportTransformation> _logger;

        public DataImportTransformation(ILogger<DataImportTransformation> logger)
        {
            _logger = logger;
        }

        public string InsertMissingData(string dataLine)
        {
            if (dataLine.Contains(",,"))
            {
                dataLine = dataLine.Replace(",,", ",0,");
                _logger.LogInformation("Added missing value 0 to ,,");
            }

            if (dataLine.EndsWith(","))
            {
                dataLine += "0";
                _logger.LogInformation("Added missing value 0 to end of string");
            }
            return dataLine;
        }
    }
}
