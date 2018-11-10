using CalculateDays.Business;
using System;

namespace CalculateDays
{
    class Program
    {
        static void Main(string[] args)
        {
            bool validStartDate = false;
            bool validEndDate = false;
            DateTime StartDate = DateTime.MinValue;
            DateTime EndDate = DateTime.MaxValue;
            IValidation validation = new Validation();
            ComputeDays daysElapsed = new ComputeDays();


            while (!validStartDate)
            {
                Console.Write("Please enter start date in format DD/MM/YYYY: ");
                string startDateInput = Console.ReadLine();
                validStartDate = validation.ValidateStartDate(startDateInput, ref StartDate);
                if (!validStartDate)
                    Console.WriteLine("Invalid Start Date.");
            }

            while (!validEndDate)
            {
                Console.Write("Please enter end date in format DD/MM/YYYY: ");
                string endDateInput = Console.ReadLine();
                validEndDate = validation.ValidateEndDate(endDateInput, ref EndDate);
                if (!validEndDate)
                    Console.WriteLine("Invalid End Date.");
            }

            if (validStartDate && validStartDate)
            {
                Console.WriteLine("Dates Validated!");
                int numberOfDays = daysElapsed.CalculateDaysElapse(StartDate, EndDate);
                Console.WriteLine(numberOfDays);

            }
            Console.ReadLine();
        }
    }
}

