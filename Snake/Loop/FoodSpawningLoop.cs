using Snake.Core;
using Snake.Factories;

namespace Snake.Loop
{
    public sealed class FoodSpawningLoop : IGameLoopObject
    {
        private readonly IFoodFactory _foodFactory;
        private readonly ICellsField _cellsField;

        private int _lastSpawnedFoodX;
        private int _lastSpawnedFoodY;

        public FoodSpawningLoop(IFoodFactory foodFactory, ICellsField cellsField)
        {
            _foodFactory = foodFactory ?? throw new ArgumentNullException(nameof(foodFactory));
            _cellsField = cellsField ?? throw new ArgumentNullException(nameof(cellsField));
        }

        public void Update(int delta)
        {
            if (_cellsField.GetCell(_lastSpawnedFoodX, _lastSpawnedFoodY).Type == CellType.Food || !_foodFactory.CanCreate) 
                return;
            
            var food = _foodFactory.CreateInRandomCell();
            _lastSpawnedFoodX = food.X;
            _lastSpawnedFoodY = food.Y;
        }
    }
}