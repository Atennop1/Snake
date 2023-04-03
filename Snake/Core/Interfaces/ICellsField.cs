namespace Snake.Core
{
    public interface ICellsField
    {
        bool IsExist(int x, int y);
        ICell GetCell(int x, int y);
        void ReplaceCell(int x, int y, ICell cell);
    }
}