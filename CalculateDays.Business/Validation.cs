using System;
using System.Globalization;

namespace CalculateDays.Business
{
    public class Validation : IValidation
    {
        private static DateTime minDateTime = DateTime.Parse("01/01/1901");
        private static DateTime maxDateTime = DateTime.Parse("31/12/2999");

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
