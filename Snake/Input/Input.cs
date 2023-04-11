using Snake.Loop;
using Snake.Player;

namespace Snake.Input
{
    public sealed class Input : IGameLoopObject
    {
        private readonly ISnake _snake;

        public Input(ISnake snake) 
            => _snake = snake ?? throw new ArgumentNullException(nameof(snake));

        public void Update(int delta)
        {
            if (!Console.KeyAvailable) 
                return;
            
            var keyInfo = Console.ReadKey();
            if (keyInfo.Key is not ConsoleKey.DownArrow or ConsoleKey.LeftArrow or ConsoleKey.RightArrow or ConsoleKey.UpArrow)
                return;
            
            var rotateDirection = keyInfo.Key switch
            {
                ConsoleKey.DownArrow => RotateDirection.Down,
                ConsoleKey.LeftArrow => RotateDirection.Left,
                ConsoleKey.RightArrow => RotateDirection.Right,
                ConsoleKey.UpArrow => RotateDirection.Up
            };

            if (!_snake.CanRotate(rotateDirection))
                return;
            
            _snake.Rotate(rotateDirection);
        }
    }
}