using Snake.Core;

namespace Snake.Factories
{
    public interface ICellsFieldFactory
    {
        ICellsField Create(int width, int height);
    }
}