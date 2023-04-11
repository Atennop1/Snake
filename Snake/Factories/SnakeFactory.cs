using Snake.Core;

namespace Snake.Factories
{
    public sealed class SnakeFactory
    {
        private readonly ICellsField _cellsField;

        public SnakeFactory(ICellsField cellsField) 
            => _cellsField = cellsField ?? throw new ArgumentNullException(nameof(cellsField));

        public Snake.Player.Snake Create()
        {
            var bodyCells = new List<ICell>();
            var xOfFieldCenter = _cellsField.SizeX / 2;
            var yOfFieldCenter= _cellsField.SizeY / 2;

            for (var i = -2; i < 3; i++)
            {
                var cell = _cellsField.Cells[yOfFieldCenter + i, xOfFieldCenter];
                cell.TurnIntoSnake();
                bodyCells.Add(cell);
            }

            return new Snake.Player.Snake(_cellsField, bodyCells);
        }
    }
}