using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Game
    {
        private Snake _snake;
        private Food _food;
        private bool _isRunning;

        public void Start()
        {
            Console.Clear();
            _snake = new Snake();
            _food = new Food();
            // Generate food

            _isRunning = true;

            while (_isRunning)
            {
                // Update game state
                // Check for collisions
                // Render game
                // Handle input
            }
        }

        private void Draw()
        {
            Console.Clear();
            // Draw snake
            // Draw food
        }
    }
}
