using Snake.Core;
using Snake.Factories;
using Snake.Input;

namespace Snake.Player
{
    public sealed class Snake : ISnake
    {
        public bool IsAlive { get; private set; } = true;
        
        private ICell HeadCell => _bodyCells[^1];
        private ICell TailCell => _bodyCells[0];

        private readonly ICellsField _cellsField;
        private readonly List<ICell> _bodyCells;
        private readonly ICellsFactory _cellsFactory;
        
        private Direction _currentDirection = Direction.Down;

        public Snake(ICellsField cellsField, List<ICell> bodyCells, ICellsFactory cellsFactory)
        {
            _cellsField = cellsField ?? throw new ArgumentNullException(nameof(cellsField));
            _bodyCells = bodyCells ?? throw new ArgumentNullException(nameof(bodyCells));
            _cellsFactory = cellsFactory ?? throw new ArgumentNullException(nameof(cellsFactory));
        }

        public void Update(int delta)
        {
            if (!IsAlive)
                return;
            
            var nextCell = GetNextCell();
            if (nextCell.Type is CellType.Wall or CellType.SnakeBody)
            {
                IsAlive = false;
                return;
            }
            
            if (nextCell.Type != CellType.Food)
            {
                _cellsField.ReplaceCell(_cellsFactory.CreateVoid(TailCell.X, TailCell.Y));
                _bodyCells.Remove(TailCell);
                _cellsField.ReplaceCell(_cellsFactory.CreateSnakeTail(TailCell.X, TailCell.Y));
            }
            
            _cellsField.ReplaceCell(_cellsFactory.CreateSnakeBody(HeadCell.X, HeadCell.Y));
            _cellsField.ReplaceCell(_cellsFactory.CreateSnakeHead(nextCell.X, nextCell.Y));
            _bodyCells.Add(nextCell);
        }

        private ICell GetNextCell()
        {
            var xShift = _currentDirection switch
            {
                Direction.Left => -1,
                Direction.Right => 1,
                _ => 0
            };
            
            var yShift = _currentDirection switch
            {
                Direction.Down => 1,
                Direction.Up => -1,
                _ => 0
            };

            return _cellsField.GetCell(HeadCell.X + xShift, HeadCell.Y + yShift);
        }

        public bool CanRotate(Direction direction)
            => !((_currentDirection == Direction.Down && direction == Direction.Up) ||
               (_currentDirection == Direction.Up && direction == Direction.Down) ||
               (_currentDirection == Direction.Left && direction == Direction.Right) ||
               (_currentDirection == Direction.Right && direction == Direction.Left));

        public void Rotate(Direction direction)
        {
            if (!CanRotate(direction))
                throw new InvalidOperationException("Can't rotate snake to this direction");

            _currentDirection = direction;
        }
    }
}