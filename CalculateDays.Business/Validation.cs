using System;
using System.Globalization;

namespace CalculateDays.Business
{
    /// <summary>
    /// This class inherits the Ivalidation interface and implements its methods
    /// </summary>
    public class Validation : IValidation
    {
        private static DateTime minDateTime = DateTime.Parse("01/01/1901");
        private static DateTime maxDateTime = DateTime.Parse("31/12/2999");

        /// <summary>
        /// This function validates the start date against the right format allowed (DD/MM/YYYY) and 
        /// also against the allowed limit i.e. minDateTime
        /// </summary>
        /// <param name="Date"></param>
        /// <param name="dateTime"></param>
        /// <returns>Result (True or False)</returns>
        public bool ValidateStartDate(string Date, ref DateTime dateTime)
        {
            try
            {
                dateTime = DateTime.ParseExact(Date, "dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo);
                if (dateTime < minDateTime)
                {
                    return false;
                }

            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// This function validates the end date against the right format allowed (DD/MM/YYYY) and 
        /// also against the allowed limit i.e. maxDateTime
        /// </summary>
        /// <param name="Date"></param>
        /// <param name="dateTime"></param>
        /// <returns>Result (True or False) </returns>
        public bool ValidateEndDate(string Date, ref DateTime dateTime)
        {
            try
            {
                dateTime = DateTime.ParseExact(Date, "dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo);
                if (dateTime > maxDateTime)
                {
                    return false;
                }
            }
            catch
            {

                return false;
            }
            return true;
        }
    }
}
