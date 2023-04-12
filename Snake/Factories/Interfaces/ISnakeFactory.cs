using Snake.Player;

namespace Snake.Factories
{
    public interface ISnakeFactory
    {
        ISnake Create();
    }
}