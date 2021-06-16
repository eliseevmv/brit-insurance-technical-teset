using Core;
using Core.Persistence;
using Core.Persistence.InstructionFactories;
using System;
using System.Collections.Generic;

/* Assumptions
 * 
 * 1. This code needs to deal with monetary values rather than integer values or physical values
 *    Therefore decimals are used instead of integers or float/double types.
 *    In ideal scenario I would try to get an answer for this question before coding
 * 2. Number of instructions is not too large so it could easily fit into memory
 * */

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculatorService = ResolveCalculatorService();
            var result = calculatorService.Calculate();
            Console.WriteLine(result);
        }

        static CalculatorService ResolveCalculatorService()
        {
            string filePath = "input.txt"; // Production code will get it from the config file
                                           // Production code will use an IoC container instead of this method

            var instructionFactories = new List<IInstructionFactory>()
            {
                new AddInstructionFactory(),
                new SubtractInstructionFactory(),
                new MultiplyInstructionFactory(),
                new DivideInstructionFactory(),
                new ApplyInstructionFactory()
            };

            return new CalculatorService(new InstructionReader(instructionFactories, new FileReader(filePath)), new Calculator());
        }
    }
}
