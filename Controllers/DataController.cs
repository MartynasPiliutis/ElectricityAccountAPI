using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using Newtonsoft.Json;
using ElectricityAccountAPI.Models;
using ElectricityAccountAPI.Interfaces;
using ElectricityAccountAPI.DataPaths;

namespace ElectricityAccountAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class DataController : ControllerBase
    {
        private readonly ILogger<DataController> _logger;
        private readonly IDataImportService _dataImportService;
        private readonly IRetrieveDbData _retrieveDbData;

        public DataController(ILogger<DataController> logger, IDataImportService dataImportService, IRetrieveDbData retrieveDbData)
        {
            _logger = logger;
            _dataImportService = dataImportService;
            _retrieveDbData = retrieveDbData;
        }

        [HttpPost("AggregateDataToDatabase")]
        public ActionResult ImportAggregatedDataToDatabase()
        {
            var message = _dataImportService.ImportFileDataToDatabaseFromFilePath();
            return Ok(message);
        }
        [HttpGet("RetrieveData")]
        public string GetAllDataFromDatabase()
        {
            _logger.LogInformation("Starting controller execution...");
            var responseJson = _retrieveDbData.GetAllDataFromDatabase();
            return responseJson.ToString();
        }
    }
} 
