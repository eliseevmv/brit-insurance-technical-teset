using Core.Entities;
using Core.Entities.Instructions;

namespace Core.Persistence.InstructionFactories
{
    public class MultiplyInstructionFactory : IInstructionFactory
    {
        public string OperationName => "multiply";

        public IInstruction Create(decimal number)
        {
            return new MultiplyInstruction(number);
        }
    }
}
