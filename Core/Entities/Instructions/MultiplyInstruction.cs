namespace Core.Entities.Instructions
{
    public class MultiplyInstruction : IInstruction
    {
        public decimal Number { get; private set; }

        public MultiplyInstruction(decimal number)
        {
            this.Number = number;
        }

        public decimal Apply(decimal a)
        {
            return a * Number;
        }
    }
}
