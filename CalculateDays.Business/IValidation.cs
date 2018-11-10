using System;

namespace CalculateDays.Business
{
    public interface IValidation
    {
        bool ValidateStartDate(string Date, ref DateTime dateTime);
        bool ValidateEndDate(string Date, ref DateTime dateTime);
    }
}
