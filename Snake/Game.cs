using Snake.Factories;
using Snake.Loop;

namespace Snake
{
    public sealed class Game
    {
        public void Play()
        {
            var fieldFactory = new CellsFieldFactory();
            var field = fieldFactory.Create(40, 20);
            
            var foodFactory = new FoodFactory(field);
            var foodSpawningLoop = new FoodSpawningLoop(foodFactory);
            foodSpawningLoop.Update(150);

            var snakeFactory = new SnakeFactory(field);
            var snake = snakeFactory.Create();

            var snakeGameLoop = new GameLoop(new List<IGameLoopObject> { foodSpawningLoop, snake }, new GameTime(150));
            snakeGameLoop.Activate();

            var input = new Input.Input(snake);
            var inputGameLoop = new GameLoop(new List<IGameLoopObject> { input }, new GameTime(20));
            inputGameLoop.Activate();
        }
    }
}