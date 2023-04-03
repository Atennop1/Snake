namespace Snake.Core
{
    public interface ICellView
    {
        void DisplayFood(int x, int y);
        void DisplaySnake(int x, int y);
        void DisplayWall(int x, int y);
        void DisplayVoid(int x, int y);
    }
}