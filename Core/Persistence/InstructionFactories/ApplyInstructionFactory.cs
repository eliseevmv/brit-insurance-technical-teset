using Core.Entities;

namespace Core.Persistence.InstructionFactories
{
    public class ApplyInstructionFactory : IInstructionFactory
    {
        public string OperationName => "apply"; 

        public IInstruction Create(decimal number)
        {
            return new ApplyInstruction(number);
        }
    }
}
