﻿using Snake.Loop;
using Snake.Player;

namespace Snake.Input
{
    public sealed class Input : IGameLoopObject
    {
        private readonly ISnake _snake;

        public Input(ISnake snake) 
            => _snake = snake ?? throw new ArgumentNullException(nameof(snake));

        public void Update(int delta)
        {
            if (!Console.KeyAvailable) 
                return;
            
            var keyInfo = Console.ReadKey(true);
            if (keyInfo.Key != ConsoleKey.DownArrow && keyInfo.Key != ConsoleKey.LeftArrow && keyInfo.Key != ConsoleKey.RightArrow && keyInfo.Key != ConsoleKey.UpArrow)
                return;

            var rotateDirection = keyInfo.Key switch
            {
                ConsoleKey.DownArrow => Direction.Down,
                ConsoleKey.LeftArrow => Direction.Left,
                ConsoleKey.RightArrow => Direction.Right,
                ConsoleKey.UpArrow => Direction.Up,
                _ => throw new ArgumentOutOfRangeException()
            };

            if (!_snake.CanRotate(rotateDirection))
                return;
            
            _snake.Rotate(rotateDirection);
        }
    }
}