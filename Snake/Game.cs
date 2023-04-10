using Snake.Factories;

namespace Snake
{
    public sealed class Game
    {
        public void Play()
        {
            var field = new CellsFieldFactory().Create(10, 10);
        }
    }
}