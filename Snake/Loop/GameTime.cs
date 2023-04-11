using Snake.Tools;

namespace Snake.Loop
{
    public sealed class GameTime : IGameTime
    {
        public bool IsActive { get; private set; }
        public int DeltaTime { get; }

        public GameTime(int deltaTime) 
            => DeltaTime = deltaTime.ThrowExceptionIfLessOrEqualsZero();

        public void Start() 
            => IsActive = true;

        public void Stop() 
            => IsActive = false;
    }
}