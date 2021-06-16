using Core;
using Core.Persistence;
using Core.Persistence.InstructionFactories;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    // These tests test the CalculatorService class with its collaborator classes but in isolation from external dependencies (the file)
    // It could be good idea to write unit tests to test each or some of these classes in isolation of all collaborators and dependencies
    public class CalculatorServiceTests
    {

        private CalculatorService SetupCalculatorService(string[] fileContent)
        {
            var fileReaderStub = new FileReaderStub(fileContent); // Prod code might use a mock framework instead of stub

            var instructionFactories = new List<IInstructionFactory>() {
                new AddInstructionFactory(),
                new SubtractInstructionFactory(),
                new MultiplyInstructionFactory(),
                new DivideInstructionFactory(),
                new ApplyInstructionFactory()
            };

            // Prod code might use the same IoC container for both tests and the console app to resolve CalculatorService
            // but tests will also configure the IoC container to resolve IFileReader as a mock which returns expected response
            return new CalculatorService(new InstructionReader(instructionFactories, fileReaderStub), new Calculator());
        }

        [Test]
        public void GivenAddInstructionShouldReturnCorrectResult()
        {
            CalculatorService calculatorService = SetupCalculatorService(new[] { "add 1", "apply 5" });

            var result = calculatorService.Calculate();

            Assert.That(result, Is.EqualTo(6));
        }

        [Test]
        public void GivenSubtractInstructionShouldReturnCorrectResult()
        {
            CalculatorService calculatorService = SetupCalculatorService(new[] { "subtract 1", "apply 5" });

            var result = calculatorService.Calculate();

            Assert.That(result, Is.EqualTo(4));
        }

        [Test]
        public void GivenMultiplyInstructionShouldReturnCorrectResult()
        {
            CalculatorService calculatorService = SetupCalculatorService(new[] { "multiply 9", "apply 5" });

            var result = calculatorService.Calculate();

            Assert.That(result, Is.EqualTo(45));
        }

        [Test]
        public void GivenDivideInstructionShouldReturnCorrectResult()
        {
            CalculatorService calculatorService = SetupCalculatorService(new[] { "divide 2", "apply 20" });

            var result = calculatorService.Calculate();

            Assert.That(result, Is.EqualTo(10));
        }

        [Test]
        public void GivenDivideWithFractionsInstructionShouldReturnCorrectResult()
        {
            CalculatorService calculatorService = SetupCalculatorService(new[] { "divide 2", "apply 1" });

            var result = calculatorService.Calculate();

            Assert.That(result, Is.EqualTo(0.5));
        }

        [Test]
        public void GivenSeveralInstructionsShouldReturnCorrectResult()
        {
            CalculatorService calculatorService = SetupCalculatorService(new[] { "add 2", "multiply 3", "apply 3" });

            var result = calculatorService.Calculate();

            Assert.That(result, Is.EqualTo(15));
        }

        // Other tests might include
        //  division by zero
        //  empty lines
        //  lines with wrong operation name
        //  lines with operation name in capital case
        //  lines with multiple whitespaces 

    }
}