using Snake.Core;

namespace Snake.Factories
{
    public sealed class CellsFactory : ICellsFactory
    {
        public ICell CreateVoid(int x, int y)
        {
            var cell = new Cell(x, y);
            var cellView = new CellView();
            cellView.DisplayVoid(x, y);
            return cell;
        }
        
        public ICell CreateWall(int x, int y)
        {
            var cell = new Cell(x, y, isWall: true);
            var cellView = new CellView();
            cellView.DisplayWall(x, y);
            return cell;
        }
        
        public ICell CreateFood(int x, int y)
        {
            var cell = new Cell(x, y, isFood: true);
            var cellView = new CellView();
            cellView.DisplayFood(x, y);
            return cell;
        }
        
        public ICell CreateSnakeHead(int x, int y)
        {
            var cell = new Cell(x, y, isPlayer: true);
            var cellView = new CellView();
            cellView.DisplaySnakeHead(x, y);
            return cell;
        }
        
        public ICell CreateSnakeBody(int x, int y)
        {
            var cell = new Cell(x, y, isPlayer: true);
            var cellView = new CellView();
            cellView.DisplaySnakeBody(x, y);
            return cell;
        }
        
        public ICell CreateSnakeTail(int x, int y)
        {
            var cell = new Cell(x, y, isPlayer: true);
            var cellView = new CellView();
            cellView.DisplaySnakeTail(x, y);
            return cell;
        }
    }
}