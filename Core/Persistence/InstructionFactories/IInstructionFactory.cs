using Core.Entities;

namespace Core.Persistence
{
    public interface IInstructionFactory
    {
        string OperationName { get; }
        IInstruction Create(decimal number);
    }
}