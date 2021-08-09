using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using AirParticulateSensor;
using TestedClass = AirParticulateSensor.LocationList;
using System.Collections.Generic;
using System.Linq;

namespace AirParticulatesSensorTests
{
    [TestClass]
    public class TestFixture_LocationList
    {
        public TestFixture_LocationList()
        {
            this.locationTests = new List<LocationTest>();
        }

        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }

            set
            {
                testContextInstance = value;
            }
        }

        // Create tested class for testing purposes
        public LocationList testedClass;
        public List<LocationTest> locationTests { get; }

        // Common constructor values for testing purposes
        public const string LOCATION1 = "Quayside";
        public const string DATE1 = "18/02/2020";
        public const int VALUE1 = 13;
        public const double TEMPERATURE1 = 8.0;
        public const double HUMIDITY1 = 51.5;

        public const string LOCATION2 = "St. Peters";
        public const string DATE2 = "19/02/2020";
        public const int VALUE2 = 15;
        public const double TEMPERATURE2 = 10.5;
        public const double HUMIDITY2 = 59.5;

        [TestInitialize]
        public void TestInitialize()
        {

        }

        [TestCleanup]
        public void TestCleanup()
        {
            // Ensure that tested class object reference can be garbage collected after testing
            testedClass = null;
        }

        // These tests for play being recorded as used properly
        [TestMethod]
        public void DisplayLocation()
        {
            // Arrange
            testedClass = new LocationList();

            var expected = from loc in this.locationTests
                           orderby loc.LocationName
                           select loc;

            // Act
            var actual = testedClass.DisplayLocationAscending();
            var failMessage = String.Format(@"Should show {0} but shows {1}!", expected, actual);

            // Assert
            Assert.AreEqual(expected, actual, failMessage);
        }

        [TestMethod]
        public void DisplayLargestParticulates()
        {
            // Arrange
            testedClass = new LocationList();

            var expected = from loc in this.locationTests
                           from read in loc.Readings
                           let large = loc.Readings.Max(x => x.Value)
                           where read.Value > 16
                           select new
                           {
                               loc = loc.LocationName,
                               date = read.Date,
                               value = read.Value
                           };

            // Act
            var actual = testedClass.DisplayLargest();

            var failMessage = String.Format(@"Should show {0} but shows {1}!", expected, actual);

            // Assert
            Assert.AreEqual(expected, actual, failMessage);
        }

        [TestMethod]
        public void DisplayDates()
        {
            // Arrange
            testedClass = new LocationList();

            var expected = 
                from loc in this.locationTests
                from read in loc.Readings
                orderby read.Date
                select new
                           {
                               Name = loc.LocationName,
                               date = read.Date,
                               value = read.Value,
                               temperature = read.Temperature,
                               humidity = read.Humidity
                           };

            // Act
            var actual = testedClass.DisplayLocationReading();

            var failMessage = String.Format(@"Should show {0} but shows {1}!", expected, actual);

            // Assert
            Assert.AreEqual(expected, actual, failMessage);
        }
    }
}
