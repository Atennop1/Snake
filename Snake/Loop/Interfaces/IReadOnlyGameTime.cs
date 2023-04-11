namespace Snake.Loop
{
    public interface IReadOnlyGameTime
    {
        bool IsActive { get; }
        int DeltaTime { get; }
    }
}