using System.Text;


namespace ElectricityAccountAPI.Interfaces
{
    public interface IRetrieveDbData
    {
        public StringBuilder GetAllDataFromDatabase();
    }
}
