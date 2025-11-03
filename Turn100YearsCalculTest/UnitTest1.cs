// This test verifies that when the user selects option 2, the program terminates correctly.//

using Microsoft.VisualStudio.TestPlatform.TestHost;
using Turn100YearsCalcul;
using NUnit.Framework;
using System;
using System.IO;
using System.Globalization;

namespace Turn100YearsCalculTest
{
    public class Tests
    {
        [Test]
        public void Main_WhenOption2_TerminatesProgram()
        {
            
            string simulatedInput = "2\n"; // This creates fake keyboard input (user selects option 2 to quit and \n to simulate Enter key to end the program)
            using var input = new StringReader(simulatedInput); // Simulate console input
            using var output = new StringWriter(); // Capture what program writes using console.writeline()

            Console.SetIn(input); // Redirect console input to our simulated input
            Console.SetOut(output); // Redirect console output to our StringWriter to capture output

            // Act
            Turn100YearsCalcul.Program.runProgram(); // Call the method that contains the main program logic

            // Assert
            string consoleOut = output.ToString(); // Get the captured output as a string
            Assert.That(consoleOut, Does.Contain("Program terminated.")); // Verify that the output contains the termination message

        }



    }
}