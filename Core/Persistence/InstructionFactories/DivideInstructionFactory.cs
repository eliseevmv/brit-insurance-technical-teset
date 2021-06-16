using Core.Entities;
using Core.Entities.Instructions;

namespace Core.Persistence.InstructionFactories
{
    public class DivideInstructionFactory : IInstructionFactory
    {
        public string OperationName => "divide";

        public IInstruction Create(decimal number)
        {
            return new DivideInstruction(number);
        }
    }
}
