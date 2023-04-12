using Snake.Core;
using Snake.Loop;

namespace Snake.Game
{
    public sealed class GameWin : IGameLoopObject
    {
        private readonly ICellsField _cellsField;
        private readonly IGameTime _gameTime;
        private bool _isWon;

        public GameWin(ICellsField cellsField, IGameTime gameTime)
        {
            _cellsField = cellsField ?? throw new ArgumentNullException(nameof(cellsField));
            _gameTime = gameTime ?? throw new ArgumentNullException(nameof(gameTime));
        }

        public void Update(int delta)
        {
            if (_isWon)
                return;

            for (var i = 0; i < _cellsField.SizeY; i++)
            {
                for (var j = 0; j < _cellsField.SizeX; j++)
                {
                    var cell = _cellsField.GetCell(j, i);
                    
                    if (cell.Type != CellType.SnakeBody && cell.Type != CellType.SnakeTail && cell.Type != CellType.Wall)
                        return;
                }
            }
            
            Console.CursorTop = Console.WindowTop + Console.WindowHeight - 2;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.WriteLine("You win! ;P");
            
            _gameTime.Stop();
            _isWon = true;
        }
    }
}