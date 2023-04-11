namespace Snake.Core
{
    public interface ICellsField
    {
        ICell[,] Cells { get; }
        
        int SizeX { get; }
        int SizeY { get; }
    }
}