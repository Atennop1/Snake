using Snake.Core;
using Snake.Factories;

namespace Snake.Loop
{
    public sealed class FoodSpawningLoop : IGameLoopObject
    {
        private readonly IFoodFactory _foodFactory;
        private ICell _lastFoodCell;

        public FoodSpawningLoop(IFoodFactory foodFactory) 
            => _foodFactory = foodFactory ?? throw new ArgumentNullException(nameof(foodFactory));

        public void Update(int delta)
        {
            if (_lastFoodCell == null || (!_lastFoodCell.IsFood && _foodFactory.CanCreate))
                _lastFoodCell = _foodFactory.CreateInRandomCell();
        }
    }
}