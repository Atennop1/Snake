using Snake.Input;

namespace Snake.Player
{
    public sealed class Snake : ISnake
    {
        private RotateDirection _currentDirection;
        
        public bool CanRotate(RotateDirection direction)
        {
            switch (_currentDirection)
            {
                case RotateDirection.Down when direction == RotateDirection.Up:
                case RotateDirection.Up when direction == RotateDirection.Down:
                case RotateDirection.Left when direction == RotateDirection.Right:
                case RotateDirection.Right when direction == RotateDirection.Left:
                    return false;
            }
            
            return true;
        }

        public void Rotate(RotateDirection direction)
        {
            if (!CanRotate(direction))
                throw new InvalidOperationException("Can't rotate snake to this direction");

            _currentDirection = direction;
        }
    }
}