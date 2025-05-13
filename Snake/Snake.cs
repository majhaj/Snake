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

        public Snake()
        {
            Body = new List<(int x, int y)> { (10, 10) };
            direction = (1, 0);
        }

        public void ChangeDirection(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow: if (direction.y != 1) direction = (0, -1); break;
                case ConsoleKey.DownArrow: if (direction.y != -1) direction = (0, 1); break;
                case ConsoleKey.LeftArrow: if (direction.x != 1) direction = (-1, 0); break;
                case ConsoleKey.RightArrow: if (direction.x != -1) direction = (1, 0); break;
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

        public void Draw()
        {
            foreach (var part in Body)
            {
                Console.SetCursorPosition(part.x, part.y);
                Console.Write("O");
            }
        }
    }
}

