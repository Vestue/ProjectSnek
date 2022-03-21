using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace Snake_DVA222
{
    internal class yellowFood : IFood
    {
        SolidBrush pen = new SolidBrush(Color.Yellow);
        Pen outline = new Pen(Color.Black);
        
        Rectangle Square = new Rectangle();
        int value;
        int points;
        Engine Engine;
        public yellowFood(int x, int y, Engine engine)
        {
            Engine = engine;
            Square.Width = engine.GameObjectSize;
            Square.Height = engine.GameObjectSize;
            Square.X = x;
            Square.Y = y;
            value = -1;
            points = 1;

        }


        public void Draw(Graphics g)
        {

            g.FillRectangle(pen, Square);
            
        }

        public bool intersect(Snake snake)
        {

            var BodyCord = snake.GetBodyCords();
            var SnakeHeadPos = BodyCord[0];


            float ClosestX = Math.Clamp(SnakeHeadPos.X - Square.Width / 2, Square.Left, Square.Right);
            float ClosestY = Math.Clamp(SnakeHeadPos.Y - Square.Height / 2, Square.Top, Square.Bottom);

            float DistanceX = SnakeHeadPos.X - ClosestX;
            float DistanceY = SnakeHeadPos.Y - ClosestY;
            float DistanceSqrd = (DistanceX * DistanceX) + (DistanceY * DistanceY);


            if (DistanceSqrd <= (Square.Width * Square.Height))
            {
                return true;
            }

            return false;
        }

        public int returnPoints()
        {
            value = 1;

            return value;
        }

        public void TryHit(Snake snake)
        {
            snake.Hit(points, value);
            Engine.Remove(this);
        }
    }
}
