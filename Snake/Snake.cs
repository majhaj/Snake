using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Snake
    {
        public List<(int x, int y)> Body { get; private set; }
        private (int x, int y) direction;
        private ConsoleColor color;

        public Snake((int x, int y) startPosition, ConsoleColor color)
        {
            Body = new List<(int x, int y)> { startPosition };
            direction = (1, 0);
            this.color = color;
        }

        public void ChangeDirection(ConsoleKey key, bool isPlayerOne)
        {
            if (isPlayerOne)
            {
                switch (key)
                {
                    case ConsoleKey.UpArrow: if (direction.y != 1) direction = (0, -1); break;
                    case ConsoleKey.DownArrow: if (direction.y != -1) direction = (0, 1); break;
                    case ConsoleKey.LeftArrow: if (direction.x != 1) direction = (-1, 0); break;
                    case ConsoleKey.RightArrow: if (direction.x != -1) direction = (1, 0); break;
                }
            }
            else
            {
                switch (key)
                {
                    case ConsoleKey.W: if (direction.y != 1) direction = (0, -1); break;
                    case ConsoleKey.S: if (direction.y != -1) direction = (0, 1); break;
                    case ConsoleKey.A: if (direction.x != 1) direction = (-1, 0); break;
                    case ConsoleKey.D: if (direction.x != -1) direction = (1, 0); break;
                }
            }
        }

        public void Move()
        {
            var head = Body[0];
            var newHead = (head.x + direction.x, head.y + direction.y);
            Body.Insert(0, newHead);
            Body.RemoveAt(Body.Count - 1);
        }

        public bool Eat((int x, int y) foodPosition)
        {
            if (Body[0] == foodPosition)
            {
                Body.Add(Body[^1]);
                return true;
            }
            return false;
        }

        public bool CheckCollision()
        {
            var head = Body[0];
            if (head.x < 0 || head.y < 0 || head.x >= Console.WindowWidth || head.y >= Console.WindowHeight)
                return true;

            for (int i = 1; i < Body.Count; i++)
                if (Body[i] == head) return true;

            return false;
        }

        public bool CollidesWith(Snake other)
        {
            var head = Body[0];
            foreach (var segment in other.Body)
            {
                if (segment == head) return true;
            }
            return false;
        }

        public void Draw()
        {
            Console.ForegroundColor = color;
            foreach (var part in Body)
            {
                Console.SetCursorPosition(part.x, part.y);
                Console.Write("O");
            }
            Console.ResetColor();
        }
    }
}
