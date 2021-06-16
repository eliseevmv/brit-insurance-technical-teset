using Core.Entities;
using Core.Entities.Instructions;

namespace Core.Persistence.InstructionFactories
{
    public class AddInstructionFactory : IInstructionFactory
    {
        public string OperationName => "add";

        public IInstruction Create(decimal number)
        {
            return new AddInstruction(number);
        }
    }
}
