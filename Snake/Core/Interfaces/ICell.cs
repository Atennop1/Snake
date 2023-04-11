namespace Snake.Core
{
    public interface ICell
    {
        int X { get; }
        int Y { get; }
        
        bool IsPlayer { get; }
        bool IsWall { get; }
        bool IsFood { get; }
    }
}