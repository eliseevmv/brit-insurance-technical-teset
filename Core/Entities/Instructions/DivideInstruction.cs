namespace Core.Entities.Instructions
{
    public class DivideInstruction : IInstruction
    {
        public decimal Number { get; private set; }

        public DivideInstruction(decimal number)
        {
            this.Number = number;
        }

        public decimal Apply(decimal a)
        {
            return a / Number;
        }
    }
}
