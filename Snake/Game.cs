using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Game
    {
        private Snake snake1;
        private Snake snake2;
        private Food food;
        private bool isRunning;

        public void Start()
        {
            Console.Clear();
            snake1 = new Snake((10, 10), ConsoleColor.Green);
            snake2 = new Snake((30, 10), ConsoleColor.Red);
            food = new Food();
            food.Generate(snake1.Body, snake2.Body);

            isRunning = true;

            while (isRunning)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;
                    snake1.ChangeDirection(key, true);  // Player 1
                    snake2.ChangeDirection(key, false); // Player 2
                }

                snake1.Move();
                snake2.Move();

                if (snake1.CheckCollision() || snake2.CheckCollision() || snake1.CollidesWith(snake2) || snake2.CollidesWith(snake1))
                {
                    isRunning = false;
                    Console.SetCursorPosition(0, 20);
                    Console.WriteLine("Game Over!");
                    break;
                }

                if (snake1.Eat(food.Position) || snake2.Eat(food.Position))
                {
                    food.Generate(snake1.Body, snake2.Body);

                    Draw();
                    Thread.Sleep(100);
                }
            }
        }
        

        private void Draw()
        {
            Console.Clear();
            snake1.Draw();
            snake2.Draw();
            food.Draw();
        }
    }
}
