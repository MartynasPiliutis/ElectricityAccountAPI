using System.IO;
using System.Collections.Generic;

namespace ElectricityAccountAPI.DataPaths
{
    public class DataPath
    {
        public static readonly string csvToImport04 = Path.GetFullPath(@"..\ElectricityAccountAPI\DataCSV\2022-04.csv");
        public static readonly string csvToImport05 = Path.GetFullPath(@"..\ElectricityAccountAPI\DataCSV\2022-05.csv");
        public static readonly string sqlConnectionDetails = "Server=Localhost;Database=ElectricityAccountDB;Trusted_Connection=True";
        public static readonly string sqlString = "SELECT * FROM [ElectricityAccountDB].[dbo].[AggregatedDatas] FOR JSON AUTO";


        public static List<string> AddItemsToList()
        {
            List<string> listToAdd = new List<string>();
            listToAdd.Add(csvToImport04);
            listToAdd.Add(csvToImport05);
            return listToAdd;
        }
    }
}
