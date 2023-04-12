using Snake.Tools;

namespace Snake.Core
{
    public sealed class Cell : ICell
    {
        public CellType Type { get; }
        
        public int X { get; }
        public int Y { get; }

        public Cell(CellType type, int x, int y)
        {
            Type = type;
            X = x.ThrowExceptionIfLessThanZero();
            Y = y.ThrowExceptionIfLessThanZero();
        }
    }
}