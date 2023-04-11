using Snake.Core;

namespace Snake.Factories
{
    public interface ICellsFactory
    {
        ICell CreateVoid(int x, int y);
        ICell CreateWall(int x, int y);
        ICell CreateFood(int x, int y);
        ICell CreateSnakeHead(int x, int y);
        ICell CreateSnakeBody(int x, int y);
        ICell CreateSnakeTail(int x, int y);
    }
}