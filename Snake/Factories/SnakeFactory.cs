using Snake.Core;

namespace Snake.Factories
{
    public sealed class SnakeFactory : ISnakeFactory
    {
        private readonly ICellsField _cellsField;
        private readonly ICellsFactory _cellsFactory;

        public SnakeFactory(ICellsField cellsField, ICellsFactory cellsFactory)
        {
            _cellsField = cellsField ?? throw new ArgumentNullException(nameof(cellsField));
            _cellsFactory = cellsFactory ?? throw new ArgumentNullException(nameof(cellsFactory));
        }

        public Snake.Player.Snake Create()
        {
            var bodyCells = new List<ICell>();
            var xOfFieldCenter = _cellsField.SizeX / 2;
            var yOfFieldCenter= _cellsField.SizeY / 2;

            for (var i = -2; i < 3; i++)
            {
                var cell = _cellsFactory.CreateSnakeBody(xOfFieldCenter, yOfFieldCenter + i);
                
                if (i == -2)
                    cell = _cellsFactory.CreateSnakeTail(xOfFieldCenter, yOfFieldCenter + i);
                
                if (i == 2)
                    cell = _cellsFactory.CreateSnakeHead(xOfFieldCenter, yOfFieldCenter + i);
                
                _cellsField.ReplaceCell(cell);
                bodyCells.Add(cell);
            }

            return new Snake.Player.Snake(_cellsField, bodyCells, _cellsFactory);
        }
    }
}