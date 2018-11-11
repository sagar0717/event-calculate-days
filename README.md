# event-calculate-days
1. A console application to calculate the number of days elapsed between two events. 
For the calculation purspose, First day and Last day are considered partial days, hence not counted in days elapsed. e.g. First day = 10/11/2018 and Last day = 11/11/2018
then days elapsed = 0;
2. User can either enter input from the console or an input source can be provided to calculate the days. For demo purspose a sample XML file is added to the project 
which takes the values of start and end date based on eventid and provide the output result in a text file.

## Pre-Requisites

1. Programming Language: C#
2. Target Frameowrk :.NET Framework 4.6.1
3. NUnit and NUnit3 Test Adapter installed and configured on the selected IDE. 
4. IDE : Visual Studio

## Assumptions:

1. If First Day and Last Day are same then both are considered partial days thus days elapsed = 0.
2. Dates can only be enetred in DD/MM/YYYY format.
3. If any spaces are put in the dates with the correct format, the system will remove it and consider it as valid date. 
e.g "01/&nbsp;&nbsp;11/2&nbsp;&nbsp;018" is a valid date.
4. Only XML file as input source is handled currently except Input from user.


## Running the Application
#### Input from console (Project - CalculateDays)
1. Unzip the project.
2. Move to the application CalculateDays.exe available under CalculateDays -> bin -> debug and double click to run it.
3. User will be asked to enter Start and End Date


#### Input from other source (Project - CalculateDays.ExternalData)
1. Unzip the project.
2. Move to the application CalculateDays.ExternalData available under CalculateDays.ExternalData -> bin -> debug and double click to run it.
3. Input from XML file(EventDates.xml) for different events would be taken and result would be available in DaysElapsed.txt file.
   Sample Input and Output file available under Resources

## Running the tests 
1. Unzip the project.
2. Open the solution file in IDE.
3. Install NUnit and NUnit3 Test Adapter from Nuget Packages.
4. Run the tests.


## Author
Sagar Kathuria
