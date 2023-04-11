using Snake.Core;

namespace Snake.Factories
{
    public sealed class CellsFieldFactory : ICellsFieldFactory
    {
        private readonly ICellsFactory _cellsFactory;

        public CellsFieldFactory(ICellsFactory cellsFactory) 
            => _cellsFactory = cellsFactory ?? throw new ArgumentNullException(nameof(cellsFactory));

        public ICellsField Create(int width, int height)
        {
            var cells = new ICell[height, width];
            
            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    var cell = _cellsFactory.CreateVoid(j, i);

                    if (i == 0 || i == height - 1 || j == 0 || j == width - 1)
                        cell = _cellsFactory.CreateWall(j, i);
                    
                    cells[i, j] = cell;
                }
            }

            return new CellsField(cells);
        }
    }
}