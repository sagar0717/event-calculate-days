using System;

namespace CalculateDays.Business
{
    /// <summary>
    /// The interface is to show the contract for Validation class
    /// </summary>
    public interface IValidation
    {
        bool ValidateStartDate(string Date, ref DateTime dateTime);
        bool ValidateEndDate(string Date, ref DateTime dateTime);
    }
}
