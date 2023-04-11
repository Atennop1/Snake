using Snake.Core;

namespace Snake.Factories
{
    public sealed class FoodFactory : IFoodFactory
    {
        private readonly ICellsField _cellsField;
        private readonly ICellsFactory _cellsFactory;

        public FoodFactory(ICellsField cellsField, ICellsFactory cellsFactory)
        {
            _cellsField = cellsField ?? throw new ArgumentNullException(nameof(cellsField));
            _cellsFactory = cellsFactory ?? throw new ArgumentNullException(nameof(cellsFactory));
        }

        public bool CanCreate
        {
            get
            {
                for (var i = 0; i < _cellsField.SizeY; i++)
                {
                    for (var j = 0; j < _cellsField.SizeX; j++)
                    {
                        var cell = _cellsField.GetCell(j, i);
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
            var cellInWhichCreating = _cellsField.GetCell(random.Next(0, _cellsField.SizeX), random.Next(0, _cellsField.SizeY));
            
            while (cellInWhichCreating.IsPlayer || cellInWhichCreating.IsWall || cellInWhichCreating.IsFood)
                cellInWhichCreating = _cellsField.GetCell(random.Next(0, _cellsField.SizeX), random.Next(0, _cellsField.SizeY));
            
            _cellsField.ReplaceCell(_cellsFactory.CreateFood(cellInWhichCreating.X, cellInWhichCreating.Y));
            return _cellsField.GetCell(cellInWhichCreating.X, cellInWhichCreating.Y);
        }
    }
}