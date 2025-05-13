using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Game
    {
        private Snake snake;
        private Food food;
        private bool isRunning;

        public void Start()
        {
            Console.Clear();
            snake = new Snake();
            food = new Food();
            food.Generate(snake.Body);

            isRunning = true;

            while (isRunning)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;
                    snake.ChangeDirection(key);
                }

                snake.Move();

                if (snake.CheckCollision())
                {
                    isRunning = false;
                    Console.SetCursorPosition(0, 20);
                    Console.WriteLine("Game Over!");
                    break;
                }

                if (snake.Eat(food.Position))
                {
                    food.Generate(snake.Body);
                }

                Draw();
                Thread.Sleep(100);
            }
        }

        private void Draw()
        {
            Console.Clear();
            snake.Draw();
            food.Draw();
        }
    }
}
