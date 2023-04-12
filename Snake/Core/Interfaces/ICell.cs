namespace Snake.Core
{
    public interface ICell
    {
        CellType Type { get; }
        
        int X { get; }
        int Y { get; }
    }
}