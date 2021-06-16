namespace Core.Entities.Instructions
{
    public class SubtractInstruction : IInstruction
    {
        public decimal Number { get; private set; }

        public SubtractInstruction(decimal number)
        {
            this.Number = number;
        }

        public decimal Apply(decimal a)
        {
            return a - Number;
        }
    }
}
