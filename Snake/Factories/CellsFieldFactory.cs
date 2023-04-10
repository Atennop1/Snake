using Snake.Core;

namespace Snake.Factories
{
    public sealed class CellsFieldFactory : ICellsFieldFactory
    {
        public ICellsField Create(int width, int height)
        {
            var cells = new ICell[height, width];
            
            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    var cellView = new CellView();
                    var cell = new Cell(cellView, j, i);
                    cellView.DisplayVoid(cell.X, cell.Y);

                    if (i == 0 || i == height - 1 || j == 0 || j == width - 1)
                        cell.TurnIntoWall();
                    
                    cells[i, j] = cell;
                }
            }

            return new CellsField(cells);
        }
    }
}