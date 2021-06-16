namespace Core.Entities
{
    public interface IInstruction
    {
        decimal Number { get; }
        decimal Apply(decimal a);
    }
}