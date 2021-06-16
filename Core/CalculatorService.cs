using Core.Persistence;

namespace Core
{

    // In production code this interface  will be used for resolving this class from an IoC container
    interface ICalculatorService
    {
        decimal Calculate();
    }

      public class CalculatorService : ICalculatorService
    {
        private IInstructionReader instructionsReader;
        private ICalculator calculator;

        public CalculatorService(IInstructionReader instructionsReader, ICalculator calculator)
        {
            this.instructionsReader = instructionsReader;
            this.calculator = calculator;
        }

        public decimal Calculate()
        {
            var instructions = instructionsReader.Read();
            return calculator.Calculate(instructions);
        }
    }
}
