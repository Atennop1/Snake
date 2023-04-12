using Snake.Core;

namespace Snake.Factories
{
    public sealed class CellsFactory : ICellsFactory
    {
        public ICell CreateVoid(int x, int y)
        {
            var cell = new Cell(CellType.Void, x, y);
            var cellView = new CellView();
            cellView.DisplayVoid(x, y);
            return cell;
        }
        
        public ICell CreateWall(int x, int y)
        {
            var cell = new Cell(CellType.Wall, x, y);
            var cellView = new CellView();
            cellView.DisplayWall(x, y);
            return cell;
        }
        
        public ICell CreateFood(int x, int y)
        {
            var cell = new Cell(CellType.Food, x, y);
            var cellView = new CellView();
            cellView.DisplayFood(x, y);
            return cell;
        }
        
        public ICell CreateSnakeHead(int x, int y)
        {
            var cell = new Cell(CellType.SnakeBody, x, y);
            var cellView = new CellView();
            cellView.DisplaySnakeHead(x, y);
            return cell;
        }
        
        public ICell CreateSnakeBody(int x, int y)
        {
            var cell = new Cell(CellType.SnakeBody, x, y);
            var cellView = new CellView();
            cellView.DisplaySnakeBody(x, y);
            return cell;
        }
        
        public ICell CreateSnakeTail(int x, int y)
        {
            var cell = new Cell(CellType.SnakeTail, x, y);
            var cellView = new CellView();
            cellView.DisplaySnakeTail(x, y);
            return cell;
        }
    }
}