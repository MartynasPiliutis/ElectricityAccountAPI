namespace ElectricityAccountAPI.Interfaces
{
    public interface IDataImportTransformation
    {
        public string InsertMissingData(string dataLine);
    }
}
