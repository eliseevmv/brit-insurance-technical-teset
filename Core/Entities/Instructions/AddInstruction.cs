namespace Core.Entities.Instructions
{
    public class AddInstruction : IInstruction
    {
        public decimal Number { get; private set; }

        public AddInstruction(decimal number)
        {
            this.Number = number;
        }

        public decimal Apply(decimal a)
        {
            return a + Number;
        }
    }
}
