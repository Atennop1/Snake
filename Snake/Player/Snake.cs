using Snake.Core;
using Snake.Input;
using Snake.Loop;

namespace Snake.Player
{
    public sealed class Snake : ISnake, IGameLoopObject
    {
        public bool IsAlive { get; private set; }
        
        private ICell Head => _bodyCells[^1];
        private ICell Tail => _bodyCells[0];

        private readonly ICellsField _cellsField;
        private readonly List<ICell> _bodyCells;
        private RotateDirection _currentDirection;

        public Snake(ICellsField cellsField, List<ICell> bodyCells)
        {
            _cellsField = cellsField ?? throw new ArgumentNullException(nameof(cellsField));
            _bodyCells = bodyCells ?? throw new ArgumentNullException(nameof(bodyCells));
            _currentDirection = RotateDirection.Down;
            IsAlive = true;
        }

        public void Update(int delta)
        {
            if (!IsAlive)
                return;
            
            var nextCell = GetNextCell();
            if (nextCell.IsPlayer || nextCell.IsWall)
            {
                IsAlive = false;
                return;
            }
            
            if (!nextCell.IsFood)
            {
                Tail.Clear();
                _bodyCells.Remove(Tail);
            }
            
            nextCell.TurnIntoSnake();
            _bodyCells.Add(nextCell);
        }

        private ICell GetNextCell()
        {
            var xShift = _currentDirection switch
            {
                RotateDirection.Left => -1,
                RotateDirection.Right => 1,
                _ => 0
            };
            
            var yShift = _currentDirection switch
            {
                RotateDirection.Down => 1,
                RotateDirection.Up => -1,
                _ => 0
            };

            return _cellsField.Cells[Head.Y + yShift, Head.X + xShift];
        }

        public bool CanRotate(RotateDirection direction)
            => !((_currentDirection == RotateDirection.Down && direction == RotateDirection.Up) ||
               (_currentDirection == RotateDirection.Up && direction == RotateDirection.Down) ||
               (_currentDirection == RotateDirection.Left && direction == RotateDirection.Right) ||
               (_currentDirection == RotateDirection.Right && direction == RotateDirection.Left));

        public void Rotate(RotateDirection direction)
        {
            if (!CanRotate(direction))
                throw new InvalidOperationException("Can't rotate snake to this direction");

            _currentDirection = direction;
        }
    }
}