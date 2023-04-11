using Snake.Tools;

namespace Snake.Core
{
    public sealed class Cell : ICell
    {
        public int X { get; }
        public int Y { get; }
        
        public bool IsPlayer { get; }
        public bool IsWall { get; }
        public bool IsFood { get; }

        public Cell(int x, int y, bool isPlayer = false, bool isWall = false, bool isFood = false)
        {
            X = x.ThrowExceptionIfLessThanZero();
            Y = y.ThrowExceptionIfLessThanZero();

            IsPlayer = isPlayer;
            IsWall = isWall;
            IsFood = isFood;
        }
    }
}