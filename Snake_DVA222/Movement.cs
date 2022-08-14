using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_DVA222
{
    internal class Movement
    {
        public void Move(KeyEventArgs key, Snake snake)
        {
            // EXTENSION
            // Added control keys for third snake
            List<Keys> keyList = snake.GetKeyList();
            if (keyList == null) throw new ArgumentException();

            if (key == null)
            {
                snake.SetDirection(Direction.Right);
                return;
            }
            // EXTENSION
            // Revamped the entire control system to use the controls that are now stored in the snake
            for(int i = 0; i < keyList.Count; i++)
            {
                if(key.KeyCode == keyList[i])
                {
                    switch(i)
                    {
                        case 0:
                            if(snake.GetDirection() != Direction.Down) snake.SetDirection(Direction.Up);
                            break;
                        case 1:
                            if (snake.GetDirection() != Direction.Up) snake.SetDirection(Direction.Down);
                            break;
                        case 2:
                            if (snake.GetDirection() != Direction.Right) snake.SetDirection(Direction.Left);
                            break;
                        case 3:
                            if (snake.GetDirection() != Direction.Left) snake.SetDirection(Direction.Right);
                            break;

                    }
                }
            }
        }
    }
}
