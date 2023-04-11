using Snake.Factories;

namespace Snake
{
    public sealed class Game
    {
        public void Play()
        {
            var field = new CellsFieldFactory().Create(40, 20);
            var foodFactory = new FoodFactory(field);
            foodFactory.CreateInRandomCell();
        }
    }
}