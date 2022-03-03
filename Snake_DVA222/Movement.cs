using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_DVA222
{
    internal class Movement
    {
        public void Move(ConsoleKey key, Snake snake)
        {
            // Kolla om snake är null

            // Change method names depending on implementation
            if (key == ConsoleKey.UpArrow || key == ConsoleKey.W) snake.Move(Direction.Up);
            else if (key == ConsoleKey.DownArrow || key == ConsoleKey.S) snake.Move(Direction.Down);
            else if (key == ConsoleKey.LeftArrow || key == ConsoleKey.A) snake.Move(Direction.Left);
            else if (key == ConsoleKey.RightArrow || key == ConsoleKey.D) snake.Move(Direction.Right);
        }
    }
}
