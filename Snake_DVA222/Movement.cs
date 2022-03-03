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
            if ((key == ConsoleKey.UpArrow && snake.ID == 2) || (key == ConsoleKey.W && snake.ID == 1)) snake.SetDirection(Direction.Up);
            else if ((key == ConsoleKey.DownArrow && snake.ID == 2) || (key == ConsoleKey.S && snake.ID == 1)) snake.SetDirection(Direction.Down);
            else if ((key == ConsoleKey.LeftArrow && snake.ID == 2) || (key == ConsoleKey.A && snake.ID == 1)) snake.SetDirection(Direction.Left);
            else if ((key == ConsoleKey.RightArrow && snake.ID == 2) || (key == ConsoleKey.D && snake.ID == 1)) snake.SetDirection(Direction.Right);
        }
    }
}
