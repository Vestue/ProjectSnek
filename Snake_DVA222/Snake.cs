using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_DVA222
{
    internal class Snake
    {
        Direction Dir;
        List<Coordinate> BodyCords = new List<Coordinate>();
        public Snake(int length, Coordinate startPos, Direction dir)
        {
            Dir = dir;
            for (int i = 0; i < length; i++)
            {
                // startPos is the position of the head of the snake;
                // The snake's body is placed in the opposite direction of the starting direction
                switch(Dir)
                {
                    case Direction.Up:
                        BodyCords.Add(new Coordinate(startPos.X, startPos.Y + i));
                        break;
                    case Direction.Down:
                        BodyCords.Add(new Coordinate(startPos.X, startPos.Y - i));
                        break;
                    case Direction.Left:
                        BodyCords.Add(new Coordinate(startPos.X + i, startPos.Y));
                        break;
                    case Direction.Right:
                        BodyCords.Add(new Coordinate(startPos.X - i, startPos.Y));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public void Move ()
        {
            throw new NotImplementedException();
        }

        public void SetDirection (Direction dir)
        {
            Dir = dir;
        }
    }
}
