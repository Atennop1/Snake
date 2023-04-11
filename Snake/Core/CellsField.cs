namespace Snake.Core
{
    public sealed class CellsField : ICellsField
    {
        public ICell[,] Cells { get; }
        
        public int SizeX { get; }
        public int SizeY { get; }

        public CellsField(ICell[,] cells)
        {
            SizeY = cells.GetLength(0);
            SizeX = cells.GetLength(1);
            Cells = cells ?? throw new ArgumentNullException(nameof(cells));
            
            Console.CursorVisible = false;
        }
    }
}