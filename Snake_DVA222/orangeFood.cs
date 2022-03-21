using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace Snake_DVA222
{
    internal class orangeFood : IFood
    {
        SolidBrush pen = new SolidBrush(Color.Orange);
        Pen outline = new Pen(Color.Black);
        int value;
        int points;
        Rectangle Square = new Rectangle();

        Engine Engine;
        public orangeFood(int x, int y, Engine engine)
        {
            Engine = engine;
            Square.Width = engine.GameObjectSize;
            Square.Height = engine.GameObjectSize;
            Square.X = x;
            Square.Y = y;
            value = 1;
            points = 1;
            

        }


        public void Draw(Graphics g)
        {
            g.FillRectangle(pen, Square);
            

        }

        public void TryHit(Snake snake)
        {

            snake.Hit(points, value);
            Engine.Remove(this);
        }
        public int returnPoints()
        {

            return value;
          
        }


       //Not totally accurate, if snake is slightly under food it will eat it
        public bool intersect(Snake snake)
        {

            var BodyCord = snake.GetBodyCords();
            var SnakeHeadPos = BodyCord[0];
           

            float ClosestX = Math.Clamp(SnakeHeadPos.X - Square.Width/2, Square.Left, Square.Right);
            float ClosestY = Math.Clamp(SnakeHeadPos.Y - Square.Height/2, Square.Top, Square.Bottom);

            float DistanceX = SnakeHeadPos.X - ClosestX;
            float DistanceY = SnakeHeadPos.Y - ClosestY;
            float DistanceSqrd = (DistanceX * DistanceX) + (DistanceY * DistanceY);
         
          
               if(DistanceSqrd <= (Square.Width * Square.Height))
            {
                return true;
            }

            return false;
        }
    }
}
