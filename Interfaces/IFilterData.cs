namespace ElectricityAccountAPI.Interfaces
{
    public interface IFilterData
    {
        public bool FilterApartmentData(string valueToCheck, string valueRequired);
        public bool FilterConsumtionData(double valueToCheck);
    }
}
