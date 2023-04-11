using Snake.Input;

namespace Snake.Player;

public interface ISnake
{
    bool CanRotate(RotateDirection direction);
    void Rotate(RotateDirection direction);
}