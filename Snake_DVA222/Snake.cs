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
        int Points = 0;
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
        public int Points() => Points;

        public void Move(int width, int height)
        {
            // Remove the last body part
            BodyCords.RemoveAt(BodyCords.Count - 1);

            // Add a new body part in front of the head in the direction the snake is going in
            switch (Dir)
            {
                case Direction.Up:
                    if (BodyCords[0].Y - 1 < 0) {  Hit(); }
                    BodyCords.Insert(0, new Coordinate(BodyCords[0].X, BodyCords[0].Y - 1));
                    break;
                case Direction.Down:
                    if (BodyCords[0].Y + 1 > height) { Hit(); }
                    BodyCords.Insert(0, new Coordinate(BodyCords[0].X, BodyCords[0].Y + 1));
                    break;
                case Direction.Left:
                    if (BodyCords[0].X - 1 < 0) { Hit(); }
                    BodyCords.Insert(0, new Coordinate(BodyCords[0].X - 1, BodyCords[0].Y));
                    break;
                case Direction.Right:
                    if (BodyCords[0].X + 1 > width) { Hit(); }
                    BodyCords.Insert(0, new Coordinate(BodyCords[0].X + 1, BodyCords[0].Y));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void SetDirection(Direction dir) => Dir = dir;

        private void Hit()
        {
            // Hit function for hitting a wall or bodypart
            throw new NotImplementedException();
        }

        public void Hit(int points)
        {
            // Hit() function for Food
            Points += points;
            // TODO: Add more body parts according to the amount of points
        }
    }
}
