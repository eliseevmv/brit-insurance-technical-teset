using Core.Entities;
using Core.Entities.Instructions;

namespace Core.Persistence.InstructionFactories
{
    public class SubtractInstructionFactory : IInstructionFactory
    {
        public string OperationName => "subtract";

        public IInstruction Create(decimal number)
        {
            return new SubtractInstruction(number);
        }
    }
}
