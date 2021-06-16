using System.Collections.Generic;

namespace Core.Entities
{
    public class InstructionsWithNumber
    {
        public decimal Number { get; private set; }
        public IEnumerable<IInstruction> PreviousInstructions { get; private set; }

        public InstructionsWithNumber(decimal number, IEnumerable<IInstruction> previousInstructions)
        {
            Number = number;
            PreviousInstructions = previousInstructions;
        }
    }
}