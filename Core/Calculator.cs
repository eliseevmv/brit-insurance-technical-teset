using Core.Entities;

namespace Core
{
    public interface ICalculator
    {
        decimal Calculate(InstructionsWithNumber instructions);
    }

    public class Calculator: ICalculator
    {
        public decimal Calculate(InstructionsWithNumber instructions)
        {
            decimal curr = instructions.Number;
            foreach (var instruction in instructions.PreviousInstructions)
            {
                curr = instruction.Apply(curr);
            }
            return curr;
        }
    }
}