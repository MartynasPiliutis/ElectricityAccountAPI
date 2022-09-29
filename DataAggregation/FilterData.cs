using ElectricityAccountAPI.Interfaces;

namespace ElectricityAccountAPI.DataAggregation
{
    public class FilterData : IFilterData
    {
        bool IFilterData.FilterApartmentData(string valueToCheck, string valueRequired)
        {
            if (valueToCheck == valueRequired) return true;
            else return false;
        }

        bool IFilterData.FilterConsumtionData(double valueToCheck)
        {
            if (valueToCheck > 1) return false; else return true;
        }
    }
}
