using Snake.Loop;
using Snake.Player;

namespace Snake.Game
{
    public sealed class GameOver : IGameLoopObject
    {
        private readonly ISnake _snake;
        private bool _isOvered;

        public GameOver(ISnake snake) 
            => _snake = snake ?? throw new ArgumentNullException(nameof(snake));

        public void Update(int delta)
        {
            if (_isOvered || _snake.IsAlive)
                return;

            Console.CursorTop = Console.WindowTop + Console.WindowHeight - 2;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.WriteLine("Game Over! ;(");
            _isOvered = true;
        }
    }
}