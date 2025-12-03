namespace JwtFlow.Domain.BackOffice.ObjectValue;

public struct FlightCity
{
    public FlightCity()
    {
        
    }
    public FlightCity(string cityStart, string cityOut)
    {
        if (!IsValid(cityStart, cityOut))
            throw new Exception();
        CityStart = cityStart;
        CityOut = cityOut;
    }

    public string CityStart { get;private set; }
    public string CityOut { get;private set; }

    private void SetCityStart(string otherCity)
        => CityStart = otherCity;
    private void SetCityOut(string otherCity)
        => CityOut = otherCity;
    
    public bool IsValid(string cityStart, string cityOut)
    {
        if (string.IsNullOrEmpty(cityOut) || string.IsNullOrEmpty(cityOut)|| cityStart == cityOut)
            return false;
        return true;
    }
}