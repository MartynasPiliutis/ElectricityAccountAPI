using Microsoft.EntityFrameworkCore;
using System;

namespace ElectricityAccountAPI.Models
{
    [Keyless]
    public class AggregatedData
    {
        public string PowerGrid { get; set; }
        public string ObjectName { get; set; }
        public string ObjectType { get; set; }
        public int ObjectId { get; set; }
        public double PowerConsume { get; set; }
        public DateTime LogDate { get; set; }
        public double PowerGenerate { get; set; }
        public double PowerDifference { get; set; }

        public AggregatedData(string powerGrid, string objectName, string objectType, int objectId, double powerConsume, DateTime logDate, double powerGenerate, double powerDifference)
        {
            PowerGrid = powerGrid;
            ObjectName = objectName;
            ObjectType = objectType;
            ObjectId = objectId;
            PowerConsume = powerConsume;
            LogDate = logDate;
            PowerGenerate = powerGenerate;
            PowerDifference = powerDifference;
        }
    }
}
