namespace Snake.Core
{
    public sealed class CellsField : ICellsField
    {
        public int SizeX { get; }
        public int SizeY { get; }

        private readonly ICell[,] _cells;
        
        public ICell GetCell(int x, int y) 
            => _cells[y, x];

        public void ReplaceCell(ICell cell)
        {
            if (_cells[cell.Y, cell.X].Type == CellType.Wall)
                throw new InvalidOperationException("Can't replace wall");

            _cells[cell.Y, cell.X] = cell ?? throw new ArgumentNullException(nameof(cell));
        }

        public CellsField(ICell[,] cells)
        {
            SizeY = cells.GetLength(0);
            SizeX = cells.GetLength(1);
            _cells = cells ?? throw new ArgumentNullException(nameof(cells));
            
            Console.CursorVisible = false;
        }
    }
}