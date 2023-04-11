namespace Snake.Core
{
    public interface ICellView
    {
        void DisplayFood(int x, int y);
        void DisplayWall(int x, int y);
        void DisplayVoid(int x, int y);
        
        void DisplaySnakeBody(int x, int y);
        void DisplaySnakeHead(int x, int y);
        void DisplaySnakeTail(int x, int y);
    }
}