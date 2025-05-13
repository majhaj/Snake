using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Food
    {
        public (int x, int y) Position { get; private set; }
        private Random random = new Random();

        public void Generate(List<(int x, int y)> snakeBody)
        {
            do
            {
                Position = (random.Next(0, Console.WindowWidth),
                            random.Next(0, Console.WindowHeight));
            } while (snakeBody.Contains(Position));
        }

        public void Draw()
        {
            Console.SetCursorPosition(Position.x, Position.y);
            Console.Write("*");
        }
    }
}
