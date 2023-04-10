using Snake.Core;

namespace Snake.Factories
{
    public interface IFoodFactory
    {
        bool CanCreate { get; }
        ICell CreateInRandomCell();
    }
}