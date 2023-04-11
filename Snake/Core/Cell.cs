using Snake.Tools;

namespace Snake.Core
{
    public sealed class Cell : ICell
    {
        public int X { get; }
        public int Y { get; }
        
        public bool IsPlayer { get; private set; }
        public bool IsWall { get; private set; }
        public bool IsFood { get; private set; }

        private readonly ICellView _cellView;

        public Cell(ICellView cellView, int x, int y)
        {
            _cellView = cellView ?? throw new ArgumentNullException(nameof(cellView));
            X = x.ThrowExceptionIfLessThanZero();
            Y = y.ThrowExceptionIfLessThanZero();
        }
        
        public void TurnIntoFood()
        {
            IsFood = true;
            IsWall = IsPlayer = false;
            _cellView.DisplayFood(X, Y);
        }

        public void TurnIntoWall()
        {
            IsWall = true;
            IsFood = IsPlayer = false;
            _cellView.DisplayWall(X, Y);
        }

        public void Clear()
        {
            IsPlayer = IsWall = IsFood = false;
            _cellView.DisplayVoid(X, Y);
        }

        public void TurnIntoSnakeBody()
        {
            IsPlayer = true;
            IsWall = IsFood = false;
            _cellView.DisplaySnakeBody(X, Y);
        }

        public void TurnIntoSnakeHead()
        {
            IsPlayer = true;
            IsWall = IsFood = false;
            _cellView.DisplaySnakeHead(X, Y);
        }

        public void TurnIntoSnakeTail()
        {
            IsPlayer = true;
            IsWall = IsFood = false;
            _cellView.DisplaySnakeTail(X, Y);
        }
    }
}