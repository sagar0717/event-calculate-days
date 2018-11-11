using CalculateDays.Business;
using NUnit.Framework;
using System;
using System.Globalization;

namespace CalculateDays.Test
{
    /// <summary>
    /// This test class is to test methods ValidateStartDate and ValidateEndDate of Validation class.
    /// </summary>
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

        /// <summary>
        /// This test method tests the ValidateStartDate method of Validation class.
        /// The methods assert True if the date format is correct.
        /// </summary>
        [Test]
        public void Should_ReturnTrue_When_ValidFormat_StartDate()
        {
            //Arrange
            string startDateInput = "01/01/2011";

            //Act
            bool expectedValue = validate.ValidateStartDate(startDateInput, ref MinDate);

            //Assert
            Assert.IsTrue(expectedValue, "Date not in valid Format");
        }

        /// <summary>
        /// This test method tests the ValidateEndDate method of Validation class.
        /// The methods assert True if the date format is correct.
        /// </summary>
        [Test]
        public void Should_ReturnTrue_When_ValidFormat_EndDate()
        {
            //Arrange
            string endDateInput = "01/01/2011";

            //Act
            bool expectedValue = validate.ValidateEndDate(endDateInput, ref MaxDate);

            //Assert
            Assert.IsTrue(expectedValue, "Date not in valid Format");
        }

        /// <summary>
        /// This test method tests the ValidateStartDate method of Validation class.
        /// The methods assert False if the date format is incorrect.
        /// </summary>
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

        /// <summary>
        /// This test method tests the ValidateStartDate method of Validation class.
        /// The methods assert False if the date entered is less than allowed value.
        /// </summary>
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

        /// <summary>
        /// This test method tests the ValidateEndDate method of Validation class.
        /// The methods assert False if the date Format is invalid.
        /// </summary>
        [Test]
        public void Should_Return_False_When_InvalidFormat_EndDate()
        {
            //Arrange
            string endDateInput = "01-01-2011";

            //Act
            bool expectedValue = validate.ValidateEndDate(endDateInput, ref MaxDate);

            //Assert
            Assert.IsFalse(expectedValue, "Date in valid Format");
        }

        /// <summary>
        /// This test method tests the ValidateEndDate method of Validation class.
        /// The methods assert False if the date entered is greater than allowed value.
        /// </summary>
        [Test]
        public void Should_Return_False_When_EndDate_GreaterThanAllowed()
        {
            //Arrange
            string endDateInput = "01/01/3000";

            //Act
            bool expectedValue = validate.ValidateEndDate(endDateInput, ref MaxDate);

            //Assert
            Assert.IsFalse(expectedValue, "Date in valid Format");
        }

        /// <summary>
        /// This test method tests the ValidateStartDate method of Validation class.
        /// The methods assert False if the date entered is a set of characters.
        /// </summary>

        [Test]
        public void Should_Return_False_When_StartDate_Entered_As_Characters()
        {
            //Arrange
            string startDateInput = "abcde1111";

            //Act
            bool expectedValue = validate.ValidateStartDate(startDateInput, ref MinDate);

            //Assert
            Assert.IsFalse(expectedValue, "Date in valid Format");

        }

        [OneTimeTearDown]
        public void TestCleanup()
        {
            validate = null;
        }
    }

    /// <summary>
    /// This test class is for testing CalculateDaysElapse method of ComputeDays class.
    /// </summary>
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

        /// <summary>
        /// This test method tests the CalculateDaysElapse method of ComputeDays class
        /// It validates when start and end date are in valid format.
        /// It asserts the value returned by method against the expected value.
        /// </summary>
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

        /// <summary>
        /// This test method tests the CalculateDaysElapse method of ComputeDays class.
        /// It validates when Start Date is greater than end Date.
        /// It asserts the value returned by method against the expected value.
        /// </summary>
        [Test]
        public void Should_Return_DaysElapsed_When_StartDate_GreaterThan_EndDate()
        {
            //Arrange
            string startDateInput = "22/07/1983";
            string endDateInput = "02/06/1983";
            DateTime startDateTime = DateTime.ParseExact(startDateInput, "dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo);
            DateTime endDateTime = DateTime.ParseExact(endDateInput, "dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo);

            //Act
            int NumberOfDaysElapse = computeDays.CalculateDaysElapse(startDateTime, endDateTime);

            //Assert
            Assert.AreEqual(49, NumberOfDaysElapse);
        }

        /// <summary>
        /// This test method tests the CalculateDaysElapse method of ComputeDays class.
        /// It validates when Start Date is equal to end Date.
        /// It asserts the value returned by method against the expected value of 0.
        /// </summary>
        [Test]
        public void Should_Return_0_DaysElapsed_When_StartDate_Equal_EndDate()
        {
            //Arrange
            string startDateInput = "22/06/1983";
            string endDateInput = "22/06/1983";
            DateTime startDateTime = DateTime.ParseExact(startDateInput, "dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo);
            DateTime endDateTime = DateTime.ParseExact(endDateInput, "dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo);

            //Act
            int NumberOfDaysElapse = computeDays.CalculateDaysElapse(startDateTime, endDateTime);

            //Assert
            Assert.AreEqual(0, NumberOfDaysElapse);
        }

        /// <summary>
        /// This test method tests the CalculateDaysElapse method of ComputeDays class.
        /// It validates when Start Date and End Date are partial days.
        /// It asserts the value returned by method against the expected value.
        /// </summary>
        [Test]
        public void Should_Return_0_DaysElapsed_When_StartDate_EndDate_PartialDays()
        {
            //Arrange
            string startDateInput = "22/06/1983";
            string endDateInput = "23/06/1983";
            DateTime startDateTime = DateTime.ParseExact(startDateInput, "dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo);
            DateTime endDateTime = DateTime.ParseExact(endDateInput, "dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo);

            //Act
            int NumberOfDaysElapse = computeDays.CalculateDaysElapse(startDateTime, endDateTime);

            //Assert
            Assert.AreEqual(0, NumberOfDaysElapse);
        }

        [OneTimeTearDown]
        public void TestCleanup()
        {
            computeDays = null;
            validation = null;
        }

    }
}
