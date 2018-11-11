using CalculateDays.Business;
using System;
using System.Text.RegularExpressions;

namespace CalculateDays
{
    class Program
    {
        static void Main(string[] args)
        {
            IValidation validation = new Validation();
            ComputeDays daysElapsed = new ComputeDays();
            DateTime StartDate = DateTime.MinValue;
            DateTime EndDate = DateTime.MaxValue;
            string yesNo;

            do
            {
                bool validStartDate = false;
                bool validEndDate = false;

                //Validating the start date and making user enter until he enters in correct format
                while (!validStartDate)
                {
                    Console.Write("Please enter start date in format DD/MM/YYYY: ");
                    string startDateInput = Regex.Replace(Console.ReadLine(), @"\s", "");
                    validStartDate = validation.ValidateStartDate(startDateInput, ref StartDate);
                    if (!validStartDate)
                        Console.WriteLine("Invalid Start Date.");
                }

                //Validating the end date and making user enter until he enters in correct format
                while (!validEndDate)
                {
                    Console.Write("Please enter end date in format DD/MM/YYYY: ");
                    string endDateInput = Regex.Replace(Console.ReadLine(), @"\s", "");
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

                Console.WriteLine("Press 'e' to exit or 'y' to calculate days for another event");
                yesNo = Console.ReadLine().ToLower();
                while (!yesNo.Equals("y") && !yesNo.Equals("e"))
                {

                    Console.WriteLine("Invalid Input!");

                    Console.WriteLine("Press 'e' to exit or 'y' to perform another conversion");

                    yesNo = Console.ReadLine().ToLower();

                }
            }
            while (yesNo.Equals("y"));
        }
    }
}

