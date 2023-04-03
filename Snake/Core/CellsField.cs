namespace Snake.Core
{
    public sealed class CellsField : ICellsField
    {
        private readonly ICell[,] _cells;

        public CellsField(ICell[,] cells) 
            => _cells = cells ?? throw new ArgumentNullException(nameof(cells));

        public bool IsExist(int x, int y)
        {
            var xLength = _cells.GetLength(1);
            var yLength = _cells.GetLength(0);
            return (yLength > y && y >= 0) && (xLength > x && x >= 0);
        }

        public ICell GetCell(int x, int y)
            => _cells[y, x];

        public void ReplaceCell(int x, int y, ICell cell) 
            => _cells[y, x] = cell;
    }
}