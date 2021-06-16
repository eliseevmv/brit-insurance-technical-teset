using System;

namespace Core.Entities
{
    public class ApplyInstruction : IInstruction
    {
        public decimal Number { get; private set; }

        public ApplyInstruction(decimal number)
        {
            Number = number;
        }

        public decimal Apply(decimal a)
        {
            throw new NotImplementedException();
        }
    }
}
