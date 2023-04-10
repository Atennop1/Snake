namespace Snake.Core
{
    public sealed class CellsField : ICellsField
    {
        public int SizeX { get; }
        public int SizeY { get; }
        
        private readonly ICell[,] _cells;

        public CellsField(ICell[,] cells)
        {
            SizeY = cells.GetLength(0);
            SizeX = cells.GetLength(1);
            _cells = cells ?? throw new ArgumentNullException(nameof(cells));
        }

        public ICell GetCell(int x, int y)
            => _cells[y, x];

        public void ReplaceCell(int x, int y, ICell cell) 
            => _cells[y, x] = cell ?? throw new ArgumentNullException(nameof(cell));
    }
}