namespace Snake.Core
{
    public sealed class CellView : ICellView
    {
        public void DisplayFood(int x, int y)
        {
            Console.SetCursorPosition(x * 2, y);
            Console.Write("@ ");
        }

        public void DisplaySnake(int x, int y)
        {
            Console.SetCursorPosition(x * 2, y);
            Console.Write("* ");
        }

        public void DisplayWall(int x, int y)
        {
            Console.SetCursorPosition(x * 2, y);
            Console.Write("# ");
        }

        public void DisplayVoid(int x, int y)
        {
            Console.SetCursorPosition(x * 2, y);
            Console.Write(". ");
        }
    }
}