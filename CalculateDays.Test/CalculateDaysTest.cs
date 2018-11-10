using CalculateDays.Business;
using NUnit.Framework;
using System;
using System.Globalization;

namespace CalculateDays.Test
{
    [TestFixture]
    class CalculateDaysTest
    {
        IValidation validate;
        DateTime MinDate = DateTime.MinValue;
        DateTime MaxDate = DateTime.MaxValue;

        [OneTimeSetUp]
        public void TestInit()
        {
            validate = new Validation();

        }

        [Test]
        public void Should_ReturnFalse_When_InvalidFormat_StartDate()
        {
            //Arrange
            string startDateInput = "01-01/2011";

            //Act
            bool expectedValue = validate.ValidateStartDate(startDateInput, ref MinDate);

            //Assert
            Assert.IsFalse(expectedValue, "Date in valid Format");
        }

        [Test]
        public void Should_Return_False_When_StartDate_SmallerThanAllowed()
        {
            //Arrange
            string startDateInput = "31/12/1900";

            //Act
            bool expectedValue = validate.ValidateStartDate(startDateInput, ref MinDate);

            //Assert
            Assert.IsFalse(expectedValue, "Valid Date Entered");
        }

        [Test]
        public void Should_Return_False_When_InvalidFormat_EndDate()
        {
            //Arrange
            string endDateInput = "01-01-2011";

            //Act
            bool expectedValue = validate.ValidateStartDate(endDateInput, ref MaxDate);

            //Assert
            Assert.IsFalse(expectedValue, "Date in valid Format");
        }

        [OneTimeTearDown]
        public void TestCleanup()
        { }
    }

    [TestFixture]
    public class ComputeDaysTest
    {
        ComputeDays computeDays;
        IValidation validation;
        [OneTimeSetUp]
        public void TestInit()
        {
            computeDays = new ComputeDays();
            validation = new Validation();
        }

        [Test]
        public void Should_Return_DaysElapsed_When_Valid_StartDate_And_Valid_EndDate()
        {
            //Arrange
            string startDateInput = "02/06/1983";
            string endDateInput = "22/06/1983";
            DateTime startDateTime = DateTime.ParseExact(startDateInput, "dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo);
            DateTime endDateTime = DateTime.ParseExact(endDateInput, "dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo);

            //Act
            int NumberOfDaysElapse = computeDays.CalculateDaysElapse(startDateTime, endDateTime);

            //Assert
            Assert.AreEqual(19, NumberOfDaysElapse);
        }

    }
}
