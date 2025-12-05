using JwtFlow.Domain.BackOffice.Exceptions;

namespace JwtFlow.Domain.BackOffice.ObjectValue;

public class FlightDate
{
    protected FlightDate()
    {
    }
    public FlightDate(DateTime dateStart, DateTime dateOut)
    {
        if (!IsValid(dateStart, dateOut))
            throw new FlightDateException("Error in constructor");
        DateStart = dateStart;
        DateOut =dateOut;
    }
    public DateTime DateStart { get;private set; }
    public DateTime DateOut { get;private set; }

    public void SetDateStart(DateTime otherDate)
        => DateStart = otherDate;
    public void SetDateOut(DateTime otherDate)
        => DateOut = otherDate;

    public bool IsValid(DateTime dateStart, DateTime dateOut)
    {
        if (dateStart > dateOut || dateStart < DateTime.Now)
            return false;
        return true;
    }
}