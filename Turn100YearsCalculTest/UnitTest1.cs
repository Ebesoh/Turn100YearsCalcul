// This test verifies that when the user selects option 2, the program terminates correctly.//

using Microsoft.VisualStudio.TestPlatform.TestHost;
using Turn100YearsCalcul;
using NUnit.Framework;
using System;
using System.IO;
using System.Globalization;

namespace Turn100YearsCalculTest
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void SetNameAge_ShouldAssignValuesCorrectly() // Test for SetNameAge method
        {
            // Arrange
            var person = new NameAgeCal();
            string expectedName = "Alice";
            float expectedAge = 25.5f;

            // Act
            person.SetNameAge(expectedName, expectedAge); // Call the method to test

            // Assert
            Assert.That(person.Name, Is.EqualTo(expectedName));
            Assert.That(person.Age, Is.EqualTo(expectedAge));
        }

        [Test]
        public void CalculateYearWhen100_ShouldReturnCorrectYear()
        {
            // Arrange
            var person = new NameAgeCal();
            person.SetNameAge("Bob", 25);

            float currentYear = DateTime.Now.Year;
            float expected = currentYear + (100 - 25);

            // Act
            float result = person.CalculateYearWhen100();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void CalculateYearWhen100_ShouldHandleDecimalAgesCorrectly()
        {
            // Arrange
            var person = new NameAgeCal();
            person.SetNameAge("Eve", 45.5f);

            float currentYear = DateTime.Now.Year;
            float expected = currentYear + (100 - 45.5f);

            // Act
            float result = person.CalculateYearWhen100();

            // Assert
            Assert.That(result, Is.EqualTo(expected).Within(0.0001), "Calculation should handle decimals precisely.");
        }

        [Test]
        public void CalculateYearWhen100_ShouldIncreaseWhenAgeIsSmaller()
        {
            // Arrange
            var younger = new NameAgeCal();
            var older = new NameAgeCal();
            younger.SetNameAge("Chris", 20);
            older.SetNameAge("John", 50);

            // Act
            float yearYounger = younger.CalculateYearWhen100();// Call the method to test
            float yearOlder = older.CalculateYearWhen100();

            // Assert
            Assert.That(yearYounger, Is.GreaterThan(yearOlder), "Younger person should reach 100 later.");// Assert that the younger person's year is greater than the older person's year
        }

        [Test]
        public void DefaultValues_ShouldBeInitializedCorrectly()
        {
            // Arrange
            var person = new NameAgeCal();

            // Assert
            Assert.That(person.Name, Is.EqualTo(string.Empty));
            Assert.That(person.Age, Is.EqualTo(0));
        }
    }
}