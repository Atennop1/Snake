using Snake.Core;

namespace Snake.Factories
{
    public sealed class FoodFactory : IFoodFactory
    {
        private readonly ICellsField _cellsField;

        public FoodFactory(ICellsField cellsField) 
            => _cellsField = cellsField ?? throw new ArgumentNullException(nameof(cellsField));

        public bool CanCreate
        {
            get
            {
                for (var i = 0; i < _cellsField.SizeY; i++)
                {
                    for (var j = 0; j < _cellsField.SizeX; j++)
                    {
                        var cell = _cellsField.Cells[i, j];
                        if (!cell.IsFood && !cell.IsPlayer && !cell.IsWall)
                            return true;
                    }
                }

                return false;
            }
        }

        public ICell CreateInRandomCell()
        {
            if (!CanCreate)
                throw new InvalidOperationException("Field is full");
            
            var random = new Random();
            var cellInWhichCreating = _cellsField.Cells[random.Next(0, _cellsField.SizeY), random.Next(0, _cellsField.SizeX)];
            
            while (cellInWhichCreating.IsPlayer || cellInWhichCreating.IsWall || cellInWhichCreating.IsFood)
                cellInWhichCreating = _cellsField.Cells[random.Next(0, _cellsField.SizeY), random.Next(0, _cellsField.SizeX)];
            
            cellInWhichCreating.TurnIntoFood();
            return cellInWhichCreating;
        }
    }
}