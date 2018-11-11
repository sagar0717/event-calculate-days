using System;

namespace CalculateDays.Business
{
    public class ComputeDays
    {
        /// <summary>
        /// This funtion computes the number of days of between two events
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns>number of days elapsed</returns>
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
