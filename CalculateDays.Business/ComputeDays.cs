using System;

namespace CalculateDays.Business
{
    public class ComputeDays
    {
        public int CalculateDaysElapse(DateTime StartDate, DateTime EndDate)
        {
            if (StartDate == EndDate)
                return (EndDate-StartDate).Days;
            else
            {
                int numberOfDays = (EndDate > StartDate) ? (EndDate - StartDate).Days - 1 : (StartDate - EndDate).Days - 1;
                return numberOfDays;
            }
        }
    }
}
