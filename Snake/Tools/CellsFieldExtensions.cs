using Snake.Core;

namespace Snake.Tools
{
    public static class CellsFieldExtensions
    {
        public static bool IsExist(this ICellsField field, int x, int y)
            => (field.SizeY > y && y >= 0) && (field.SizeX > x && x >= 0);
    }
}