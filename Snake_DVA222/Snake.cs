﻿using System;
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
        int BodyPartsToAdd = 0;

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
        public int GetPoints() => Points;

        public void Move(int width, int height)
        {
            // If there are body parts left to add (after food is eaten) 
            // then don't remove the last one until there are no more body parts to add
            if (BodyPartsToAdd > 0)
            {
                BodyPartsToAdd--;
            }
            else if (BodyPartsToAdd < 0)
            {
                BodyPartsToAdd++;
                BodyCords.RemoveAt(BodyCords.Count - 1);    // TODO: Better way to write this?
                BodyCords.RemoveAt(BodyCords.Count - 1);
            }
            else
            {
                // Remove the last body part
                BodyCords.RemoveAt(BodyCords.Count - 1);
            }

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

        public Direction SetDirection(Direction dir) => Dir = dir;

        public List<Coordinate> GetBodyCords() => BodyCords;

        private void Hit()
        {
            // Hit function for hitting a wall or bodypart
            throw new NotImplementedException();
        }

        public void Hit(int points, int lengthIncrease)
        {
            // Hit() function for Food
            Points += points;
            BodyPartsToAdd += lengthIncrease;
        }

        public bool SnakeCollide(Snake snake)
        {
            // Works for both other snakes and itself
            if (snake == null) throw new ArgumentNullException();

            List<Coordinate> otherBodyCords = snake.GetBodyCords();

            for (int i = 0; i < otherBodyCords.Count; i++)
            {
                // If the snake is checking its own body then don't check the head (would always falsely return true)
                if (i == 0 && this == snake) i++;
                // You only need to check if the head of this snake is hitting 
                if (BodyCords[0].X == otherBodyCords[i].X && BodyCords[0].Y == otherBodyCords[i].Y)
                {
                    Hit();
                    return true;
                }
            }
            return false;
        }
    }
}
