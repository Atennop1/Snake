using Snake.Factories;
using Snake.Loop;

namespace Snake.Game
{
    public sealed class Game
    {
        public void Play()
        {
            var cellsFactory = new CellsFactory();
            
            var fieldFactory = new CellsFieldFactory(cellsFactory);
            var field = fieldFactory.Create(40, 20);
            
            var foodFactory = new FoodFactory(field, cellsFactory);
            var foodSpawningLoop = new FoodSpawningLoop(foodFactory, field);
            foodSpawningLoop.Update(150);

            var snakeFactory = new SnakeFactory(field, cellsFactory);
            var snake = snakeFactory.Create();

            var gameTime = new GameTime(150);
            var gameOver = new GameOver(snake);
            var gameWin = new GameWin(field, gameTime);

            var snakeGameLoop = new GameLoop(new List<IGameLoopObject> { foodSpawningLoop, snake, gameOver, gameWin }, gameTime);
            snakeGameLoop.Activate();

            var input = new Input.Input(snake);
            var inputGameLoop = new GameLoop(new List<IGameLoopObject> { input }, new GameTime(20));
            inputGameLoop.Activate();
        }
    }
}