using CalculateDays.Business;
using System;
using System.IO;
using System.Text;

namespace CalculateDays.ExternalData
{
    class Program
    {
        static void Main(string[] args)
        {
            IValidation validation = new Validation();
            ComputeDays daysElapsed = new ComputeDays();
            DateTime StartDate = DateTime.MinValue;
            DateTime EndDate = DateTime.MaxValue;
            LoadDataXML dataXML = new LoadDataXML();

            string _filePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\CalculateDays.ExternalData\Resources"));
            dataXML.Loaddata(_filePath);

            // verifies if the output result file already exists and delete it to allow the system 
            // to create a new one for the next input file

            if (File.Exists(_filePath + @"\DaysElapsed.txt"))
            {
                File.Delete(_filePath + @"\DaysElapsed.txt");
            }

            foreach (EventDetails u in LoadDataXML.events) 
            {
                bool validStartDate = false;
                bool validEndDate = false;

                // validates the start date of an event
               // if not logs the error in output file and move to the next iteration
                validStartDate = validation.ValidateStartDate(u.EventStartDate, ref StartDate);
                if (!validStartDate)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("Event Id: " + u.EventId + " - " + "Invalid Start Date");
                    using (StreamWriter swriter = new StreamWriter(_filePath + @"\DaysElapsed.txt", true))
                    {
                        swriter.WriteLine(sb.ToString());
                    }
                    continue;
                }

                // validates the end date of an event
                // if not logs the error in output file and move to the next iteration
                validEndDate = validation.ValidateEndDate(u.EventEndDate, ref EndDate);
                if (!validEndDate)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("Event Id: " + u.EventId + " - " + "Invalid End Date");
                    using (StreamWriter swriter = new StreamWriter(_filePath + @"\DaysElapsed.txt", true))
                    {
                        swriter.WriteLine(sb.ToString());
                    }
                    continue;
                }

                // if the start and end date are valid compute the number of days beween the event 
                // and log the result in the output file
                if (validStartDate && validStartDate)
                {
                    int numberOfDays = daysElapsed.CalculateDaysElapse(StartDate, EndDate);
                    StringBuilder sb = new StringBuilder();
                    sb.Append("Event Id: " + u.EventId + " - " + "Number of Days Elapsed: " + numberOfDays);
                    using (StreamWriter swriter = new StreamWriter(_filePath + @"\DaysElapsed.txt", true))
                    {
                        swriter.WriteLine(sb.ToString());
                    }
                }
            }

        }
    }
}
