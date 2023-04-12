using Snake.Input;
using Snake.Loop;

namespace Snake.Player
{
    public interface ISnake : IGameLoopObject
    {
        bool IsAlive { get; }
        bool CanRotate(Direction direction);
        void Rotate(Direction direction);
    }
}